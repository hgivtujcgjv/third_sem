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
    public class DeleteTariffPage : ContentPage
    {
        private Entry _tariffIdEntry;
        private Button _deleteButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDb.db3");

        public DeleteTariffPage()
        {
            this.Title = "Delete Tariff";
            StackLayout stackLayout = new StackLayout();

            _tariffIdEntry = new Entry();
            _tariffIdEntry.Keyboard = Keyboard.Numeric;
            _tariffIdEntry.Placeholder = "Tariff ID to Delete";
            stackLayout.Children.Add(_tariffIdEntry);

            _deleteButton = new Button();
            _deleteButton.Text = "Delete";
            _deleteButton.Clicked += _deleteButton_Clicked;
            stackLayout.Children.Add(_deleteButton);

            Content = stackLayout;
        }

        private async void _deleteButton_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(_tariffIdEntry.Text, out int tariffId))
            {
                var db = new SQLiteConnection(_dbPath);
                db.CreateTable<Mobile_Tariff>();

                var tariffToDelete = db.Table<Mobile_Tariff>().FirstOrDefault(t => t.Id == tariffId);

                if (tariffToDelete != null)
                {
                    db.Delete(tariffToDelete);
                    await DisplayAlert(null, "Tariff Deleted", "Ok");
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
