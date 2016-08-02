using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GetLocalIP
{
    class Program
    {
        static void Main(string[] args)
        {
            var Today = DateTime.Today.ToString("yyyy-MM-dd");
            var LogPath = @"D:\WorkSchedule\" + Today + ".txt";

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                var Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                try
                {
                    var LogData = string.Concat("Record Time: ", Time, ". Alive Local IP: ", ip.ToString(), "\r\n");
                    File.AppendAllText(LogPath, LogData);
                }
                catch (Exception E)
                {
                    File.AppendAllText(LogPath, E.ToString());
                }
                Console.WriteLine(ip.AddressFamily.ToString());
                Console.WriteLine(ip.ToString());
            }
            Console.ReadLine();
        }
    }
}
