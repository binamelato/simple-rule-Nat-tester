using Open.Nat;
using System.Net;

try
{
    var nat = new NatDiscoverer();
    var device = await nat.DiscoverDeviceAsync();

    if (device == null)
    {
        Console.WriteLine("Устройство NAT не найдено.");
        return;
    }

    var mappings = await device.GetAllMappingsAsync();
    var portExists = mappings.Any(m => m.PublicPort == port);

    if (portExists)
    {
        Console.WriteLine("Порт "+port+" существует.");       
    }
    else
    {
        Console.WriteLine("Порт "+port+" не существует.");
    }
}
catch (NatDeviceNotFoundException)
{
    Console.WriteLine("Устройство NAT не найдено.");
}
catch (MappingException ex)
{
    Console.WriteLine("Ошибка при получении списка порт-маппингов: " + ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("Ошибка: " + ex.Message);
}