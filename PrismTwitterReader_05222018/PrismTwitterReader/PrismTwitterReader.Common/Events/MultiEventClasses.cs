using Prism.Events;

namespace PrismTwitterReader.Common
{
    public class ModuleNavigationEvent : PubSubEvent<DestinationModuleType> { }

    public enum DestinationModuleType
    {
        LiveTweets,
        SavedTweets
    }

    public class SelectLiveUserEvent : PubSubEvent<UserModel> { }

    public class SelectSavedUserEvent : PubSubEvent<UserModel> { }
}
