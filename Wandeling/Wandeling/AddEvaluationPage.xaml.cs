using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WandelApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wandeling
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEvaluationPage : ContentPage
    {
        private Entry _nameEntry;
        private Entry _reviewEntry;
        private Entry _scoreEntry;
        private Button _saveButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public AddEvaluationPage()
        {
            this.Title = "Review toevoegen";

            StackLayout stackLayout = new StackLayout();

            //aanmaken entry voor de naam in te voeren
            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Uw naam";
            stackLayout.Children.Add(_nameEntry);

            //aanmaken entry voor de recensie in te voeren
            _reviewEntry = new Entry();
            _reviewEntry.Keyboard = Keyboard.Text;
            _reviewEntry.Placeholder = "Uw recensie";
            stackLayout.Children.Add(_reviewEntry);

            //aanmaken entry voor de score in te voeren
            _scoreEntry = new Entry();
            _scoreEntry.Keyboard = Keyboard.Text;
            _scoreEntry.Placeholder = "Uw cijfer";
            stackLayout.Children.Add(_scoreEntry);

            //aanmaken savebutton
            _saveButton = new Button();
            _saveButton.Text = "Opslaan";
            _saveButton.Clicked += saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;
        }

        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Evaluation>();

            var maxPk = db.Table<Evaluation>().OrderByDescending(c => c.EvaluationId).FirstOrDefault();

            Evaluation evaluation = new Evaluation()
            {
                EvaluationId = (maxPk == null ? 1 : maxPk.EvaluationId + 1),
                Name = _nameEntry.Text,
                Review = _reviewEntry.Text,
                Score = _scoreEntry.Text
            };
            db.Insert(evaluation);
            await DisplayAlert(null, "Uw recensie is opgeslagen", "Ok");
            await Navigation.PopAsync();
        }
    }
}