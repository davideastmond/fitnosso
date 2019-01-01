using System;
using Foundation;
using UIKit;
namespace fitnosso
{
    //[Register("UserRegistrationResultProtocoll"), Model]
    public class UserRegistrationResultProtocol
    {
        public event RegistrationReceived OnReceivedRegistrationData;
        //public abstract void GotRegistrationResults(RegistrationReturnData data);
        // public abstract event ReceivedRegistrationEvents()
        public object psender;
        public RegistrationReturnData pData;
        public void RaiseEvent (object sender, RegistrationReturnData data)
        {
            psender = sender;
            pData = data;

            OnReceivedRegistrationData += UserRegistrationResultProtocol_OnReceivedRegistrationData;
            OnReceivedRegistrationData(psender, pData);
        }


        void UserRegistrationResultProtocol_OnReceivedRegistrationData(object sender, RegistrationReturnData data)
        {
            // Do nothing
        }

    }
    public struct RegistrationReturnData
    {
        public DateTime DateOfBirth;
        public string Name;
    }
}
