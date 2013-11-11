using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using System.Net;


namespace ListBoxVisualStatesDemo
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private int _numberOfPagesToFetch;
        private int _curentPage;
        public event EventHandler SearchCompletedEvent;
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            Items.Clear();
            _numberOfPagesToFetch = 1;

            _curentPage = 1;

            //Search("Windows Phone 7");
            InitSomeData();
            this.IsDataLoaded = true;
        }

        private void InitSomeData()
        {
            for (int count = 0; count < 20;count++ )
                Items.Add(new ItemViewModel() { DisplayUserName = count.ToString()+"_chen",TweetText=count.ToString()+"_tweet" });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Search(string searchTerm)
        {
            var feedUri = String.Format("http://search.twitter.com/search.atom?q={0}&rpp=20&page={1} ", Uri.EscapeDataString(searchTerm), _curentPage);

            var webClient = new WebClient();
            webClient.DownloadStringCompleted += (sender, e) =>
            {
                if (e.Error != null)
                {
                    if (SearchCompletedEvent != null)
                        SearchCompletedEvent(this, EventArgs.Empty);
                    return;
                }

                // Remove Namespace
                var xmlDoc = XElement.Parse(e.Result.Replace("xmlns=\"http://www.w3.org/2005/Atom\"", String.Empty));

                foreach (var item in xmlDoc.Elements("entry"))
                {
                    Items.Add(new ItemViewModel
                    {
                        UserName = GetUserName(item),
                        DisplayUserName = GetUserDisplayName(item),
                        TweetText = (string)item.Element("title"),
                        CreatedDate = GetFormattedDate((string)item.Element("published")),
                        Image = (string)item.Descendants("link").ElementAt(1).Attribute("href"),
                    });
                }

                _curentPage++;
                if (_curentPage <= _numberOfPagesToFetch)
                {
                    Search(searchTerm);
                }
                else
                {
                    if (SearchCompletedEvent != null)
                        SearchCompletedEvent(this, EventArgs.Empty);
                }
            };
            webClient.DownloadStringAsync(new Uri(feedUri));
        }

        private static DateTime GetFormattedDate(string date)
        {
            return DateTime.Parse(date);
        }

        private static string GetUserName(XElement item)
        {            
            var names = GetNames(item);

            return names.Split(' ')[0];
        }

        private static string GetUserDisplayName(XElement item)
        {         
            var names = GetNames(item);

            var displayName = names.Substring(names.IndexOf('('));
            return displayName.Substring(1, displayName.Length - 2);
        }

        private static string GetNames(XElement item)
        {
            if (item == null) throw new ArgumentNullException("item");

            var author = item.Element("author");
            if (author == null)
                return String.Empty;

            return (string)author.Element("name");
        }
        
        
        
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}