using System;
using System.Collections.Generic;

namespace Nebukam.Signals
{

    /// <summary>
    /// Delegate used by signal to store callbacks
    /// </summary>
    public static class SignalDelegates
    {

        /// <summary>
        /// Delegate for zero-argument callbacks
        /// </summary>
        public delegate void Signal();

        /// <summary>
        /// Delegate for one-argument callbacks
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arg"></param>
        public delegate void Signal<T>(T arg);

        /// <summary>
        /// Delegate for two-arguments callbacks
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public delegate void Signal<T1,T2>(T1 arg1, T2 arg2);

        /// <summary>
        /// Delegate for three-arguments callbacks
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        public delegate void Signal<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3);

        /// <summary>
        /// Delegate for four-arguments callbacks
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        public delegate void Signal<T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);

    }


    public interface ISignal : IBaseSignal<SignalDelegates.Signal> { }

	public class Signal : BaseSignal<SignalDelegates.Signal>, ISignal
	{

		public Signal ()
            :base()
		{

		}

        public void Dispatch()
		{

            _dispatching = true;

            int count = _subscribers.Count;
            for (int i = 0; i < count; i++) //for (int i = count-1; i >= 0; i--)
                _subscribers[i]();

            PostDispatch();

        }
        
    }

    public interface ISignal<T> : IBaseSignal<SignalDelegates.Signal<T>> { }
    public class Signal<T> : BaseSignal<SignalDelegates.Signal<T>>, ISignal<T>
    {

        public Signal()
            : base()
        {

        }

        public void Dispatch( T arg )
        {


            _dispatching = true;

            int count = _subscribers.Count;
            for (int i = 0; i < count; i++) //for (int i = count-1; i >= 0; i--)
                _subscribers[i](arg);

            PostDispatch();
            
        }

    }

    public interface ISignal<T1, T2> : IBaseSignal<SignalDelegates.Signal<T1, T2>> { }
    public class Signal<T1, T2> : BaseSignal<SignalDelegates.Signal<T1, T2>>, ISignal<T1, T2> 
    {

        public Signal()
            : base()
        {

        }

        public void Dispatch(T1 arg1, T2 arg2)
        {

            _dispatching = true;

            int count = _subscribers.Count;
            for (int i = 0; i < count; i++) //for (int i = count-1; i >= 0; i--)
                _subscribers[i](arg1, arg2);

            PostDispatch();

        }

    }

    public interface ISignal<T1, T2, T3> : IBaseSignal<SignalDelegates.Signal<T1, T2, T3>> { }
    public class Signal<T1, T2, T3> : BaseSignal<SignalDelegates.Signal<T1, T2, T3>>, ISignal<T1, T2, T3>
    {

        public Signal()
            : base()
        {

        }

        public void Dispatch(T1 arg1, T2 arg2, T3 arg3)
        {

            _dispatching = true;

            int count = _subscribers.Count;
            for (int i = 0; i < count; i++) //for (int i = count-1; i >= 0; i--)
                _subscribers[i](arg1, arg2, arg3);

            PostDispatch();

        }

    }

    public interface ISignal<T1, T2, T3, T4> : IBaseSignal<SignalDelegates.Signal<T1, T2, T3, T4>> { }
    public class Signal<T1, T2, T3, T4> : BaseSignal<SignalDelegates.Signal<T1, T2, T3, T4>>, ISignal<T1, T2, T3, T4>
    {

        public Signal()
            : base()
        {

        }

        public void Dispatch(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {

            _dispatching = true;

            int count = _subscribers.Count;
            for (int i = 0; i < count; i++) //for (int i = count-1; i >= 0; i--)
                _subscribers[i](arg1, arg2, arg3, arg4);

            PostDispatch();

        }

    }

}

