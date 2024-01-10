using l13__.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace l13__.ViewModels
{
    public class AddTariffPage : ContentPage
    {
        private Entry _nameEntry;
        private Entry _priceEntry;
        private Entry _descriptionEntry;
        private Button _saveButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDb.db3");

        public AddTariffPage()
        {
            this.Title = "Add Tariff";
            StackLayout stackLayout = new StackLayout();

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Tariff Name";
            stackLayout.Children.Add(_nameEntry);

            _priceEntry = new Entry();
            _priceEntry.Keyboard = Keyboard.Numeric;
            _priceEntry.Placeholder = "Tariff Price";
            stackLayout.Children.Add(_priceEntry);

            _descriptionEntry = new Entry();
            _descriptionEntry.Keyboard = Keyboard.Text;
            _descriptionEntry.Placeholder = "Tariff Description";
            stackLayout.Children.Add(_descriptionEntry);

            _saveButton = new Button();
            _saveButton.Text = "Add";
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;
        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Mobile_Tariff>();

            Mobile_Tariff tariff = new Mobile_Tariff()
            {
                Name_of_Tariff = _nameEntry.Text,
                Price = int.Parse(_priceEntry.Text),
                Description = _descriptionEntry.Text
            };

            db.Insert(tariff);
            await DisplayAlert(null, $"{tariff.Name_of_Tariff} Saved", "Ok");
            await Navigation.PopAsync();
        }
    }
}
