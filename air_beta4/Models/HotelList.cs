using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace air_beta4.Models
{
    public class HotelList
    {
        public string signature;
        public string marker = "74588";
        public string token = "60be4bd09411cd4664933bd759ba8963";
        public List<Hotel> list = new List<Hotel>();

        public string ConvertStringtoMD5(string strword)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(strword);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public HotelList(HotelRequest ht)
        {
            signature = token + ":" + marker + ":" + ht.adultsCount + ":" + ht.checkIn + ":" + ht.checkOut + ":" +
                ht.currency + ":" + ht.iata + ":" + ht.lang;
            signature = ConvertStringtoMD5(signature);

            string api = "http://engine.hotellook.com/api/v2/search/start.json?";
            api += "iata=" + ht.iata + "&checkIn=" + ht.checkIn + "&checkOut=" + ht.checkOut + "&adultsCount=" + ht.adultsCount + "&lang=" +
                ht.lang + "&currency=" + ht.currency + "&marker=" + marker + "&signature=" + signature;
            var request = new WebClient().DownloadString(api);
            HotelsRequestResult HRR = (HotelsRequestResult)JsonConvert.DeserializeObject(request, typeof(HotelsRequestResult));

            signature = token + ":" + marker + ":" + HRR.searchId + ":" + "price";
            signature = ConvertStringtoMD5(signature);
            api = "http://engine.hotellook.com/api/v2/search/getResult.json?searchId=" + HRR.searchId + "&sortBy=price&marker=" + marker +
                "&signature=" + signature;

            //var hotelListRequest = new WebClient().DownloadString(api);

            string hotelListRequest = "";

            bool flag = false;
            HotelResult res = new HotelResult();

            while (!flag)
            {
                using (var httpClient = new HttpClient())
                {
                    flag = true;
                    var response = httpClient.GetAsync(api).Result;
                    string result = response.Content.ReadAsStringAsync().Result;
                    hotelListRequest = result;
                    res = (HotelResult)JsonConvert.DeserializeObject(hotelListRequest, typeof(HotelResult));
                    if (res.errorCode == 4)
                    {
                        flag = false;
                        System.Threading.Thread.Sleep(500);
                    }
                }
            }

      
            //HotelResult res = (HotelResult)JsonConvert.DeserializeObject(hotelListRequest, typeof(HotelResult));
            list = res.result;
            list.Sort((x, y) => x.minPriceTotal.CompareTo(y.minPriceTotal));


        }
    }
}