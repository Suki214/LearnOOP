using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace ResolveDNS
{
    class ResolveDNS
    {
        IPAddress[] m_arrayIPs;

        public void Resolve(string s_host)
        {
            IPHostEntry ip = Dns.GetHostByName(s_host);
            m_arrayIPs = ip.AddressList;
        }

        public IPAddress this[int nIndex]
        {
            get
            {
                return m_arrayIPs[nIndex];
            }
        }

        public int IPLength
        {
            get
            {
                return m_arrayIPs.Length;

            }
        }
    }
}
