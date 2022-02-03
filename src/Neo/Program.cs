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

var plugs = await neo.GetNeoPlugs();

var tree = plugs["Tree"];

if (tree.IsOn)
{
    Console.Out.WriteLine(await tree.TurnOff());
}
else
{
    Console.Out.WriteLine(await tree.TurnOn());
}

// Live Data
var stats = await neo.GetNeoStats();
Console.Out.WriteLine();
Console.Out.WriteLine($"Thermostats");
Console.Out.WriteLine($"   Id Name                              Set Actual Heating");

foreach (NeoStat stat in from kv in stats where kv.Value.IsThermostat select kv.Value)
{
    string onOff = stat.IsOn ? "on" : "off";
    Console.Out.WriteLine($"{stat.DeviceId,5} {stat.Name,-30}{stat.SetTemperature,7:0.0}{stat.Temperature,7:0.0} {onOff}");
}

Console.Out.WriteLine();
Console.Out.WriteLine($"Timer Switches");
Console.Out.WriteLine($"   Id Name                                On/Off");
foreach (NeoStat stat in from kv in stats where kv.Value.IsTimerSwitch select kv.Value)
{
    string onOff = stat.IsOn ? "on" : "off";
    Console.Out.WriteLine($"{stat.DeviceId,5} {stat.Name,-30}      {onOff}");
}
