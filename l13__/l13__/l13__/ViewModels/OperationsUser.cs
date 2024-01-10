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
    public class OperationsUser : ContentPage
    {
        public OperationsUser()
        {
                this.Title = "Select Option";

            StackLayout stackLayout = new StackLayout();

            Button button1 = new Button();
            button1.Text = "Add User";
            button1.Clicked += first_Button_Clicked;
            stackLayout.Children.Add(button1);

            Button button2 = new Button();
            button2.Text = "Delete User";
            button2.Clicked += second_Button_Clicked;
            stackLayout.Children.Add(button2);

            Button button3 = new Button(); 
            button3.Text = "Update User";
            button3.Clicked += third_Button_Clicked;
            stackLayout.Children.Add(button3);

            Button button4 = new Button();
            button4.Text = "Read User";
            button4.Clicked += fourth_Button_Clicked;
            stackLayout.Children.Add(button4);

            Content = stackLayout;

        }

        private async void first_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddUserPage());
        }
        private async void second_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteUserPage());
        }
        private async void third_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdateUserPage());
        }

        private async void fourth_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReadUserPage());
        }
    }
}