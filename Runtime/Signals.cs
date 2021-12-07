// Copyright (c) 2021 Timothé Lapetite - nebukam@gmail.com.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

namespace Nebukam.Signals
{

    public interface ISignal : IBaseSignal<SignalDelegates.Signal> { }
    public class Signal : BaseSignal<SignalDelegates.Signal>, ISignal
    {

        public Signal()
            : base()
        {

        }

        /// <summary>
        /// Dispatches signal, notifying all subscriber in order of subscription
        /// </summary>
        public void Dispatch()
        {
            _dispatching = true;
            int count = _subscribers.Count;
            for (int i = 0; i < count; i++) { _subscribers[i](); }
            PostDispatch();
        }

        /// <summary>
        /// Dispatches signal, notifying all subscriber in inverse order of subscription
        /// </summary>
        public void DispatchInverse()
        {
            _dispatching = true;
            int count = _subscribers.Count;
            for (int i = count - 1; i >= 0; i--) { _subscribers[i](); }
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

        /// <summary>
        /// Dispatches argument(s) to all listeners, in order of subscription
        /// </summary>
        /// <param name="arg"></param>
        public void Dispatch(T arg)
        {
            _dispatching = true;
            int count = _subscribers.Count;
            for (int i = 0; i < count; i++) { _subscribers[i](arg); }
            PostDispatch();
        }

        /// <summary>
        /// Dispatches argument(s) to all listeners, in inverse order of subscription
        /// </summary>
        /// <param name="arg"></param>
        public void DispatchInverse(T arg)
        {
            _dispatching = true;
            int count = _subscribers.Count;
            for (int i = count - 1; i >= 0; i--) { _subscribers[i](arg); }
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

        /// <summary>
        /// Dispatches argument(s) to all listeners, in order of subscription
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public void Dispatch(T1 arg1, T2 arg2)
        {
            _dispatching = true;
            int count = _subscribers.Count;
            for (int i = 0; i < count; i++) { _subscribers[i](arg1, arg2); }
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
            for (int i = count - 1; i >= 0; i--) { _subscribers[i](arg1, arg2); }
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

        /// <summary>
        /// Dispatches argument(s) to all listeners, in order of subscription
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        public void Dispatch(T1 arg1, T2 arg2, T3 arg3)
        {
            _dispatching = true;
            int count = _subscribers.Count;
            for (int i = 0; i < count; i++) { _subscribers[i](arg1, arg2, arg3); }
            PostDispatch();
        }

        /// <summary>
        /// Dispatches argument(s) to all listeners, in inverse order of subscription
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        public void DispatchInverse(T1 arg1, T2 arg2, T3 arg3)
        {
            _dispatching = true;
            int count = _subscribers.Count;
            for (int i = count - 1; i >= 0; i--) { _subscribers[i](arg1, arg2, arg3); }
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

        /// <summary>
        /// Dispatches argument(s) to all listeners, in order of subscription
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        public void Dispatch(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            _dispatching = true;
            int count = _subscribers.Count;
            for (int i = 0; i < count; i++) { _subscribers[i](arg1, arg2, arg3, arg4); }
            PostDispatch();
        }

        /// <summary>
        /// Dispatches argument(s) to all listeners, in inverse order of subscription
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        public void DispatchInverse(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            _dispatching = true;
            int count = _subscribers.Count;
            for (int i = count - 1; i >= 0; i--) { _subscribers[i](arg1, arg2, arg3, arg4); }
            PostDispatch();
        }

    }

}

