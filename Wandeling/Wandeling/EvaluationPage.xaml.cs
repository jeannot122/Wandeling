using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wandeling
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EvaluationPage : ContentPage
	{
		public EvaluationPage ()
		{
            this.Title = "Select Option";
            StackLayout stackLayout = new StackLayout();
            Button button = new Button();
            button.Text = "Recensie toevoegen";
            button.Clicked += Button_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Recensies bekijken";
            button.Clicked += Button_Show_Clicked;
            stackLayout.Children.Add(button);

            Content = stackLayout;
			
		}        

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEvaluationPage());
        }

        private async void Button_Show_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowEvaluationPage());
        }
    }
}