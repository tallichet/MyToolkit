﻿using Windows.UI.Xaml;
using MyToolkit.Collections;
using MyToolkit.Paging;

namespace SampleUniversalPhoneApp.Views
{
    public sealed partial class LongListSelectorPage : MtPage
    {
        private readonly AlphaGroupCollection<string> _groups;

        public LongListSelectorPage()
        {
            InitializeComponent();

            _groups = new AlphaGroupCollection<string>
            {
                "Rico Suter", 
                "Hans Muster", 
                "Jane Doe", 
                "Jon Doe", 
                "Johnny Cash", 
                "Bill Gates", 
            };

            LongListSelector.ItemsSource = _groups;
        }

        private void OnAddItem(object sender, RoutedEventArgs e)
        {
            _groups.Add("Test Test");
        }
    }
}
