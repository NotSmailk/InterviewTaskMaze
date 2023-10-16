using Assets.Source.Scripts.Signals;
using Assets.Source.Scripts.Utils;
using System;
using System.Collections.Generic;

namespace Assets.Source.Scripts
{
    public class EventBus : BaseSingleton<EventBus>
    {
        private Dictionary<Type, List<object>> _events;

        public EventBus()
        {
            _events = new();
        }

        public void Subscribe<T>(Action<T> action) where T : ISignal
        {
            var type = typeof(T);
            if (_events.ContainsKey(type))
            {
                _events[type].Add(action);
                return;
            }

            _events.Add(type, new List<object>() { action });
        }

        public void UnSubscribe<T>(Action<T> action) where T : ISignal
        {
            var type = typeof(T);
            if (_events.ContainsKey(type))
            {
                _events[type].Remove(action);
                return;
            }

            throw new KeyNotFoundException();
        }

        public void Invoke<T>(T signal) where T : ISignal
        {
            var type = typeof(T);
            if (_events.ContainsKey(type))
            {
                foreach (var obj in _events[type])
                {
                    var evnt = obj as Action<T>;
                    evnt?.Invoke(signal);
                }
            }
        }
    }
}
