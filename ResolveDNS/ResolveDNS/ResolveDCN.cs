using System;
using System.Net;

namespace ResolveDNS
{
    internal class ResolveDCN
    {
        IPAddress[] iPAddress;
        public IPAddress this[int ndex]
        {
            get
            {
                return iPAddress[ndex];
            }
        }
        internal void Resolve(string host)
        {
            IPHostEntry iPHost = Dns.GetHostByName(host);
            iPAddress = iPHost.AddressList;
        }
        internal int IpLength()
        {
            return iPAddress.Length;
        }
    }
}