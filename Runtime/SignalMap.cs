using System.Collections.Generic;

namespace Nebukam.Signals
{
    /// <summary>
    /// SignalMap dispatches events to multiple listeners.
    /// </summary>
    /// <typeparam name="IdType"></typeparam>
    /// <typeparam name="T"></typeparam>
    public interface IBaseSignalMap<IdType, T>
    {
        void Add(IdType id, T callback);
        void AddOnce(IdType id, T callback);
        void Remove(IdType id, T callback);
    }

    /// <summary>
    /// SignalMap dispatches events to multiple listeners.
    /// It allows to filter & organize subscribers based on a unique ID.
    /// It avoids the need for boilerplate code where 
    /// the same delegate signature would be used with numerous different signals
    /// covering the same purposes (i.e user interface code)
    /// </summary>
    /// <typeparam name="IdType"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TSignal"></typeparam>
    public abstract class BaseSignalMap<IdType, T, TSignal> : IBaseSignalMap<IdType,T>
        where TSignal : BaseSignal<T>, new()
    {

        protected List<TSignal> _signals = new List<TSignal>();
        protected Dictionary<IdType, TSignal> _signalMap = new Dictionary<IdType, TSignal>();

        /// <summary>
        /// Subscribe a listener for the signal.
        /// </summary>
        /// <param name="id">Signal ID</param>
        /// <param name="callback"></param>
        public void Add(IdType id, T callback)
        {
            GetOrCreateSignal(id).Add(callback);

        }

        /// <summary>
        /// Subscribe a listener for the signal, once.
        /// The listener will automatically unsubscribe after the next dispatch
        /// </summary>
        /// <param name="id">Signal ID</param>
        /// <param name="callback"></param>
        public void AddOnce(IdType id, T callback)
        {
            GetOrCreateSignal(id).AddOnce(callback);
        }

        internal TSignal GetOrCreateSignal(IdType id)
        {
            TSignal signal;
            if (!_signalMap.TryGetValue(id, out signal))
            {
                signal = new TSignal();
                _signalMap[id] = signal;
                _signals.Add(signal);
            }
            return signal;
        }

        /// <summary>
        /// Unscribe a listener from the signal
        /// </summary>
        /// <param name="id">Signal ID</param>
        /// <param name="callback"></param>
        public void Remove(IdType id, T callback)
        {

            TSignal signal;

            if (!_signalMap.TryGetValue(id, out signal))
                return;

            signal.Remove(callback);

        }

        /// <summary>
        /// Removes all subscriber for a given ID
        /// </summary>
        /// <param name="id">Signal ID</param>
        /// <param name="clear">Whether or not to keep a reference to the ID for later use</param>
        public void RemoveAll(IdType id, bool clear = false)
        {

            TSignal signal;

            if (!_signalMap.TryGetValue(id, out signal))
                return;

            if (clear)
            {
                signal.Clear();

                _signals.Remove(signal);
                _signalMap.Remove(id);
            }
            else
            {
                signal.RemoveAll();
            }
        }


        /// <summary>
        /// Removes all subscribers, for all IDs
        /// </summary>
        public void RemoveAll(bool clear = false)
        {
            if (clear)
            {

                int count = _signals.Count;
                for (int i = 0; i < count; i++)
                {
                    _signals[i].Clear();
                }

                _signalMap.Clear();
                _signals.Clear();
                
            }
            else
            {
                int count = _signals.Count;
                for(int i = 0; i < count; i++)
                {
                    _signals[i].RemoveAll();
                }
            }

        }

        public virtual void Clear()
        {
            RemoveAll();
        }

    }

    public interface ISignalMap<IdType> : IBaseSignalMap<IdType, SignalDelegates.Signal> { }
    public class SignalMap<IdType> : BaseSignalMap<IdType, SignalDelegates.Signal, Signal>, ISignalMap<IdType>
    {

        public void Dispatch(IdType id)
        {
            Signal signal;
            if (_signalMap.TryGetValue(id, out signal)) { signal.Dispatch(); }
        }

    }

    public interface ISignalMap<IdType, T> : IBaseSignalMap<IdType, SignalDelegates.Signal<T>> { }
    public class SignalMap<IdType, T> : BaseSignalMap<IdType, SignalDelegates.Signal<T>, Signal<T>>, ISignalMap<IdType, T>
    {
        public void Dispatch(IdType id, T arg)
        {
            Signal<T> signal;
            if (_signalMap.TryGetValue(id, out signal)) { signal.Dispatch(arg); }
        }
    }

    public interface ISignalMap<IdType, T1, T2> : IBaseSignalMap<IdType, SignalDelegates.Signal<T1, T2>> { }
    public class SignalMap<IdType, T1, T2> : BaseSignalMap<IdType, SignalDelegates.Signal<T1, T2>, Signal<T1, T2>>, ISignalMap<IdType, T1, T2>
    {

        public void Dispatch(IdType id, T1 arg1, T2 arg2)
        {
            Signal<T1, T2> signal;
            if (_signalMap.TryGetValue(id, out signal)) { signal.Dispatch(arg1, arg2); }
        }

    }

    public interface ISignalMap<IdType, T1, T2, T3> : IBaseSignalMap<IdType, SignalDelegates.Signal<T1, T2, T3>> { }
    public class SignalMap<IdType, T1, T2, T3> : BaseSignalMap<IdType, SignalDelegates.Signal<T1, T2, T3>, Signal<T1, T2, T3>>, ISignalMap<IdType, T1, T2, T3>
    {

        public void Dispatch(IdType id, T1 arg1, T2 arg2, T3 arg3)
        {
            Signal<T1, T2, T3> signal;
            if (_signalMap.TryGetValue(id, out signal)) { signal.Dispatch(arg1, arg2, arg3); }
        }

    }

    public interface ISignalMap<IdType, T1, T2, T3, T4> : IBaseSignalMap<IdType, SignalDelegates.Signal<T1, T2, T3, T4>> { }
    public class SignalMap<IdType, T1, T2, T3, T4> : BaseSignalMap<IdType, SignalDelegates.Signal<T1, T2, T3, T4>, Signal<T1, T2, T3, T4>>, ISignalMap<IdType, T1, T2, T3, T4>
    {

        public void Dispatch(IdType id, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            Signal<T1, T2, T3, T4> signal;
            if (_signalMap.TryGetValue(id, out signal)) { signal.Dispatch(arg1, arg2, arg3, arg4); }
        }

    }

}
