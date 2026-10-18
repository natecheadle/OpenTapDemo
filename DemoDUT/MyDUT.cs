using System;
using OpenTap;

namespace Demo;

[Display("MyDUT", Description: "Insert a description here", Group: "DemoDUT")]
public class MyDUT : Dut
{
    #region Settings
    public DemoPowerSupply? PowerSupply { get; set; }
    public string SerialNumber { get; set; } = "12345-6789";

    #endregion

    /// <summary>
    /// Initializes a new instance of this DUT class.
    /// </summary>
    public MyDUT()
    {
        // ToDo: Set default values for properties / settings.
        Name = nameof(MyDUT);
    }

    /// <summary>
    /// Opens a connection to the DUT represented by this class
    /// </summary>
    public override void Open()
    {
        base.Open();
        if (PowerSupply is null)
            throw new NullReferenceException($"{nameof(PowerSupply)} is null");

        PowerSupply.SetOutputVoltage(10);
        PowerSupply.EnableOutput();

        Log.Info($"Hello from {SerialNumber}");
        // TODO: establish connection to DUT here
    }

    /// <summary>
    /// Closes the connection made to the DUT represented by this class
    /// </summary>
    public override void Close()
    {
        // TODO: close connection to DUT
        base.Close();
        Log.Info($"Goodbye from {SerialNumber}");

        PowerSupply?.DisableOutput();
    }
}
