using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace l13__.ViewModels
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            this.Title = "Select Option";

            StackLayout stackLayout = new StackLayout();
            Button button1 = new Button();
            button1.Text = "Operations with User";
            button1.Clicked += first_Button_Clicked;
            stackLayout.Children.Add(button1);


           
            button1 = new Button();
            button1.Text = "Operations with Tariffs";
            button1.Clicked += second_Button_Clicked;
            stackLayout.Children.Add(button1);


            Content = stackLayout;
        }

        private async void first_Button_Clicked(object sender, EventArgs e) { 
            await Navigation.PushAsync(new OperationsUser());
        }
        private async void second_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OperationsTariff());
        }
    }
}