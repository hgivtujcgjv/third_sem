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
    public class ReadUserPage : ContentPage
    {
        private Entry _userIdEntry;
        private Button _readButton;
        private Label _userDetailsLabel;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDb.db3");

        public ReadUserPage()
        {
            this.Title = "Read User";
            StackLayout stackLayout = new StackLayout();

            _userIdEntry = new Entry();
            _userIdEntry.Keyboard = Keyboard.Numeric;
            _userIdEntry.Placeholder = "User ID to Read";
            stackLayout.Children.Add(_userIdEntry);

            _readButton = new Button();
            _readButton.Text = "Read";
            _readButton.Clicked += _readButton_Clicked;
            stackLayout.Children.Add(_readButton);

            _userDetailsLabel = new Label();
            stackLayout.Children.Add(_userDetailsLabel);

            Content = stackLayout;
        }

        private async void _readButton_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(_userIdEntry.Text, out int userId))
            {
                var db = new SQLiteConnection(_dbPath);
                db.CreateTable<User>();

                var userToRead = db.Table<User>().FirstOrDefault(u => u.Id == userId);

                if (userToRead != null)
                {
                    _userDetailsLabel.Text = $"User Details:\nID: {userToRead.Id}\nName: {userToRead.Name}\nEmail: {userToRead.Email}";
                }
                else
                {
                    _userDetailsLabel.Text = "User Not Found";
                }
            }
            else
            {
                _userDetailsLabel.Text = "Invalid User ID";
            }
        }
    }
}
