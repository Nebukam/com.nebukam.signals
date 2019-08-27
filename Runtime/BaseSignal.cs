using System.Collections.Generic;

namespace Nebukam.Signals
{

    /// <summary>
    /// Signal dispatches events to multiple listeners.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remark>
    /// Signals interface should be exposed to the public as they offer safe subscription
    /// However, actual signal management (Dispatch & RemoveAll) is left enclosed at the object level
    /// in order to offer greater control over who can and cannot dispatch the signal.
    /// </remark>
    public interface IBaseSignal<T>
    {
        /// <summary>
        /// Subscribe a listener for the signal.
        /// </summary>
        /// <param name="callback"></param>
        void Add(T callback);

        /// <summary>
        /// Subscribe a listener for the signal, once.
        /// The listener will automatically unsubscribe after the next dispatch
        /// </summary>
        /// <param name="callback"></param>
        void AddOnce(T callback);

        /// <summary>
        /// Unscribe a listener from the signal
        /// </summary>
        /// <param name="callback"></param>
        void Remove(T callback);
    }

    /// <summary>
    /// Signal dispatches events to multiple listeners.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseSignal<T>
    {

        internal bool _dispatching = false;

        internal List<T> _subscribers = new List<T>(10);
        internal List<T> _deprecated = null;
        internal HashSet<T> _once = new HashSet<T>();

        /// <summary>
        /// Subscribe a listener for the signal.
        /// </summary>
        /// <param name="callback"></param>
        public void Add(T callback)
        {

            if (_subscribers.Contains(callback))
                return;

            _subscribers.Add(callback);

            if (_once.Contains(callback))
                _once.Remove(callback);
        }

        /// <summary>
        /// Subscribe a listener for the signal, once.
        /// The listener will automatically unsubscribe after the next dispatch
        /// </summary>
        /// <param name="callback"></param>
        public void AddOnce(T callback)
        {

            if (_subscribers.Contains(callback))
                return;

            _subscribers.Add(callback);
            _once.Add(callback);
        }

        /// <summary>
        /// Unscribe a listener from the signal
        /// </summary>
        /// <param name="callback"></param>
        public void Remove(T callback)
        {
            if (_dispatching)
            {

                if (_deprecated == null)
                    _deprecated = new List<T>(5);

                _deprecated.Add(callback);

                return;
            }

            _subscribers.Remove(callback);
            _once.Remove(callback);
        }

        /// <summary>
        /// Called by Dispatch method once they traversed the list of suscribers.
        /// Unsubscriptions that were left unapplied during dispatch 
        /// are processed by this methode, as well as removing all 'once' subscribers.
        /// </summary>
        internal void PostDispatch()
        {

            if (_deprecated != null)
            {
                int c = _deprecated.Count;
                T callback;

                for (int i = 0; i < c; i++)
                {
                    callback = _deprecated[i];
                    _subscribers.Remove(callback);
                    _once.Remove(callback);
                }

                _deprecated.Clear();
                _deprecated = null;
            }

            _dispatching = false;
        }

        /// <summary>
        /// Remove all subscribers
        /// </summary>
        public void RemoveAll()
        {
            _subscribers.Clear();
            _once.Clear();

            if (_deprecated != null)
            {
                _deprecated.Clear();
                _deprecated = null;
            }

        }

        public virtual void Clear()
        {
            RemoveAll();
        }

    }

}
