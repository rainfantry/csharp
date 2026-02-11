using System;
using System.Net.Sockets;

class Program
{
    static bool ScanPort(string target, int port)
    {
        try
        {
            TcpClient client = new TcpClient();
            client.Connect(target, port);
            client.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }

    static void Main(string[] args)
    {
        string target = "192.168.1.64";
        int[] ports = { 21, 22, 23, 80, 443, 3306, 8080 };
        Console.WriteLine($"[*] Scanning {target} for open ports...\n");
        for (int i = 0; i < ports.Length; i++)
        {
            bool isOpen = ScanPort(target, ports[i]);
            if (isOpen)
                Console.WriteLine($"[+] Port {ports[i],-6} is open.");
            else
                Console.WriteLine($"[-] Port {ports[i],-6} is closed.");
        }
    }
}
