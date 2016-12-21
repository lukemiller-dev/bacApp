using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uber;
using Uber.Models;
using System.Web;

namespace AlcoholApp.Services
{
    public class UberService
    { 
        public void UberRequest()
        {
            var client = new UberClient("bcOz4z-GbY3kIGEha6wWMfzbZDOCZNdB");

            //Uber Login

            string url = Common.FormatAuthorizeUrl(ResponseTypes.Code, "bcOz4z-GbY3kIGEha6wWMfzbZDOCZNdB", HttpUtility.UrlEncode("YOURCALLBACKURL"));

            //var tw 

             

            //return Redirect(url);

            //HttpR.Redirect(url,false);

            //Access Token Authentication

            //var auth = new AuthenticationClient();
            //await auth.WebServerAsync(_clientId, _clientSecret, _callbackUrl, code);

            //Initialize Client

            //client = new UberClient(TokenTypes.Access, auth.AccessToken);
        }
    }
}
