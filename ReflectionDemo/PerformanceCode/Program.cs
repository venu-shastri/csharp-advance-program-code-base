using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] content = { "a", "b", "c", "d", "e", "f", "g", "h" };
           
            List<string> _encryptedContent = new List<string>();
            System.Diagnostics.Stopwatch _stopWatch = new System.Diagnostics.Stopwatch();
            _stopWatch.Start();
            for(int i = 0; i < content.Length; i++)
            {
               _encryptedContent.Add( Encrypt(content[i]));
            }
            _stopWatch.Stop();
            Console.WriteLine(_stopWatch.ElapsedMilliseconds);
            for(int i = 0; i < _encryptedContent.Count; i++)
            {
                Console.WriteLine(_encryptedContent[i]);
            }


        }
        static string Encrypt(string item)
        {
            System.Threading.Thread.Sleep(1000);
            return item.ToUpper();
        }
    }
}
