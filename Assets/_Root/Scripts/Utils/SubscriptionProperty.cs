using System;

namespace KitchenChaosMVC.Utils
{
    internal sealed class SubscriptionProperty<TValue> : ISubscriptionProperty<TValue>
    {
        private TValue _value;
        private Action<TValue> _onChangedValue;

        public TValue Value
        {
            get => _value;

            set
            {
                _value = value;
                _onChangedValue?.Invoke(_value);
            }
        }

        public void SubscribeOnChanged(Action<TValue> subcriptionAction)
        {
            _onChangedValue += subcriptionAction;
        }

        public void UnSubscribeOnChanged(Action<TValue> unsubcriptionAction)
        {
            _onChangedValue -= unsubcriptionAction;
        }
    }
}
