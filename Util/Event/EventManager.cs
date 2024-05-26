using Saga.Debug;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saga.Util.Event
{
    /// <summary>
    /// The EventManager manages links between specific event types and callback methods but does not include the transmission of data.
    /// </summary>
    /// <typeparam name="T">Must be either an <c>int</c> or <c>enum</c></typeparam>
    internal class EventManager<T> : BaseManager where T : struct, IComparable, IFormattable
    {
        private Dictionary<T, List<Action>> _listeners;

        public EventManager()
        {
            _listeners = new Dictionary<T, List<Action>>();
        }

        /// <summary>
        /// Links a specific method to a specific event
        /// </summary>
        /// <param name="eventType">The type of event</param>
        /// <param name="method">The method to be removed</param>
        public void AddEventListener(T eventType, Action method)
        {
            List<Action> list = null;
            if (!_listeners.TryGetValue(eventType, out list))
            {
                list = new List<Action>();
                _listeners.Add(eventType, list);
            }

            if (!list.Contains(method))
                list.Add(method);
            else
                Terminal.Warn("Attempted to add duplicate observer");
        }

        /// <summary>
        /// Removes the link between a method and an event. Throws an exception if the listener does not exist.
        /// </summary>
        /// <param name="eventType">The type of event</param>
        /// <param name="method">The method to be removed</param>
        public void RemoveEventListener(T eventType, Action method)
        {
            _listeners[eventType].Remove(method);
        }

        /// <summary>
        /// Emits the event specified
        /// </summary>
        /// <param name="eventType">The type of event</param>
        public void Emit(T eventType)
        {
            List<Action> list = null;
            if (_listeners.TryGetValue(eventType, out list))
            {
                for (var i = list.Count - 1; i >= 0; i--)
                    list[i]();
            }
        }

    }


    /// <summary>
    /// This EventManager manages links between specific event types and callback methods and includes the transmission of data.
    /// </summary>
    /// <typeparam name="T">Must be either an <c>int</c> or <c>enum</c></typeparam>
    internal class EventManager<T, U> : BaseManager where T : struct, IComparable, IFormattable
    {
        private Dictionary<T, List<Action<U>>> _listeners;

        public EventManager()
        {
            _listeners = new Dictionary<T, List<Action<U>>>();
        }

        /// <summary>
        /// Links a specific method to a specific event
        /// </summary>
        /// <param name="eventType">The type of event</param>
        /// <param name="method">The method to be removed</param>
        public void AddEventListener(T eventType, Action<U> method)
        {
            List<Action<U>> list = null;
            if (!_listeners.TryGetValue(eventType, out list))
            {
                list = new List<Action<U>>();
                _listeners.Add(eventType, list);
            }

            if (!list.Contains(method))
                list.Add(method);
            else
                Terminal.Warn("Attempted to add duplicate observer");
        }

        /// <summary>
        /// Removes the link between a method and an event. Throws an exception if the listener does not exist.
        /// </summary>
        /// <param name="eventType">The type of event</param>
        /// <param name="method">The method to be removed</param>
        public void RemoveEventListener(T eventType, Action<U> method)
        {
            _listeners[eventType].Remove(method);
        }

        /// <summary>
        /// Emits the event specified
        /// </summary>
        /// <param name="eventType">The type of event</param>
        /// <param name="data">Data to be included in transmission</param>
        public void Emit(T eventType, U data)
        {
            List<Action<U>> list = null;
            if (_listeners.TryGetValue(eventType, out list))
            {
                for (var i = list.Count - 1; i >= 0; i--)
                    list[i](data);
            }
        }

    }
}
