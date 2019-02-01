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
	public partial class ShowEvaluationPage : ContentPage
	{
        public ListView _ListView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
		public ShowEvaluationPage ()
		{
            this.Title = "Recensies";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _ListView = new ListView();
            _ListView.ItemsSource = db.Table<Evaluation>().OrderBy(x => x.Name).ToList();
            stackLayout.Children.Add(_ListView);

            Content = stackLayout;
		}
	}
}