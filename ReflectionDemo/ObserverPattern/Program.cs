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
        List<Action<SecurityDoorState>> _observers = new List<Action<SecurityDoorState>>();
        
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
            for(int i = 0; i < this._observers.Count; i++)
            {
                this._observers[i].Invoke(this.currentState);
            }
            
        }
        public void Subscribe(Action<SecurityDoorState> observer) { this._observers.Add(observer); }
        public void UnSubcribe(Action<SecurityDoorState> observer) { this._observers.Remove(observer); }


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
            _door.Subscribe(owner_observer);
            _door.Subscribe(logger_observer);
            _door.Open();
            _door.Close();


        }
    }
}
