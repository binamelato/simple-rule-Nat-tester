using Open.Nat;
using System.Net;

try
{
    var nat = new NatDiscoverer(); // Инициализация провайдера NAT
    var device = await nat.DiscoverDeviceAsync();  // Поиск устройства NAT

    if (device == null)
    {
        Console.WriteLine("Устройство NAT не найдено.");
        return;
    }

    // Получение внешнего IP-адреса
    var externalIp = await device.GetExternalIPAsync();
    Console.WriteLine("Внешний IP-адрес: " + externalIp);
    label2.Text = externalIp.ToString();

        await device.CreatePortMapAsync(new Mapping(Protocol.Udp, port, port, "Test Mapping"));
        Console.WriteLine("UDP порт " + port + " успешно перенаправлен через UPnP.");

}
catch (NatDeviceNotFoundException)
{
    Console.WriteLine("Устройство NAT не найдено.");
}
catch (MappingException ex)
{
    Console.WriteLine("Ошибка при создании порт-маппинга: " + ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("Ошибка: " + ex.Message);
}