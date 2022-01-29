using Heatmiser.NeoHubSDK;

NeoHubClient neo = new();

NeoHubInfo? info = await neo.GetHubInfo();
if (info != null)
{
    Console.Out.WriteLine($"Neo Hub \"{info.DeviceId}\" version {info.HubType} firmware version: {info.HubVersion}");
}
else
{
    Console.Error.Write("Cannot connect to Neo Hub.");
    return;
}

// Live Data
LiveData? liveData = await neo.GetLiveData();
if (liveData != null)
{
    Console.Out.WriteLine();
    Console.Out.WriteLine($"Thermostats");
    Console.Out.WriteLine($"   Id Name                              Set Actual Heating");

    foreach (LiveDeviceData d in from dv in liveData.Devices where dv.Thermostat select dv)
    {
        string onOff = d.HeatOn ? "on" : "off";
        Console.Out.WriteLine($"{d.DeviceId,5} {d.ZoneName,-30}{d.SetTemperature,7:0.0}{d.ActualTemp,7:0.0} {onOff}");
    }

    Console.Out.WriteLine();
    Console.Out.WriteLine($"Timer Switches");
    Console.Out.WriteLine($"   Id Name                                On/Off");
    foreach (LiveDeviceData d in from dv in liveData.Devices where !dv.Thermostat select dv)
    {
        string onOff = d.TimerOn ? "on" : "off";
        Console.Out.WriteLine($"{d.DeviceId,5} {d.ZoneName,-30}{"",5} {onOff}");
    }
}
