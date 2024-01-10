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
    public class UpdateTariffPage : ContentPage
    {
        private Entry _tariffIdEntry;
        private Entry _nameEntry;
        private Entry _priceEntry;
        private Entry _descriptionEntry;
        private Button _updateButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDb.db3");

        public UpdateTariffPage()
        {
            this.Title = "Update Tariff";
            StackLayout stackLayout = new StackLayout();

            _tariffIdEntry = new Entry();
            _tariffIdEntry.Keyboard = Keyboard.Numeric;
            _tariffIdEntry.Placeholder = "Tariff ID to Update";
            stackLayout.Children.Add(_tariffIdEntry);

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "New Tariff Name";
            stackLayout.Children.Add(_nameEntry);

            _priceEntry = new Entry();
            _priceEntry.Keyboard = Keyboard.Numeric;
            _priceEntry.Placeholder = "New Tariff Price";
            stackLayout.Children.Add(_priceEntry);

            _descriptionEntry = new Entry();
            _descriptionEntry.Keyboard = Keyboard.Text;
            _descriptionEntry.Placeholder = "New Tariff Description";
            stackLayout.Children.Add(_descriptionEntry);

            _updateButton = new Button();
            _updateButton.Text = "Update";
            _updateButton.Clicked += _updateButton_Clicked;
            stackLayout.Children.Add(_updateButton);

            Content = stackLayout;
        }

        private async void _updateButton_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(_tariffIdEntry.Text, out int tariffId))
            {
                var db = new SQLiteConnection(_dbPath);
                db.CreateTable<Mobile_Tariff>();

                var tariffToUpdate = db.Table<Mobile_Tariff>().FirstOrDefault(t => t.Id == tariffId);

                if (tariffToUpdate != null)
                {
                    tariffToUpdate.Name_of_Tariff = _nameEntry.Text;
                    tariffToUpdate.Price = int.Parse(_priceEntry.Text);
                    tariffToUpdate.Description = _descriptionEntry.Text;

                    db.Update(tariffToUpdate);
                    await DisplayAlert(null, "Tariff Updated", "Ok");
                }
                else
                {
                    await DisplayAlert(null, "Tariff Not Found", "Ok");
                }

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(null, "Invalid Tariff ID", "Ok");
            }
        }
    }
}
