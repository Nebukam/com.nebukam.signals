using System;
using System.Collections.Generic;

namespace Nebukam.Signals
{
    
    public interface IRSignal<T> : IBaseSignal<RSignalDelegates.Signal<T>> { }
    public class RSignal<T> : BaseSignal<RSignalDelegates.Signal<T>>, IRSignal<T>
    {

        public RSignal()
            : base()
        {

        }

        /// <summary>
        /// Dispatches argument(s) to all listeners, in order of subscription
        /// </summary>
        /// <param name="arg"></param>
        public void Dispatch(ref T arg)
        {
            _dispatching = true;
            int count = _subscribers.Count;
            for (int i = 0; i < count; i++) { _subscribers[i](ref arg); }
            PostDispatch();
        }

        /// <summary>
        /// Dispatches argument(s) to all listeners, in inverse order of subscription
        /// </summary>
        /// <param name="arg"></param>
        public void DispatchInverse(ref T arg)
        {
            _dispatching = true;
            int count = _subscribers.Count;
            for (int i = count - 1; i >= 0; i--) { _subscribers[i](ref arg); }
            PostDispatch();
        }

    }

    public interface IRSignal<T1, T2> : IBaseSignal<RSignalDelegates.Signal<T1, T2>> { }
    public class RSignal<T1, T2> : BaseSignal<RSignalDelegates.Signal<T1, T2>>, IRSignal<T1, T2> 
    {

        public RSignal()
            : base()
        {

        }

        /// <summary>
        /// Dispatches argument(s) to all listeners, in order of subscription
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public void Dispatch(ref T1 arg1, ref T2 arg2)
        {
            _dispatching = true;
            int count = _subscribers.Count;
            for (int i = 0; i < count; i++) { _subscribers[i](ref arg1, ref arg2); }
            PostDispatch();
        }

        /// <summary>
        /// Dispatches argument(s) to all listeners, in inverse order of subscription
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public void DispatchInverse(T1 arg1, T2 arg2)
        {
            _dispatching = true;
            int count = _subscribers.Count;
            for (int i = count - 1; i >= 0; i--) { _subscribers[i](ref arg1, ref arg2); }
            PostDispatch();
        }

    }

    public interface IRSignal<T1, T2, T3> : IBaseSignal<RSignalDelegates.Signal<T1, T2, T3>> { }
    public class RSignal<T1, T2, T3> : BaseSignal<RSignalDelegates.Signal<T1, T2, T3>>, IRSignal<T1, T2, T3>
    {

        public RSignal()
            : base()
        {

        }

        /// <summary>
        /// Dispatches argument(s) to all listeners, in order of subscription
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        public void Dispatch(ref T1 arg1, ref T2 arg2, ref T3 arg3)
        {
            _dispatching = true;
            int count = _subscribers.Count;
            for (int i = 0; i < count; i++) { _subscribers[i](ref arg1, ref arg2, ref arg3); } //for (int i = count-1; i >= 0; i--)
            PostDispatch();
        }

        /// <summary>
        /// Dispatches argument(s) to all listeners, in inverse order of subscription
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        public void DispatchInverse(ref T1 arg1, ref T2 arg2, ref T3 arg3)
        {
            _dispatching = true;
            int count = _subscribers.Count;
            for (int i = count - 1; i >= 0; i--) { _subscribers[i](ref arg1, ref arg2, ref arg3); }
            PostDispatch();
        }

    }

    public interface IRSignal<T1, T2, T3, T4> : IBaseSignal<RSignalDelegates.Signal<T1, T2, T3, T4>> { }
    public class RSignal<T1, T2, T3, T4> : BaseSignal<RSignalDelegates.Signal<T1, T2, T3, T4>>, IRSignal<T1, T2, T3, T4>
    {

        public RSignal()
            : base()
        {

        }

        /// <summary>
        /// Dispatches argument(s) to all listeners, in order of subscription
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        public void Dispatch(ref T1 arg1, ref T2 arg2, ref T3 arg3, ref T4 arg4)
        {
            _dispatching = true;
            int count = _subscribers.Count;
            for (int i = 0; i < count; i++) { _subscribers[i](ref arg1, ref arg2, ref arg3, ref arg4); }
            PostDispatch();
        }

        /// <summary>
        /// Dispatches argument(s) to all listeners, in inverse order of subscription
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        public void DispatchInverse(ref T1 arg1, ref T2 arg2, ref T3 arg3, ref T4 arg4)
        {
            _dispatching = true;
            int count = _subscribers.Count;
            for (int i = count - 1; i >= 0; i--) { _subscribers[i](ref arg1, ref arg2, ref arg3, ref arg4); }
            PostDispatch();
        }

    }

}

