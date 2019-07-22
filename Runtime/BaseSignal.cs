using System.Collections.Generic;

namespace Nebukam.Signals
{

    /// <summary>
    /// Publicly available generic signal interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseSignal<T>
    {
        void Add(T callback);
        void AddOnce(T callback);
        void Remove(T callback);
    }

    /// <summary>
    /// Generic base for signals
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseSignal<T>
    {

        internal bool _dispatching = false;

        internal List<T> _subscribers = new List<T>(10);
        internal List<T> _deprecated = null;
        internal HashSet<T> _once = new HashSet<T>();
        
        public void Add(T callback)
        {

            if (_subscribers.Contains(callback))
                return;

            _subscribers.Add(callback);

            if (_once.Contains(callback))
                _once.Remove(callback);
        }

        public void AddOnce(T callback)
        {

            if (_subscribers.Contains(callback))
                return;

            _subscribers.Add(callback);
            _once.Add(callback);
        }

        public void Remove(T callback)
        {
            if(_dispatching)
            {

                if (_deprecated == null)
                    _deprecated = new List<T>(5);

                _deprecated.Add(callback);

                return;
            }

            _subscribers.Remove(callback);
            _once.Remove(callback);
        }

        internal void PostDispatch()
        {

            if(_deprecated != null)
            {
                int c= _deprecated.Count;
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
        /// Flush all delegate from the stack
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
