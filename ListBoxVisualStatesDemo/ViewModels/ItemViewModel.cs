using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ListBoxVisualStatesDemo
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        private string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                NotifyPropertyChanged("UserName");
            }
        }

        private string _displayUserName;
        public string DisplayUserName
        {
            get
            {
                return _displayUserName;
            }
            set
            {
                _displayUserName = value;
                NotifyPropertyChanged("DisplayUserName");
            }
        }

        private string _image;
        public string Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                NotifyPropertyChanged("Image");
            }
        }

        private string _tweetText;
        public string TweetText
        {
            get
            {
                return _tweetText;
            }
            set
            {
                _tweetText = value;
                NotifyPropertyChanged("TweetText");
            }
        }

        private DateTime _createdDate;
        public DateTime CreatedDate
        {
            get
            {
                return _createdDate;
            }
            set
            {
                if (value != _createdDate)
                {
                    _createdDate = value;
                    NotifyPropertyChanged("CreatedDate");
                }
            }
        }

        public String FormattedDateTime
        {
            get
            {
                return CreatedDate == DateTime.MinValue ? String.Empty : GetFormattedDate(_createdDate);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static String GetFormattedDate(DateTime time)
        {
            var time1 = time.ToShortDateString();
            var time2 = DateTime.Now.ToLocalTime().ToShortDateString();

            if (time1 == time2)
                return time.ToShortTimeString();

            return String.Format("{0} {1}", time.ToShortDateString(), time.ToShortTimeString());
        }
    }
}