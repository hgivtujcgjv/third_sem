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
    public class DeleteUserPage : ContentPage
    {
        private Entry _userIdEntry;
        private Button _deleteButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDb.db3");

        public DeleteUserPage()
        {
            this.Title = "Delete User";
            StackLayout stackLayout = new StackLayout();

            _userIdEntry = new Entry();
            _userIdEntry.Keyboard = Keyboard.Numeric;
            _userIdEntry.Placeholder = "User ID to Delete";
            stackLayout.Children.Add(_userIdEntry);

            _deleteButton = new Button();
            _deleteButton.Text = "Delete";
            _deleteButton.Clicked += _deleteButton_Clicked;
            stackLayout.Children.Add(_deleteButton);

            Content = stackLayout;
        }

        private async void _deleteButton_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(_userIdEntry.Text, out int userId))
            {
                var db = new SQLiteConnection(_dbPath);
                db.CreateTable<User>();

                var userToDelete = db.Table<User>().FirstOrDefault(u => u.Id == userId);

                if (userToDelete != null)
                {
                    db.Delete(userToDelete);
                    await DisplayAlert(null, "User Deleted", "Ok");
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
