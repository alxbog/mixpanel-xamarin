using System;
using System.Collections.Generic;
using Foundation;

namespace MixpanelLib
{
	public class Tweak<TValue> : Tweak
    {
		private TweakObserver _observer;
		private List<WeakReference<TweakBindingImpl>> _bindings = new List<WeakReference<TweakBindingImpl>>();

		internal Tweak(string name, TValue defaultValue) : base(name, defaultValue, null, null)
		{
		}

		internal Tweak(string name, TValue defaultValue, TValue min, TValue max) : base(name, defaultValue, min, max)
		{
		}

        public TValue GetValue()
        {
			var mpTweak = GetInternalTweak();
			return ConvertValue(mpTweak.CurrentValue ?? mpTweak.DefaultValue);
        }

		public TweakBinding Bind(Action<TValue> binding)
        {
			var bindingHolder = new TweakBindingImpl(binding);

			lock(_bindings)
			{
				if (_observer == null)
				{
					_observer = new TweakObserver(this);
					var mpTweak = GetInternalTweak();
					mpTweak.AddObserver(_observer);
				}
				_bindings.Add(new WeakReference<TweakBindingImpl>(bindingHolder));
			}

			binding(GetValue());

			return bindingHolder;
        }

		private MPTweak GetInternalTweak()
		{
			var mpTweak = MPTweakStore.SharedInstance().TweakWithName(Name);
			if (mpTweak == null)
				throw new InvalidOperationException($"Tweak '{Name}' is not registered. Use MixpanelTweaks.Register() before using tweaks.");

			return mpTweak;
		}

		private TValue ConvertValue(NSObject obj)
		{
			var valueType = typeof(TValue);

			if (valueType == typeof(int))
			{
				return (TValue)(object)((NSNumber)obj).Int32Value;
			}
			else if (valueType == typeof(float))
			{
				return (TValue)(object)((NSNumber)obj).FloatValue;
			}
			else if (valueType == typeof(bool))
			{
				return (TValue)(object)((NSNumber)obj).BoolValue;
			}
			else if (valueType == typeof(string))
			{
				return (TValue)(object)(string)(NSString)obj;
			}
			else
			{
				throw new InvalidOperationException($"Type {valueType} is not supported as a tweak value type.");
			}
		}

		private class TweakObserver : MPTweakObserver
		{
			private Tweak<TValue> _tweak;

			public TweakObserver(Tweak<TValue> tweak)
			{
				_tweak = tweak;
			}

			public override void TweakDidChange(MPTweak tweak)
			{
				List<TweakBindingImpl> bindings = new List<TweakBindingImpl>();

				var tweakBindings = _tweak._bindings;
				lock (tweakBindings)
				{
					for (var i = tweakBindings.Count - 1; i >= 0; i--)
					{
						var current = tweakBindings[i];

						TweakBindingImpl binding;
						if (!current.TryGetTarget(out binding) || binding.IsDisposed)
							tweakBindings.RemoveAt(i);

						bindings.Add(binding);
					}
				}

				var val = _tweak.GetValue();
				foreach (var binding in bindings)
				{
					binding.Apply(val);
				}
			}
		}

		private class TweakBindingImpl : TweakBinding
		{
			private Action<TValue> _binding;

			public TweakBindingImpl(Action<TValue> binding)
			{
				_binding = binding;
			}

			public void Apply(TValue value)
			{
				if (IsDisposed)
					return;

				_binding(value);
			}

			public override void Dispose()
			{
				base.Dispose();
				_binding = null;
			}
		}
	}

	public abstract class TweakBinding : IDisposable
	{
		private bool _isDisposed;

		public bool IsDisposed => _isDisposed;

		public virtual void Dispose()
		{
			_isDisposed = true;
		}
	}

	public abstract class Tweak
    {
		internal Tweak(string name, object defaultValue, object min = null, object max = null)
		{
			Name = name;
			DefaultValue = defaultValue;
			Min = min;
			Max = max;
		}

		internal string Name { get; }
		internal object DefaultValue { get; }
		internal object Min { get; }
		internal object Max { get; }

		public static Tweak<TValue> Declare<TValue>(string name, TValue defaultValue)
        {
            return new Tweak<TValue>(name, defaultValue);
        }

		public static Tweak<TValue> Declare<TValue>(string name, TValue defaultValue, TValue min, TValue max)
		{
			return new Tweak<TValue>(name, defaultValue, min, max);
		}
	}

	public static class MixpanelTweaks
    {
		public static void Register(Type appTweaks)
        {
			var tweakStore = MPTweakStore.SharedInstance();

			var fields = appTweaks.GetFields();
			foreach (var field in fields)
			{
				var tweak = (Tweak)field.GetValue(null);
				LoadOrCreateMixpanelTweak(tweakStore, tweak);
			}
        }

		private static MPTweak LoadOrCreateMixpanelTweak(MPTweakStore store, Tweak tweak)
		{
			var mpTweak = store.TweakWithName(tweak.Name);
			if (mpTweak != null)
				return mpTweak;

			mpTweak = CreateMixpanelTweak(tweak);
			store.AddTweak(mpTweak);
			return mpTweak;
		}

		private static MPTweak CreateMixpanelTweak(Tweak tweak)
		{
			var tweakType = tweak.GetType();
			var valueType = tweakType.GetGenericArguments()[0];

			MPTweak mpTweak;
			if (valueType == typeof(int))
			{
				mpTweak = new MPTweak(tweak.Name, "i");
				mpTweak.DefaultValue = NSNumber.FromInt32((int)tweak.DefaultValue);
				if (tweak.Min != null)
					mpTweak.MinimumValue = NSNumber.FromInt32((int)tweak.Min);
				if (tweak.Max != null)
					mpTweak.MaximumValue = NSNumber.FromInt32((int)tweak.Max);
			}
			else if (valueType == typeof(float))
			{
				mpTweak = new MPTweak(tweak.Name, "f");
				mpTweak.DefaultValue = NSNumber.FromFloat((float)tweak.DefaultValue);
				if (tweak.Min != null)
					mpTweak.MinimumValue = NSNumber.FromFloat((float)tweak.Min);
				if (tweak.Max != null)
					mpTweak.MaximumValue = NSNumber.FromFloat((float)tweak.Max);
			}
			else if (valueType == typeof(bool))
			{
				mpTweak = new MPTweak(tweak.Name, "c");
				mpTweak.DefaultValue = NSNumber.FromBoolean((bool)tweak.DefaultValue);
			}
			else if (valueType == typeof(string))
			{
				mpTweak = new MPTweak(tweak.Name, "@");
				mpTweak.DefaultValue = new NSString((string)tweak.DefaultValue);
			}
			else
			{
				throw new InvalidOperationException($"Type {valueType} is not supported as a tweak value type. Supported types: bool, int, float, string.");
			}
			return mpTweak;
		}
	}
}