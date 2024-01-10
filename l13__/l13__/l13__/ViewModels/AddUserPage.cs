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
    public class AddUserPage : ContentPage
    {
        private Entry _nameEntry;
        private Entry _emailEntry;
        private Entry _phoneNumberEntry;
        private Button _saveButton;

        string _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "myDb.db3");

        public AddUserPage()
        {
            Title = "Add User";
            StackLayout stackLayout = new StackLayout();

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "User Name";
            stackLayout.Children.Add(_nameEntry);

            _emailEntry = new Entry();
            _emailEntry.Keyboard = Keyboard.Text;
            _emailEntry.Placeholder = "User Email";
            stackLayout.Children.Add(_emailEntry);

            _phoneNumberEntry = new Entry();
            _phoneNumberEntry.Keyboard = Keyboard.Telephone;
            _phoneNumberEntry.Placeholder = "User Phone Number";
            stackLayout.Children.Add(_phoneNumberEntry);

            _saveButton = new Button();
            _saveButton.Text = "Add";
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;
        }

        public async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<User>();

            var maxPk = db.Table<User>().OrderByDescending(c => c.Id).FirstOrDefault();

            User user = new User()
            {
                Id = maxPk == null ? 1 : maxPk.Id + 1,
                Name = _nameEntry.Text,
                Email = _emailEntry.Text,
                Phone_Number = _phoneNumberEntry.Text
            };

            db.Insert(user);
            await DisplayAlert(null, user.Name + " Saved", "Ok");
            await Navigation.PopAsync();
        }
    }

}