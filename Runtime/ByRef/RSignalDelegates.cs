namespace Nebukam.Signals
{

    /// <summary>
    /// Delegate used by signal to store callbacks by ref
    /// </summary>
    public static class RSignalDelegates
    {

        /// <summary>
        /// Delegate for one-argument callbacks
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arg"></param>
        public delegate void Signal<T>(ref T arg);

        /// <summary>
        /// Delegate for two-arguments callbacks
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public delegate void Signal<T1, T2>(ref T1 arg1, ref T2 arg2);

        /// <summary>
        /// Delegate for three-arguments callbacks
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        public delegate void Signal<T1, T2, T3>(ref T1 arg1, ref T2 arg2, ref T3 arg3);

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
        public delegate void Signal<T1, T2, T3, T4>(ref T1 arg1, ref T2 arg2, ref T3 arg3, ref T4 arg4);

    }

}

