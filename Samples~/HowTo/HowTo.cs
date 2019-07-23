using UnityEngine;

namespace Nebukam.Signals.Samples
{

    #region Simple Signal

    public class SimpleSignal
    {
        /*
         * Setting up a simple signal :
         * 
         * The signal instance is hidden behind the protected keyword,
         * while the object expose a getter using the ISignal interface.
         * This is to keep Dispatch control internal, while only exposing
         * subscription management method to the outside, such as Add, AddOnce & Remove.
         */
        
        protected Signal m_signal = new Signal();
        public ISignal signal { get { return m_signal; } }

        public SimpleSignal()
        {

            //Objects can subscribe to a local signal by adding a callback:
            //Note that the subscriber signature must match the signal's delegate (thanks captain obvious).
            signal.Add(Callback);

            //Internal dispatch with arguments
            m_signal.Dispatch();

        }

        protected void Callback()
        {
            //This will be called whenever m_simpleSignal dispatches.
            Debug.Log("Callback was called !");
        }

    }

    #endregion

    #region Signal with arguments

    public class ArgumentSignal
    {
        /*
         * Setting up a signal with arguments:
         * 
         * The signal instance is hidden behind the protected keyword,
         * while the object expose a getter using the ISignal interface.
         * This is to keep Dispatch control internal, while only exposing
         * subscription management method to the outside, such as Add, AddOnce & Remove.
         */

        protected Signal<int, string> m_signal = new Signal<int, string>();
        public ISignal<int, string> signal { get { return m_signal; } }

        public ArgumentSignal()
        {

            //Objects can subscribe to a local signal by adding a callback:
            //Note that the subscriber signature must match the signal's delegate (thanks captain obvious).
            signal.Add(Callback);
            
            //Internal dispatch with arguments
            m_signal.Dispatch(777, "FOO");

        }

        protected void Callback(int arg1, string arg2)
        {
            //This will be called whenever m_simpleSignal dispatches.
            Debug.Log("Callback was called with the following values : arg1 = "+ arg1+ ", arg2 = "+arg2);
        }

    }

    #endregion

    #region SignalMap

    public class MapSignal
    {
        /*
         * Setting up a signal with arguments:
         * 
         * The signal instance is hidden behind the protected keyword,
         * while the object expose a getter using the ISignal interface.
         * This is to keep Dispatch control internal, while only exposing
         * subscription management method to the outside, such as Add, AddOnce & Remove.
         */
         
        protected SignalMap<string> m_signalMap = new SignalMap<string>();
        public ISignalMap<string> signalMap { get { return m_signalMap; } }

        const string ID_A = "A", ID_B = "B";

        public MapSignal()
        {
            
            //Note : you can use whatever type fits your needs in place of ID.
            //Objects can subscribe to a local signal by adding a callback with a specific ID
            signalMap.Add(ID_A, CallbackA);
            signalMap.Add(ID_A, SecondCallbackA);

            signalMap.Add(ID_B, CallbackB);

            //Internal dispatch
            Debug.Log("Dispatching with ID_A ...");
            m_signalMap.Dispatch(ID_A);

            Debug.Log("Dispatching with ID_B ...");
            m_signalMap.Dispatch(ID_B);

        }

        protected void CallbackA()
        {
            Debug.Log("Callback A was called.");
        }

        protected void SecondCallbackA()
        {
            Debug.Log("Second Callback A was called.");
        }

        protected void CallbackB()
        {
            Debug.Log("Callback B was called.");
        }

    }

    #endregion

}
