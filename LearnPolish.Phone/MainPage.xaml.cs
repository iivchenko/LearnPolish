﻿using System.IO;
using System.Windows;
using System.Windows.Input;
using Microsoft.Phone.Controls;

namespace LearnPolish.Phone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            using (var file = File.Open(@"Assets/Dictionary.txt", FileMode.Open))
            using (var reader = new StreamReader(file))
            {
                DataContext = new ViewModel.ViewModel(reader.ReadToEnd());
            }
        }
        
        private void TextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Get().Translation = TranslationTextBox.Text;

                if (Get().CanCheckTranslation)
                {
                    Get().CheckTranslation();
                }
            }
        }

        private void SwitchLanguages_OnClick(object sender, RoutedEventArgs e)
        {
            Get().SwitchLanguagesMethod();
        }

        private ViewModel.ViewModel Get()
        {
            return ((ViewModel.ViewModel)DataContext);
        }
    }
}