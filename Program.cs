using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

public class Program
{

    //////https://21303.live.streamtheworld.com/METRO_FM_SC
    public static void Main()
    {
        //Creates the Socket for sending data over TCP.


        using var client = new TcpClient();

        var hostname = "21303.live.streamtheworld.com";
        client.Connect(hostname, 443);
        using NetworkStream networkStream = client.GetStream();
        networkStream.ReadTimeout = 2000;

        var message = "\nHost: 21303.live.streamtheworld.com\r\n\n\r\n";

        Console.WriteLine(message);

        using var reader = new StreamReader(networkStream, Encoding.UTF8);

        byte[] bytes = Encoding.UTF8.GetBytes(message);
        networkStream.Write(bytes, 0, bytes.Length);
        

        Console.WriteLine(reader.ReadToEnd());

    }

}
