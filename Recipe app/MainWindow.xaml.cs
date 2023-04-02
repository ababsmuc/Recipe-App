using Recipe_app.Models;
using Recipe_app.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Recipe_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MainWindowViewModel viewmodel = new MainWindowViewModel();
        Recipe recipe = new Recipe();
        public MainWindow()
        {


            InitializeComponent();
            DataContext = viewmodel;
            this.Height = SystemParameters.PrimaryScreenHeight * 0.70;
            this.Width = SystemParameters.PrimaryScreenWidth * 0.70;

        }


    /*    private async void CookingTimeOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (CookingTimeOptions.SelectedIndex == 0)
            {
                MainTextBox.Text = "";
            }
            else
            {
                MainTextBox.Text = "";
                string Thecookingtime = viewmodel.cookingTime[CookingTimeOptions.SelectedIndex];
                await recipe.GetRecipesfromCookingTime(Thecookingtime);
                MainTextBox.Text = recipe.TOPRINT.ToString();
                recipe.TOPRINT = "";
            }
        }

        private async void MealTypeOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MealTypeOptions.SelectedIndex == 0)
            {
                MainTextBox.Text = "";
            }
            else
            {
                MainTextBox.Text = "";
                string mealtype = viewmodel.mealType[MealTypeOptions.SelectedIndex];
                await recipe.GetRecipebyMealType(mealtype);
                MainTextBox.Text = recipe.TOPRINT.ToString();
                recipe.TOPRINT = "";
            }
        }

        private async void DietTypeOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DietTypeOptions.SelectedIndex == 0)
            {
                MainTextBox.Text = "";
            }
            else
            {
                MainTextBox.Text = "";
                string diettype = viewmodel.dietType[DietTypeOptions.SelectedIndex];
                await recipe.GetRecipebyDiet(diettype);
                MainTextBox.Text = recipe.TOPRINT.ToString();
                recipe.TOPRINT = "";
            }
        }*/
    }
}
