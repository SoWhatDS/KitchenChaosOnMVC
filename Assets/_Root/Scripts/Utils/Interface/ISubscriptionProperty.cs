using System;

namespace KitchenChaosMVC.Utils
{
    internal interface ISubscriptionProperty<out TValue>
    {
        TValue Value { get; }

        void SubscribeOnChanged(Action<TValue> subscriptionAction);

        void UnSubscribeOnChanged(Action<TValue> unsubscriptionAction);
    }
}
