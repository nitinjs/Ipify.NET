using System;
using System.Collections.Generic;
using System.Text;

namespace Ipify.Net
{
    public enum IpType
    {
        /// <summary>
        /// The api6.ipify.org is used for IPv6 request only. If you don't have an IPv6 address, the request will fail.
        /// </summary>
        IPv6,
        /// <summary>
        /// The api.ipify.org is used for IPv4 request only.
        /// </summary>
        IPv4,
        /// <summary>
        /// It will return either IPv4 or IPv6 IP
        /// </summary>
        Universal
    }
}
