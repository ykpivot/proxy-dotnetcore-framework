using System;
using System.Net.Http;

namespace ProxyTesterNetCore.Factories
{
    public class HttpProxyClientFactory
    {
        public string ProxyAddress { get; }
        public string ByPassProxyAddresses { get; }
        public HttpProxyClientFactory(string proxyAddress, string byPassProxyAddresses)
        {
            ProxyAddress = proxyAddress;
            ByPassProxyAddresses = byPassProxyAddresses;
        }
        public HttpClient Create()
        {
            var webProxy = new System.Net.WebProxy(ProxyAddress);

            webProxy.BypassArrayList.AddRange(ByPassProxyAddresses.Split(','));
            webProxy.BypassProxyOnLocal = true;

            var httpClientHandler = new HttpClientHandler()
            {
                Proxy = webProxy,
            };
            
            return new HttpClient(handler: httpClientHandler, disposeHandler: true); ;
        }
    }
}
