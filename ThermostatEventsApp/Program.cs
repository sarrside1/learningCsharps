using System.ComponentModel;

namespace ThermostatEventsApp
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class HeatSensor : IHeatSensor
    {
        double _emergencyLevel = 0;
        double _warningLevel = 0;

        bool _hasReachedWarningTemperature = false;
        protected EventHandlerList _listEventHandlerList = new EventHandlerList();

        static readonly object _temperatureReachesWarningLevelKey = new object();
        static readonly object _temperatureFallsBelowWarningLevelKey = new object();
        static readonly object _temperatureReachesEmergencyLevelKey = new object();

        private double[] _temperatureData = null;

        public HeatSensor(double emergencyLevel, double warningLevel)
        {
            _emergencyLevel = emergencyLevel;
            _warningLevel = warningLevel;
            SeedData();
        }

        protected void OnTemperaturesReachesWarningLevel(TemperatureEventArgs eventArgs)
        {
            EventHandler<TemperatureEventArgs> handler = (EventHandler<TemperatureEventArgs>)_listEventHandlerList[_temperatureReachesWarningLevelKey];

            if(handler != null)
            {
                handler(this, eventArgs);
            }
        }

        protected void OnTemperaturesFallsBelowWarningLevel(TemperatureEventArgs eventArgs)
        {
            EventHandler<TemperatureEventArgs> handler = (EventHandler<TemperatureEventArgs>)_listEventHandlerList[_temperatureFallsBelowWarningLevelKey];

            if (handler != null)
            {
                handler(this, eventArgs);
            }
        }

        protected void OnTemperaturesReachesEmergencyLevel(TemperatureEventArgs eventArgs)
        {
            EventHandler<TemperatureEventArgs> handler = (EventHandler<TemperatureEventArgs>)_listEventHandlerList[_temperatureReachesEmergencyLevelKey];

            if (handler != null)
            {
                handler(this, eventArgs);
            }
        }

        private void SeedData()
        {
            _temperatureData = new double[] { 16, 17,16.5,18, 19, 22, 24, 26.75, 28.7, 27.6, 26, 24, 22, 45, 68, 86.45}
        }

        event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureReachedEmergencyLevelEventHandler
        {
            add
            {
                _listEventHandlerList.AddHandler(_temperatureReachesEmergencyLevelKey, value);
            }

            remove
            {
                _listEventHandlerList.RemoveHandler(_temperatureReachesEmergencyLevelKey, value);
            }
        }

        event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureReachedWarningLevelEventHandler
        {
            add
            {
                _listEventHandlerList.AddHandler(_temperatureReachesWarningLevelKey, value);
            }

            remove
            {
                _listEventHandlerList.AddHandler(_temperatureReachesWarningLevelKey, value);
            }
        }

        event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureFallsBelowWarningLevelEventHandler
        {
            add
            {
                _listEventHandlerList.AddHandler(_temperatureFallsBelowWarningLevelKey, value);
            }

            remove
            {
                _listEventHandlerList.AddHandler(_temperatureFallsBelowWarningLevelKey, value);
            }
        }

        public void RunHeatSensor()
        {
            throw new NotImplementedException();
        }
    }

    public interface IHeatSensor
    {
        event EventHandler<TemperatureEventArgs> TemperatureReachedEmergencyLevelEventHandler;
        event EventHandler<TemperatureEventArgs> TemperatureReachedWarningLevelEventHandler;
        event EventHandler<TemperatureEventArgs> TemperatureFallsBelowWarningLevelEventHandler;
        void RunHeatSensor();
    }

    public class TemperatureEventArgs: EventArgs
    {
        public double Temperature { get; set; }
        public DateTime CurrentDateTime { get; set; }
    }
}