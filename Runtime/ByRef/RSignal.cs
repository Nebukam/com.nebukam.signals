// Copyright (c) 2019 Timoth� Lapetite - nebukam@gmail.com.
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

