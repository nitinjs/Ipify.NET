/*
    Copyright © 2015 David Musgrove.
    Licensed under the terms of the MIT License.
*/

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ipify.Net
{
    /// <summary>
    /// Static utility class exposing methods to facilitate resolving a client's
    /// public IP address on the Internet by querying the service at ipify.org.
    /// </summary>
    public static class Ipify
    {
        /// <summary>
        /// Resolves the public IP address and returns it as a string.
        /// </summary>
        /// <param name="iptype">Type of IP: IPv6 or IPv4 or Universal</param>
        /// <param name="responseType">Type of response: text, json or jsonp</param>
        /// <param name="useHttps">Whether to use https when calling ipify API</param>
        /// <param name="jsonpCallback">jsonp callback function in case of jsonp reponse type</param>
        /// <returns></returns>
        public async static Task<string> GetPublicAddress(IpType iptype = IpType.IPv4, ResponseType responseType = ResponseType.Text, bool useHttps = false, string jsonpCallback = "")
        {
            string subdomain = string.Empty;
            switch (iptype)
            {
                case IpType.Universal:
                    subdomain = "api64";
                    break;
                case IpType.IPv4:
                    subdomain = "api";
                    break;
                case IpType.IPv6:
                    subdomain = "api6";
                    break;
            }
            var endpointURL = (useHttps ? "https://" : "http://") + $"{subdomain}.ipify.org/";
            switch (responseType)
            {
                case ResponseType.Jsonp:
                    endpointURL += "format=jsonp" + (string.IsNullOrWhiteSpace(jsonpCallback) ? "&callback=callback" : "");
                    break;
                case ResponseType.Json:
                    endpointURL += "format=json";
                    break;
            }
            var endpoint = useHttps ? "https://api.ipify.org" : "http://api.ipify.org";
            HttpClient client = new HttpClient();
            try
            {
                return await client.GetStringAsync(endpoint);
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Resolves the public IP address and returns it as an instance of
        /// <see cref="IPAddress" />.
        /// </summary>
        /// <param name="iptype">Type of IP: IPv6 or IPv4 or Universal</param>
        /// <param name="responseType">Type of response: text, json or jsonp</param>
        /// <param name="useHttps">Whether to use https when calling ipify API</param>
        /// <param name="jsonpCallback">jsonp callback function in case of jsonp reponse type</param>
        /// <returns>
        /// An instance of <see cref="IPAddress" />. If an error occures, then
        /// <see cref="IPAddress.None" /> is returned.
        /// encountered.
        /// </returns>
        public async static Task<IPAddress> GetPublicIPAddress(IpType iptype = IpType.IPv4, ResponseType responseType = ResponseType.Text, bool useHttps = false, string jsonpCallback = "")
        {
            string address = await GetPublicAddress(iptype, responseType, useHttps, jsonpCallback);
            IPAddress ipAddress;
            if (!IPAddress.TryParse(address, out ipAddress))
            {
                return IPAddress.None;
            }
            return ipAddress;
        }
    }
}