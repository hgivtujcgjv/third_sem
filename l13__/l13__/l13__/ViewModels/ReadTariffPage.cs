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
    public class ReadTariffPage : ContentPage
    {
        private Entry _tariffIdEntry;
        private Button _readButton;
        private Label _tariffDetailsLabel;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDb.db3");

        public ReadTariffPage()
        {
            this.Title = "Read Tariff";
            StackLayout stackLayout = new StackLayout();

            _tariffIdEntry = new Entry();
            _tariffIdEntry.Keyboard = Keyboard.Numeric;
            _tariffIdEntry.Placeholder = "Tariff ID to Read";
            stackLayout.Children.Add(_tariffIdEntry);

            _readButton = new Button();
            _readButton.Text = "Read";
            _readButton.Clicked += _readButton_Clicked;
            stackLayout.Children.Add(_readButton);

            _tariffDetailsLabel = new Label();
            stackLayout.Children.Add(_tariffDetailsLabel);

            Content = stackLayout;
        }

        private async void _readButton_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(_tariffIdEntry.Text, out int tariffId))
            {
                var db = new SQLiteConnection(_dbPath);
                db.CreateTable<Mobile_Tariff>();

                var tariffToRead = db.Table<Mobile_Tariff>().FirstOrDefault(t => t.Id == tariffId);

                if (tariffToRead != null)
                {
                    _tariffDetailsLabel.Text = $"Tariff Details:\nID: {tariffToRead.Id}\nName: {tariffToRead.Name_of_Tariff}\nPrice: {tariffToRead.Price}\nDescription: {tariffToRead.Description}";
                }
                else
                {
                    _tariffDetailsLabel.Text = "Tariff Not Found";
                }
            }
            else
            {
                _tariffDetailsLabel.Text = "Invalid Tariff ID";
            }
        }
    }
}
