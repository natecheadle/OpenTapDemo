using OpenTap;

namespace Demo;

[Display("DemoPowerSupply")]
public class DemoPowerSupply : Instrument
{
    private double _outputVoltage;

    #region Settings

    [Unit("ms")]
    public int ConfigurableLatency { get; set; } = 10;

    public bool OutputOn { get; private set; }

    // ToDo: Add property here for each parameter the end user should be able to change
    #endregion
    public DemoPowerSupply()
    {
        Name = "DemoPowerSupply";
        // ToDo: Set default values for properties / settings.
    }

    public override void Open()
    {
        base.Open();
        // TODO:  Open the connection to the instrument here

        //if (!IdnString.Contains("Instrument ID"))
        //{
        //    Log.Error("This instrument driver does not support the connected instrument.");
        //    throw new ArgumentException("Wrong instrument type.");
        // }
    }

    public override void Close()
    {
        // TODO:  Shut down the connection to the instrument here.
        base.Close();
    }

    public void EnableOutput()
    {
        Latency();
        OutputOn = true;
        Log.Info("Power Supply Output On");
    }

    public void DisableOutput()
    {
        Latency();
        OutputOn = false;
        Log.Info("Power Supply Output Off");
    }

    public void SetOutputVoltage(double value)
    {
        Latency();
        _outputVoltage = value;
        Log.Info($"Power Supply Voltage Set to {value} V");
    }

    private void Latency() => TapThread.Sleep(ConfigurableLatency);
}
