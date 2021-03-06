﻿using SQLiteDemo.ViewModels;
using SQLiteDemo.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SQLiteDemo.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; NotifyPropertyChanged(); }
        }

        protected DataContext Repository { get; private set; }

        public ViewModel()
        {
            LoadData();
        }

        private async void LoadData()
        {
            IsLoading = true;
            this.Repository = await DataContextFactory.GetDataContextAsync();
            IsLoading = false;
            OnDataLoaded();
        }

        protected abstract void OnDataLoaded();

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}