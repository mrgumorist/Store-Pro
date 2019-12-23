using Store_Pro.AdminPanel;
using Store_Pro.OwnerPanel;
using Store_Pro.SellerPanel;
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

namespace Store_Pro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string host = @"http://localhost:50471";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Зверніться будь ласка до адміністратора!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          
                 string WEBSERVICE_URL = host+@"/api/Apii/Login";
            try
            {
                var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 12000;
                    webRequest.ContentType = "application/json";
                    webRequest.Headers.Add("Authorization2", "Basic dchZ2VudDM6cGFdGVzC5zc3dvmQ=");
                    webRequest.Headers.Add("Username", login.Text);
                    webRequest.Headers.Add("Password", password.Password);
                    using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                        {
                            var jsonResponse = sr.ReadToEnd();
                            if (jsonResponse == @"""Succesfull""")
                            {
                                MessageBox.Show("Вдалий вхід.");
                                //REQUEST GET TYPE OF ACCOUNT
                                string req = GetTypeRequest();
                                if (req != "Error")
                                {
                                    string ID = GetID();
                                    ID = ID.Replace(@"""", "");
                                    ID = ID.Replace(@"""", "");
                                    //TODO ADMIN, OWNER, SELLER
                                    // MessageBox.Show(req);
                                    if (req==@"""Admin""")
                                    {
                                        Адмін_Панель адмінка = new Адмін_Панель(login.Text, password.Password);
                                        login.Clear();
                                        password.Clear();
                                        Hide();
                                        адмінка.ShowDialog();
                                        Show();
                                    }
                                    else if(req == @"""Owner""")
                                    {
                                        СторінкаАдміністратораМагазину сторінка = new СторінкаАдміністратораМагазину(ID);
                                        login.Clear();
                                        password.Clear();
                                        Hide();
                                        сторінка.ShowDialog();
                                        Show();
                                    }
                                    else
                                    {
                                        Сторінка_Продавця сторінка_ = new Сторінка_Продавця(ID);
                                        login.Clear();
                                        password.Clear();
                                        Hide();
                                        сторінка_.ShowDialog();
                                        Show();
                                    }
                                }
                                else
                                {
                                    
                                }
                            }
                            else
                            {
                                MessageBox.Show("Помилка! Можливо невірний пароль або немає підключення до інтернету.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка! Можливо невірний пароль або немає підключення до інтернету.");
            }
            
        }
        private string GetTypeRequest()
        {

            const string WEBSERVICE_URL = host+@"/api/Apii/GetTypeOfAccount";
            try
            {
                var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 12000;
                    webRequest.ContentType = "application/json";
                    webRequest.Headers.Add("Authorization2", "Basic dchZ2VudDM6cGFdGVzC5zc3dvmQ=");
                    webRequest.Headers.Add("Username", login.Text);
                    webRequest.Headers.Add("Password", password.Password);
                    using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                        {
                            var jsonResponse = sr.ReadToEnd();
                            return jsonResponse;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return "";
        }
        private string GetID()
        {
            const string WEBSERVICE_URL = host + @"/api/Apii/GetID";
            try
            {
                var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 12000;
                    webRequest.ContentType = "application/json";
                    webRequest.Headers.Add("Authorization2", "Basic dchZ2VudDM6cGFdGVzC5zc3dvmQ=");
                    webRequest.Headers.Add("Username", login.Text);
                    webRequest.Headers.Add("Password", password.Password);
                    using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                        {
                            var jsonResponse = sr.ReadToEnd();
                            return jsonResponse;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return "";
        }
    }
}
