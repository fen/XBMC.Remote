﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Xbmc_Movies
{
    using System.ComponentModel;

    public class MovieViewModel : INotifyPropertyChanged
	{
		private string duration;
		private bool durationFormatted = false;

	    private BitmapImage thumbnail;

	    public MovieViewModel()
		{
		}
		
		public string Title { get; set; }
		
		public int Year { get; set; }
		
	    public BitmapImage Thumbnail
	    {
	        get
	        {
	            return this.thumbnail;
	        }
            
            set
            {
                this.thumbnail = value;
                this.OnPropertyChanged("Thumbnail");
            }
	    }
		
		public string Duration 
		{ 
			get
			{
				if (!this.durationFormatted)
                {
                    if (this.duration == null)
                    {
						this.duration = "N/A";
                        this.durationFormatted = true;
                    }
                    else
                    {
                        TimeSpan duration = TimeSpan.FromMinutes(int.Parse(this.duration));
                        this.duration = string.Format("{0}h {1}min", duration.Hours, duration.Minutes);
                        this.durationFormatted = true;
                    }
                }
				
				return this.duration;
			}
			set
			{
				this.durationFormatted = false;
				this.duration = value;
			}
		}
		
		public string Rating { get; set; }
		
		public string Genre { get; set; }
		
		public string Cast { get; set; }
		
		public string Director { get; set; }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

	}
}