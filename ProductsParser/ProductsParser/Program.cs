using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ProductsParser
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> productList = new List<Product>();
            Product product = new Product();
            using (StreamReader sr = new StreamReader(@"X:\output.json"))
            {
                string temp = "";
                while (!sr.EndOfStream)
                {
                    temp = sr.ReadLine();
                    //var pos = temp.IndexOf("helpful");
                    //temp = temp.Remove(pos, 18);
                    var productObj = JsonConvert.DeserializeObject<Product>(temp);
                    productObj.ToConsole();
                    productList.Add(productObj);
                }
            }
        }
    }

    class Product
    {
        private string _reviewerID;
        private string _asin;
        private string _reviewerName;
        private string _helpful;
        private string _reviewText;
        private string _overall;
        private string _summary;
        private string _unixReviewTime;
        private string _reviewTime;

        public string ReviewerID { get => _reviewerID; set => _reviewerID = value; }
        public string Asin { get => _asin; set => _asin = value; }
        public string ReviewerName { get => _reviewerName; set => _reviewerName = value; }
        public string Helpful { get => _helpful; set => _helpful = value; }
        public string ReviewText { get => _reviewText; set => _reviewText = value; }
        public string Overall { get => _overall; set => _overall = value; }
        public string Summary { get => _summary; set => _summary = value; }
        public string UnixReviewTime { get => _unixReviewTime; set => _unixReviewTime = value; }
        public string ReviewTime { get => _reviewTime; set => _reviewTime = value; }

        public Product() { }

        public void ToConsole()
        {
            Console.WriteLine(string.Format("ReviewerID: {0} \n" +
                "Asin: {1}\n" +
                "ReviewerName: {2}\n" +
                "Helpful: {3}\n" +
                "ReviewText: {4}\n" +
                "Overall: {5}\n" +
                "Summary: {6}\n" +
                "UnixReviewTime: {7}\n" +
                "ReviewTime: {8}\n",
                ReviewerID, Asin, ReviewerName, Helpful, ReviewText,
                Overall, Summary, UnixReviewTime, ReviewTime
                ));
        }
    }
}
