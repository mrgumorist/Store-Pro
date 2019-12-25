using Newtonsoft.Json;
using Store_Pro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Store_Pro.AdminPanel
{
    /// <summary>
    /// Interaction logic for Stores.xaml
    /// </summary>
    public partial class Stores : Page
    {
        const string host = @"http://localhost:50471";
        public Stores()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            const string WEBSERVICE_URL = host + @"/api/Apii/GetStores";
            
                var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 12000;
                    webRequest.ContentType = "application/json";
                    webRequest.Headers.Add("Authorization2", "Basic dchZ2VudDM6cGFdGVzC5zc3dvmQ=");
                    using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                        {
                            var jsonResponse = sr.ReadToEnd();
                            List<Store> response = JsonConvert.DeserializeObject<List<Store>>(jsonResponse) ;
                            Dataa.ItemsSource = response;
                        }
                    }
                }
           
        }
    }
}
