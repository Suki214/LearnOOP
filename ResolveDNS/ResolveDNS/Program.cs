using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResolveDNS
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s_host = "www.163.com";
            
            //ResolveDNS resolver1 = new ResolveDNS();            
            //resolver1.Resolve(s_host);
            //int n = resolver1.IPLength;
            //Console.WriteLine("Get {1} IP Address of the host {0}",s_host,n);
            //Console.WriteLine();
            //for (int i = 0; i < n; i++)
            //    Console.WriteLine(resolver1[i]);



             string host = "www.163.com";
            ResolveDCN resolveDCN = new ResolveDCN();
        resolveDCN.Resolve(host);
            int m = resolveDCN.IpLength();
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine(resolveDCN[i]);
            }























            Console.ReadLine();
        }
    }
}
