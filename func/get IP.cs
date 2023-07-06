using System.Net;

static string getIp()
{
    string externalIpString = new WebClient().DownloadString("http://icanhazip.com").Replace("\\r\\n", "").Replace("\\n", "").Trim();
    var externalIp = IPAddress.Parse(externalIpString);
    ServerIpClient = externalIp.ToString();
    Console.WriteLine($" IP " + ServerIpClient);
    return ServerIpClient;
}