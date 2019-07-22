using System.Collections.Generic;

namespace Nebukam.Signals
{

    public interface IBaseSignalMap<IdType, T>
    {
        void Add(IdType id, T callback);
        void AddOnce(IdType id, T callback);
        void Remove(IdType id, T callback);
    }

    public abstract class BaseSignalMap<IdType, T, TSignal> : IBaseSignalMap<IdType,T>
        where TSignal : BaseSignal<T>, new()
    {

        protected List<TSignal> _signals = new List<TSignal>();
        protected Dictionary<IdType, TSignal> _signalMap = new Dictionary<IdType, TSignal>();

        public void Add(IdType id, T callback)
        {
            TSignal signal;

            if (!_signalMap.TryGetValue(id, out signal))
            {
                signal = new TSignal();
                _signalMap[id] = signal;
                _signals.Add(signal);
            }

            signal.Add(callback);

        }

        public void AddOnce(IdType id, T callback)
        {
            TSignal signal;

            if (!_signalMap.TryGetValue(id, out signal))
            {
                signal = new TSignal();
                _signalMap[id] = signal;
                _signals.Add(signal);
            }

            signal.AddOnce(callback);

        }

        public void Remove(IdType id, T callback)
        {

            TSignal signal;

            if (!_signalMap.TryGetValue(id, out signal))
                return;

            signal.Remove(callback);

        }

        public void RemoveAll(IdType id)
        {

            TSignal signal;

            if (!_signalMap.TryGetValue(id, out signal))
                return;

            signal.Clear();

            _signals.Remove(signal);
            _signalMap.Remove(id);

        }

        public void RemoveAll()
        {

            _signalMap.Clear();

            TSignal signal;
            while (_signals.Count != 0)
            {
                signal = _signals[_signals.Count - 1];
                signal.Clear();
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

            if (!_signalMap.TryGetValue(id, out signal))
                return;

            signal.Dispatch();

        }

    }

    public interface ISignalMap<IdType, T> : IBaseSignalMap<IdType, SignalDelegates.Signal<T>> { }
    public class SignalMap<IdType, T> : BaseSignalMap<IdType, SignalDelegates.Signal<T>, Signal<T>>, ISignalMap<IdType, T>
    {

        public void Dispatch(IdType id, T arg)
        {

            Signal<T> signal;

            if (!_signalMap.TryGetValue(id, out signal))
                return;

            signal.Dispatch(arg);

        }

    }

    public interface ISignalMap<IdType, T1, T2> : IBaseSignalMap<IdType, SignalDelegates.Signal<T1, T2>> { }
    public class SignalMap<IdType, T1, T2> : BaseSignalMap<IdType, SignalDelegates.Signal<T1, T2>, Signal<T1, T2>>, ISignalMap<IdType, T1, T2>
    {

        public void Dispatch(IdType id, T1 arg1, T2 arg2)
        {

            Signal<T1, T2> signal;

            if (!_signalMap.TryGetValue(id, out signal))
                return;

            signal.Dispatch(arg1, arg2);

        }

    }

    public interface ISignalMap<IdType, T1, T2, T3> : IBaseSignalMap<IdType, SignalDelegates.Signal<T1, T2, T3>> { }
    public class SignalMap<IdType, T1, T2, T3> : BaseSignalMap<IdType, SignalDelegates.Signal<T1, T2, T3>, Signal<T1, T2, T3>>, ISignalMap<IdType, T1, T2, T3>
    {

        public void Dispatch(IdType id, T1 arg1, T2 arg2, T3 arg3)
        {

            Signal<T1, T2, T3> signal;

            if (!_signalMap.TryGetValue(id, out signal))
                return;

            signal.Dispatch(arg1, arg2, arg3);

        }

    }

    public interface ISignalMap<IdType, T1, T2, T3, T4> : IBaseSignalMap<IdType, SignalDelegates.Signal<T1, T2, T3, T4>> { }
    public class SignalMap<IdType, T1, T2, T3, T4> : BaseSignalMap<IdType, SignalDelegates.Signal<T1, T2, T3, T4>, Signal<T1, T2, T3, T4>>, ISignalMap<IdType, T1, T2, T3, T4>
    {

        public void Dispatch(IdType id, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {

            Signal<T1, T2, T3, T4> signal;

            if (!_signalMap.TryGetValue(id, out signal))
                return;

            signal.Dispatch(arg1, arg2, arg3, arg4);

        }

    }

}
