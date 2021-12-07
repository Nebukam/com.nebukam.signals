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
