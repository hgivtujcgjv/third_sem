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
    public class UpdateUserPage : ContentPage
    {
        private Entry _userIdEntry;
        private Entry _nameEntry;
        private Entry _emailEntry;
        private Entry _phoneNumberEntry; 
        private Button _updateButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDb.db3");

        public UpdateUserPage()
        {
            this.Title = "Update User";
            StackLayout stackLayout = new StackLayout();

            _userIdEntry = new Entry();
            _userIdEntry.Keyboard = Keyboard.Numeric;
            _userIdEntry.Placeholder = "User ID to Update";
            stackLayout.Children.Add(_userIdEntry);

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "New User Name";
            stackLayout.Children.Add(_nameEntry);

            _emailEntry = new Entry();
            _emailEntry.Keyboard = Keyboard.Text;
            _emailEntry.Placeholder = "New User Email";
            stackLayout.Children.Add(_emailEntry);

            _phoneNumberEntry = new Entry();
            _phoneNumberEntry.Keyboard = Keyboard.Telephone;
            _phoneNumberEntry.Placeholder = "New User Phone Number";
            stackLayout.Children.Add(_phoneNumberEntry);

            _updateButton = new Button();
            _updateButton.Text = "Update";
            _updateButton.Clicked += _updateButton_Clicked;
            stackLayout.Children.Add(_updateButton);

            Content = stackLayout;
        }

        private async void _updateButton_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(_userIdEntry.Text, out int userId))
            {
                var db = new SQLiteConnection(_dbPath);
                db.CreateTable<User>();

                var userToUpdate = db.Table<User>().FirstOrDefault(u => u.Id == userId);

                if (userToUpdate != null)
                {
                    userToUpdate.Name = _nameEntry.Text;
                    userToUpdate.Email = _emailEntry.Text;
                    userToUpdate.Phone_Number = _phoneNumberEntry.Text;

                    db.Update(userToUpdate);
                    await DisplayAlert(null, "User Updated", "Ok");
                }
                else
                {
                    await DisplayAlert(null, "User Not Found", "Ok");
                }

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(null, "Invalid User ID", "Ok");
            }
        }
    }
}
