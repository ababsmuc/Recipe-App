using Recipe_app.Models;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Recipe_app.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public string[] cuisine { get; set; }
        public string[] cookingTime { get; set; }
        public string[] mealType { get; set; }
        public string[] dietType { get; set; }
        private string _displayText;
        public string DisplayText
        {
            get => _displayText;
            set => SetProperty(ref _displayText, value);
        }

        private string _ingredientText;

        public string IngredientText
        {
            get => _ingredientText;
            set => SetProperty(ref _ingredientText, value);
        }

        private string _recipeText;

        public string RecipeText
        {
            get => _recipeText;
            set => SetProperty(ref _recipeText, value);
        }
        Recipe recipe = new();
        


        public async void RandomRecipe()
        {
            DisplayText = "";
            await recipe.GetRandomRecipe();

            DisplayText = recipe._print.ToString();
            recipe._print = "";
        }

        private ICommand _buttonCommand;
        public ICommand ButtonCommand
        {
            get
            {
                if (_buttonCommand == null)
                {
                    _buttonCommand = new CommandBase(
                        p => true,
                        p => RandomRecipe());
                }
                return _buttonCommand;
            }
        }



        private ICommand _ingredientandrecipeSearchCommand;
        public ICommand IngredientandRecipeSearchCommand
        {
            get
            {
                if (_ingredientandrecipeSearchCommand == null)
                {
                    _ingredientandrecipeSearchCommand = new CommandBase(
                        p => true,
                        p => GetRecipeFromTextBox());
                }
                return _ingredientandrecipeSearchCommand;
            }
        }



        async void GetRecipeFromTextBox()
        {
            if (string.IsNullOrEmpty(RecipeText) && !string.IsNullOrEmpty(IngredientText) && Selected != "")
            {
                DisplayText = "";
                await recipe.GetRecipewithTagandName(Selected, IngredientText);
                DisplayText = recipe._print.ToString();
                recipe._print = "";
            }
            else if (!string.IsNullOrEmpty(RecipeText) && string.IsNullOrEmpty(IngredientText) && Selected != "")
            {
                DisplayText = "";
                await recipe.GetRecipewithTagandName(Selected, RecipeText);

                DisplayText = recipe._print.ToString();
                recipe._print = "";
            }
            else if (string.IsNullOrEmpty(RecipeText) && !string.IsNullOrEmpty(IngredientText))
            {
                DisplayText = "";
                await recipe.PrintAllRecipesFor(IngredientText);

                DisplayText = recipe._print.ToString();
                recipe._print = "";
            }
            else if (!string.IsNullOrEmpty(RecipeText) && !string.IsNullOrEmpty(IngredientText))
            {
                DisplayText = "Chill! Error! One at a time please!";
            }
            else if (!string.IsNullOrEmpty(RecipeText) && string.IsNullOrEmpty(IngredientText))
            {
                DisplayText = "";
                await recipe.PrintAllRecipesFor(RecipeText);

                DisplayText = recipe._print.ToString();
                recipe._print = "";
            }


            IngredientText = "";
            RecipeText = "";
        }

        public string _selected;
        public string Selected
        {
            get => _selected;
            set
            {
                SetProperty(ref _selected, value);


                SelectionChanged();
            }
        }


        private async void SelectionChanged()
        {
            if (Selected == "")
            {
                DisplayText = "";
            }
            else
            {
                DisplayText = "";

                await recipe.GetRecipebyTag(Selected);

                DisplayText = recipe._print.ToString();
                recipe._print = "";
            }
        }


        public MainWindowViewModel()
        {
            cuisine = new[] { "", "mexican", "french", "korean", "african" };
            cookingTime = new[] { "", "under_30_minutes", "under_1_hour", "under_15_minutes", "under_45_minutes" };
            mealType = new[] { "", "lunch", "bakery_goods", "desserts", "sides" };
            dietType = new[] { "", "vegan", "vegetarian", "gluten_free", "keto", "high_protein" };
            DisplayText = "Select one of the filters, search for an ingredient, a recipe or click the random recipe button for a surprise recipe!";


        }


    }


}