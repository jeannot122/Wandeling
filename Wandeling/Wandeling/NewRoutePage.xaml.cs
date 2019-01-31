using System;
using WandelApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace WandelApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewRoutePage : ContentPage
	{
        Map GMap;

        public NewRoutePage()
        {
            InitializeComponent();

         
        }

        
        private void RouteSaveButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}