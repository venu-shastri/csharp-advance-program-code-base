using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    //Observer
    public class HouseOwner
    {
        public void Notify(SecurityDoorState state)
        {
            Console.WriteLine($"House Owner Received Door State {state}, {DateTime.Now.ToString()} ");

        }

    }
    //Observer
    public class LogWriter
    {
        public void Write(SecurityDoorState state)
        {
            Console.WriteLine($"Logging Door Sttae {state}, {DateTime.Now.ToString()} ");
        }
    }
    public enum SecurityDoorState
    {
        OPEN,CLOSE

    }
    public class SecurityDoor
    {

        SecurityDoorState currentState;
       
       public event Action<SecurityDoorState> StateChanged;
        //MSIL
        //private Action<SecurityDoorState> StateChanged;
        //public event property StateChanged { .add(+=) , .remove(-=}
        //public void add_StateChanged(Action<SecurityDoorState> observer)
        //public void remove_StateChanged(Action<SecurityDoorState> observer)

        public void Open()
        {
            this.currentState = SecurityDoorState.OPEN;
            onDoorStateChanged();

        }
        public void Close()
        {
            this.currentState = SecurityDoorState.CLOSE;
            onDoorStateChanged();
        }
        void onDoorStateChanged()
        {
            this.StateChanged.Invoke(this.currentState);//MultiCasting
            
        }
       


    }
    class Program
    {
        static void Main(string[] args)
        {
            HouseOwner _owner = new HouseOwner();
            LogWriter _logWriter = new LogWriter();

            Action<SecurityDoorState> owner_observer = new Action<SecurityDoorState>(_owner.Notify);
            Action<SecurityDoorState> logger_observer = new Action<SecurityDoorState>(_logWriter.Write);

            SecurityDoor _door = new SecurityDoor();
            _door.StateChanged += owner_observer;// add_StateChanged(owner_observer);
            _door.StateChanged += logger_observer;//add_StateChanged(logger_observer);
            _door.Open();
            _door.Close();


        }
    }
}
