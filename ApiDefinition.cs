using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace MixpanelLib
{
	// @interface MixpanelPeople : NSObject
	[BaseType (typeof(NSObject))]
	interface MixpanelPeople
	{
		// @property (atomic) BOOL ignoreTime;
		[Export ("ignoreTime")]
		bool IgnoreTime { get; set; }

		// -(void)addPushDeviceToken:(NSData * _Nonnull)deviceToken;
		[Export ("addPushDeviceToken:")]
		void AddPushDeviceToken (NSData deviceToken);

		// -(void)removeAllPushDeviceTokens;
		[Export ("removeAllPushDeviceTokens")]
		void RemoveAllPushDeviceTokens ();

		// -(void)removePushDeviceToken:(NSData * _Nonnull)deviceToken;
		[Export ("removePushDeviceToken:")]
		void RemovePushDeviceToken (NSData deviceToken);

		// -(void)set:(NSDictionary * _Nonnull)properties;
		[Export ("set:")]
		void Set (NSDictionary properties);

		// -(void)set:(NSString * _Nonnull)property to:(id _Nonnull)object;
		[Export ("set:to:")]
		void Set (string property, NSObject @object);

		// -(void)setOnce:(NSDictionary * _Nonnull)properties;
		[Export ("setOnce:")]
		void SetOnce (NSDictionary properties);

		// -(void)unset:(NSArray * _Nonnull)properties;
		[Export ("unset:")]
		void Unset (NSString[] properties);

		// -(void)increment:(NSDictionary * _Nonnull)properties;
		[Export ("increment:")]
		void Increment (NSDictionary properties);

		// -(void)increment:(NSString * _Nonnull)property by:(NSNumber * _Nonnull)amount;
		[Export ("increment:by:")]
		void Increment (string property, NSNumber amount);

		// -(void)append:(NSDictionary * _Nonnull)properties;
		[Export ("append:")]
		void Append (NSDictionary properties);

		// -(void)union:(NSDictionary * _Nonnull)properties;
		[Export ("union:")]
		void Union (NSDictionary properties);

		// -(void)remove:(NSDictionary * _Nonnull)properties;
		[Export ("remove:")]
		void Remove (NSDictionary properties);

		// -(void)trackCharge:(NSNumber * _Nonnull)amount;
		[Export ("trackCharge:")]
		void TrackCharge (NSNumber amount);

		// -(void)trackCharge:(NSNumber * _Nonnull)amount withProperties:(NSDictionary * _Nullable)properties;
		[Export ("trackCharge:withProperties:")]
		void TrackCharge (NSNumber amount, [NullAllowed] NSDictionary properties);

		// -(void)clearCharges;
		[Export ("clearCharges")]
		void ClearCharges ();

		// -(void)deleteUser;
		[Export ("deleteUser")]
		void DeleteUser ();
	}

	// @interface Mixpanel : NSObject
	[BaseType (typeof(NSObject))]
	interface Mixpanel
	{
		// @property (readonly, atomic, strong) MixpanelPeople * _Nonnull people;
		[Export ("people", ArgumentSemantic.Strong)]
		MixpanelPeople People { get; }

		// @property (readonly, copy, atomic) NSString * _Nonnull distinctId;
		[Export ("distinctId")]
		string DistinctId { get; }

		// @property (copy, nonatomic) NSString * _Nonnull serverURL;
		[Export ("serverURL")]
		string ServerURL { get; set; }

		// @property (atomic) NSUInteger flushInterval;
		[Export ("flushInterval")]
		nuint FlushInterval { get; set; }

		// @property (atomic) BOOL flushOnBackground;
		[Export ("flushOnBackground")]
		bool FlushOnBackground { get; set; }

		// @property (atomic) BOOL shouldManageNetworkActivityIndicator;
		[Export ("shouldManageNetworkActivityIndicator")]
		bool ShouldManageNetworkActivityIndicator { get; set; }

		// @property (atomic) BOOL checkForSurveysOnActive;
		[Export ("checkForSurveysOnActive")]
		bool CheckForSurveysOnActive { get; set; }

		// @property (atomic) BOOL showSurveyOnActive;
		[Export ("showSurveyOnActive")]
		bool ShowSurveyOnActive { get; set; }

		// @property (readonly, atomic) BOOL isSurveyAvailable;
		[Export ("isSurveyAvailable")]
		bool IsSurveyAvailable { get; }

		// @property (readonly, atomic) NSArray<MPSurvey *> * _Nonnull availableSurveys;
		[Export ("availableSurveys")]
		NSObject[] AvailableSurveys { get; }

		// @property (atomic) BOOL checkForNotificationsOnActive;
		[Export ("checkForNotificationsOnActive")]
		bool CheckForNotificationsOnActive { get; set; }

		// @property (atomic) BOOL checkForVariantsOnActive;
		[Export ("checkForVariantsOnActive")]
		bool CheckForVariantsOnActive { get; set; }

		// @property (atomic) BOOL showNotificationOnActive;
		[Export ("showNotificationOnActive")]
		bool ShowNotificationOnActive { get; set; }

		// @property (atomic) BOOL useIPAddressForGeoLocation;
		[Export ("useIPAddressForGeoLocation")]
		bool UseIPAddressForGeoLocation { get; set; }

		// @property (atomic) BOOL enableVisualABTestAndCodeless;
		[Export ("enableVisualABTestAndCodeless")]
		bool EnableVisualABTestAndCodeless { get; set; }

		// @property (atomic) BOOL enableLogging;
		[Export ("enableLogging")]
		bool EnableLogging { get; set; }

		// @property (atomic) CGFloat miniNotificationPresentationTime;
		[Export ("miniNotificationPresentationTime")]
		nfloat MiniNotificationPresentationTime { get; set; }

		// @property (atomic, strong) UIColor * _Nullable miniNotificationBackgroundColor;
		[NullAllowed, Export ("miniNotificationBackgroundColor", ArgumentSemantic.Strong)]
		UIColor MiniNotificationBackgroundColor { get; set; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		MixpanelDelegate Delegate { get; set; }

		// @property (atomic, weak) id<MixpanelDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// +(Mixpanel * _Nonnull)sharedInstanceWithToken:(NSString * _Nonnull)apiToken;
		[Static]
		[Export ("sharedInstanceWithToken:")]
		Mixpanel SharedInstanceWithToken (string apiToken);

		// +(Mixpanel * _Nonnull)sharedInstanceWithToken:(NSString * _Nonnull)apiToken launchOptions:(NSDictionary * _Nullable)launchOptions;
		[Static]
		[Export ("sharedInstanceWithToken:launchOptions:")]
		Mixpanel SharedInstanceWithToken (string apiToken, [NullAllowed] NSDictionary launchOptions);

		// +(Mixpanel * _Nonnull)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		Mixpanel SharedInstance { get; }

		// -(instancetype _Nonnull)initWithToken:(NSString * _Nonnull)apiToken launchOptions:(NSDictionary * _Nullable)launchOptions andFlushInterval:(NSUInteger)flushInterval;
		[Export ("initWithToken:launchOptions:andFlushInterval:")]
		IntPtr Constructor (string apiToken, [NullAllowed] NSDictionary launchOptions, nuint flushInterval);

		// -(instancetype _Nonnull)initWithToken:(NSString * _Nonnull)apiToken andFlushInterval:(NSUInteger)flushInterval;
		[Export ("initWithToken:andFlushInterval:")]
		IntPtr Constructor (string apiToken, nuint flushInterval);

		// -(void)identify:(NSString * _Nonnull)distinctId;
		[Export ("identify:")]
		void Identify (string distinctId);

		// -(void)track:(NSString * _Nonnull)event;
		[Export ("track:")]
		void Track (string @event);

		// -(void)track:(NSString * _Nonnull)event properties:(NSDictionary * _Nullable)properties;
		[Export ("track:properties:")]
		void Track (string @event, [NullAllowed] NSDictionary properties);

		// -(void)trackPushNotification:(NSDictionary * _Nonnull)userInfo;
		[Export ("trackPushNotification:")]
		void TrackPushNotification (NSDictionary userInfo);

		// -(void)registerSuperProperties:(NSDictionary * _Nonnull)properties;
		[Export ("registerSuperProperties:")]
		void RegisterSuperProperties (NSDictionary properties);

		// -(void)registerSuperPropertiesOnce:(NSDictionary * _Nonnull)properties;
		[Export ("registerSuperPropertiesOnce:")]
		void RegisterSuperPropertiesOnce (NSDictionary properties);

		// -(void)registerSuperPropertiesOnce:(NSDictionary * _Nonnull)properties defaultValue:(id _Nullable)defaultValue;
		[Export ("registerSuperPropertiesOnce:defaultValue:")]
		void RegisterSuperPropertiesOnce (NSDictionary properties, [NullAllowed] NSObject defaultValue);

		// -(void)unregisterSuperProperty:(NSString * _Nonnull)propertyName;
		[Export ("unregisterSuperProperty:")]
		void UnregisterSuperProperty (string propertyName);

		// -(void)clearSuperProperties;
		[Export ("clearSuperProperties")]
		void ClearSuperProperties ();

		// -(NSDictionary * _Nonnull)currentSuperProperties;
		[Export ("currentSuperProperties")]
		NSDictionary CurrentSuperProperties { get; }

		// -(void)timeEvent:(NSString * _Nonnull)event;
		[Export ("timeEvent:")]
		void TimeEvent (string @event);

		// -(void)clearTimedEvents;
		[Export ("clearTimedEvents")]
		void ClearTimedEvents ();

		// -(void)reset;
		[Export ("reset")]
		void Reset ();

		// -(void)flush;
		[Export ("flush")]
		void Flush ();

		// -(void)flushWithCompletion:(void (^ _Nullable)())handler;
		[Export ("flushWithCompletion:")]
		void FlushWithCompletion ([NullAllowed] Action handler);

		// -(void)archive;
		[Export ("archive")]
		void Archive ();

		// -(void)createAlias:(NSString * _Nonnull)alias forDistinctID:(NSString * _Nonnull)distinctID;
		[Export ("createAlias:forDistinctID:")]
		void CreateAlias (string alias, string distinctID);

		// +(NSString * _Nonnull)libVersion;
		[Static]
		[Export ("libVersion")]
		string LibVersion { get; }

		// -(void)showSurveyWithID:(NSUInteger)ID;
		[Export ("showSurveyWithID:")]
		void ShowSurveyWithID (nuint ID);

		// -(void)showSurvey;
		[Export ("showSurvey")]
		void ShowSurvey ();

		// -(void)showNotificationWithID:(NSUInteger)ID;
		[Export ("showNotificationWithID:")]
		void ShowNotificationWithID (nuint ID);

		// -(void)showNotificationWithType:(NSString * _Nonnull)type;
		[Export ("showNotificationWithType:")]
		void ShowNotificationWithType (string type);

		// -(void)showNotification;
		[Export ("showNotification")]
		void ShowNotification ();

		// -(void)joinExperiments;
		[Export ("joinExperiments")]
		void JoinExperiments ();

		// -(void)joinExperimentsWithCallback:(void (^ _Nullable)())experimentsLoadedCallback;
		[Export ("joinExperimentsWithCallback:")]
		void JoinExperimentsWithCallback ([NullAllowed] Action experimentsLoadedCallback);

		// @property (copy, atomic) NSString * _Nullable nameTag __attribute__((deprecated("")));
		[NullAllowed, Export ("nameTag")]
		string NameTag { get; set; }
	}

	// @protocol MixpanelDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MixpanelDelegate
	{
		// @optional -(BOOL)mixpanelWillFlush:(Mixpanel * _Nonnull)mixpanel;
		[Export ("mixpanelWillFlush:")]
		bool MixpanelWillFlush (Mixpanel mixpanel);
	}

    // @interface MPTweak : NSObject
    [BaseType (typeof(NSObject))]
    interface MPTweak
    {
        // -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name andEncoding:(NSString * _Nonnull)encoding;
        [Export ("initWithName:andEncoding:")]
        IntPtr Constructor (string name, string encoding);

        // @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Export ("name")]
        string Name { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull encoding;
        [Export ("encoding")]
        string Encoding { get; }

        // @property (readwrite, nonatomic, strong) MPTweakValue _Nonnull defaultValue;
        [Export ("defaultValue", ArgumentSemantic.Strong)]
        NSObject DefaultValue { get; set; }

        // @property (readwrite, nonatomic, strong) MPTweakValue _Nullable currentValue;
        [NullAllowed, Export ("currentValue", ArgumentSemantic.Strong)]
        NSObject CurrentValue { get; set; }

        // @property (readwrite, nonatomic, strong) MPTweakValue _Nonnull minimumValue;
        [Export ("minimumValue", ArgumentSemantic.Strong)]
        NSObject MinimumValue { get; set; }

        // @property (readwrite, nonatomic, strong) MPTweakValue _Nonnull maximumValue;
        [Export ("maximumValue", ArgumentSemantic.Strong)]
        NSObject MaximumValue { get; set; }

        // -(void)addObserver:(id<MPTweakObserver> _Nonnull)observer;
        [Export ("addObserver:")]
        void AddObserver (MPTweakObserver observer);

        // -(void)removeObserver:(id<MPTweakObserver> _Nonnull)observer;
        [Export ("removeObserver:")]
        void RemoveObserver (MPTweakObserver observer);
    }

    // @protocol MPTweakObserver <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface MPTweakObserver
    {
        // @required -(void)tweakDidChange:(MPTweak * _Nonnull)tweak;
        [Abstract]
        [Export ("tweakDidChange:")]
        void TweakDidChange (MPTweak tweak);
    }

    // @interface MPTweakStore : NSObject
    [BaseType (typeof(NSObject))]
    interface MPTweakStore
    {
        // +(instancetype)sharedInstance;
        [Static]
        [Export ("sharedInstance")]
        MPTweakStore SharedInstance ();

        // @property (readonly, copy, nonatomic) NSArray * tweaks;
        [Export ("tweaks", ArgumentSemantic.Copy)]
        MPTweak[] Tweaks { get; }

        // -(MPTweak *)tweakWithName:(NSString *)name;
        [Export ("tweakWithName:")]
        MPTweak TweakWithName (string name);

        // -(void)addTweak:(MPTweak *)tweak;
        [Export ("addTweak:")]
        void AddTweak (MPTweak tweak);

        // -(void)removeTweak:(MPTweak *)tweak;
        [Export ("removeTweak:")]
        void RemoveTweak (MPTweak tweak);

        // -(void)reset;
        [Export ("reset")]
        void Reset ();
    }
}
