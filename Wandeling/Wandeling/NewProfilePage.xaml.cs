using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WandelApp.Models;

using System.Data.SqlClient;

namespace WandelApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewProfilePage : ContentPage
    {
        public NewProfilePage()
        {
            InitializeComponent();
        }

        // Button die de ingevulde gegevens opslaat
        private void CreateButton_Clicked(object sender, EventArgs e)
        {
            // controle van invoervelden en of deze zijn ingevuld
            bool isFullNameEmpty = string.IsNullOrEmpty(FullNameEntry.Text);
            bool isUsernameEmpty = string.IsNullOrEmpty(NewUsernameEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(NewPasswordEntry.Text);
            bool isConfirmPasswordEmpty = string.IsNullOrEmpty(ConfirmPasswordEntry.Text);
            bool isPhoneNumberEmpty = string.IsNullOrEmpty(PhoneNumberEntry.Text);

            //Als een van de velden niet ingevuld is verschijnt er een melding
            if (isUsernameEmpty == true || isPasswordEmpty == true || isConfirmPasswordEmpty == true || isFullNameEmpty == true || isPhoneNumberEmpty == true)
            {
                DisplayAlert("Mislukt", "Alle velden moeten ingevuld zijn!", "Ok");
            }

            else
            {
                // doorverwijzing naar de hoofdpagina
                Navigation.PushAsync(new MainPage());
            }

        }

    }
}