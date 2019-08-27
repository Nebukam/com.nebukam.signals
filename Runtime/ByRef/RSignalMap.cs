namespace Nebukam.Signals
{

    public interface IRSignalMap<IdType, T> : IBaseSignalMap<IdType, RSignalDelegates.Signal<T>> { }
    public class RSignalMap<IdType, T> : BaseSignalMap<IdType, RSignalDelegates.Signal<T>, RSignal<T>>, IRSignalMap<IdType, T>
    {
        public void Dispatch(IdType id, ref T arg)
        {
            RSignal<T> signal;
            if (_signalMap.TryGetValue(id, out signal)) { signal.Dispatch(ref arg); }
        }
    }

    public interface IRSignalMap<IdType, T1, T2> : IBaseSignalMap<IdType, RSignalDelegates.Signal<T1, T2>> { }
    public class RSignalMap<IdType, T1, T2> : BaseSignalMap<IdType, RSignalDelegates.Signal<T1, T2>, RSignal<T1, T2>>, IRSignalMap<IdType, T1, T2>
    {

        public void Dispatch(IdType id, ref T1 arg1, ref T2 arg2)
        {
            RSignal<T1, T2> signal;
            if (_signalMap.TryGetValue(id, out signal)) { signal.Dispatch(ref arg1, ref arg2); }
        }

    }

    public interface IRSignalMap<IdType, T1, T2, T3> : IBaseSignalMap<IdType, RSignalDelegates.Signal<T1, T2, T3>> { }
    public class RSignalMap<IdType, T1, T2, T3> : BaseSignalMap<IdType, RSignalDelegates.Signal<T1, T2, T3>, RSignal<T1, T2, T3>>, IRSignalMap<IdType, T1, T2, T3>
    {

        public void Dispatch(IdType id, ref T1 arg1, ref T2 arg2, ref T3 arg3)
        {
            RSignal<T1, T2, T3> signal;
            if (_signalMap.TryGetValue(id, out signal)) { signal.Dispatch(ref arg1, ref arg2, ref arg3); }
        }

    }

    public interface IRSignalMap<IdType, T1, T2, T3, T4> : IBaseSignalMap<IdType, RSignalDelegates.Signal<T1, T2, T3, T4>> { }
    public class RSignalMap<IdType, T1, T2, T3, T4> : BaseSignalMap<IdType, RSignalDelegates.Signal<T1, T2, T3, T4>, RSignal<T1, T2, T3, T4>>, IRSignalMap<IdType, T1, T2, T3, T4>
    {

        public void Dispatch(IdType id, ref T1 arg1, ref T2 arg2, ref T3 arg3, ref T4 arg4)
        {
            RSignal<T1, T2, T3, T4> signal;
            if (_signalMap.TryGetValue(id, out signal)) { signal.Dispatch(ref arg1, ref arg2, ref arg3, ref arg4); }
        }

    }

}
