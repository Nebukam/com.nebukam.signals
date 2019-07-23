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
    
}

