// Copyright (c) 2019 Timothé Lapetite - nebukam@gmail.com.
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
        /// Whether this signal has at least one suscriber
        /// </summary>
        bool hasSuscribers { get; }

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
        /// Whether this signal has at least one suscriber
        /// </summary>
        public bool hasSuscribers { get { return _subscribers.Count > 0; } }

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
