﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Lab2.Services;
using Lab2.Views;

namespace Lab2
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
