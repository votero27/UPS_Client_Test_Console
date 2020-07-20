using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SecondClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsumeEventSync objsync = new ConsumeEventSync();
            objsync.GetAllEventData();
            objsync.PostEvent_data();
            
        }
       
      

    }
    public class ConsumeEventSync
    {
        public void GetAllEventData() //Get All Events Records  
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("https://localhost:44316/api/shippings"); //URI  
                Console.WriteLine(Environment.NewLine + result);
            }
        }
        public void PostEvent_data() //Adding Event  
        {
            using (var client = new WebClient())
            {
                Product objtb = new Product(); //Setting parameter to post  
                objtb.CustomerID = 1;
                objtb.PackageWeight = 8.7;
                objtb.PackageType = "Electronic";

                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result = client.UploadString("https://localhost:44316/api/shippings", JsonConvert.SerializeObject(objtb));
                Console.WriteLine(result);
            }
        }
        public class Product
        {
            private int customerID;
            private double packageWeight;
            private string packageType;

            public string PackageType
            {
                get { return packageType; }
                set { packageType = value; }
            }


            public double PackageWeight
            {
                get { return packageWeight; }
                set { packageWeight = value; }
            }


            public int CustomerID
            {
                get { return customerID; }
                set { customerID = value; }
            }

        }
    }
}
