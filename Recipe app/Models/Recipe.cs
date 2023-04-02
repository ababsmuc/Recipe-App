using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;




namespace Recipe_app.Models
{
    public class Recipe
    {
        public string _uri { get; set; }

        public string _print { get; set; }


        private JsonDocument _json { get; set; }
        private ApiResponse recipe = new ApiResponse();

        public async Task PrintAllRecipesFor(string food)
        {

            _uri = $"list?size=3&q={food}";
            _json = await recipe.GetRecipe(_uri);
            GetDetails(_json);
        }


        public async Task GetRecipebyTag(string tag)
        {

            _uri = $"list?size=3&tags={tag}";
            _json = await recipe.GetRecipe(_uri);
            GetDetails(_json);
        }

        public async Task GetRecipewithTagandName(string tag, string food)
        {
            _uri = $"list?size=3&tags={tag}&q={food}";
            _json = await recipe.GetRecipe(_uri);
            GetDetails(_json);
        }


        public async Task GetRandomRecipe()
        {
            var rand = new Random();
            var value = rand.Next(1, 20);
            _uri = $"list?from={value}&size={1}&tags=every_occasion";
            _json = await recipe.GetRecipe(_uri);
           GetDetails(_json);
        }
        public void GetDetails(JsonDocument json)
        {
            if (json == null)
            {
                _print = "Please turn on your internet.";
            }
            else
            {
                if (json.RootElement.GetProperty("count").ToString() == 0.ToString())
                {
                    _print = "The input doesn't exist/ is not written correctly. Please try again!";
                }

                var results = json.RootElement.GetProperty("results");

                if (results.ValueKind == JsonValueKind.Array)
                {
                    try
                    {
                        int i = 1;

                        foreach (var item in results.EnumerateArray())
                        {
                            var instructions = item.GetProperty("instructions");
                            _print += "" + '\n';
                            _print += $"{i}. {item.GetProperty("name").GetString()} \n{item.GetProperty("yields").GetString()} \n";
                            i++;
                            var sections = item.GetProperty("sections");

                            foreach (var section in sections.EnumerateArray())
                            {
                                var components = section.GetProperty("components");
                                foreach (var component in components.EnumerateArray())
                                {
                                    var rawText = component.GetProperty("raw_text");

                                    _print += $"{rawText.GetString()} \n";
                                }
                            }

                            _print += '\n';
                            _print += "Steps:" + '\n';

                            foreach (var instruction in instructions.EnumerateArray())
                            {
                                var displayText = instruction.GetProperty("display_text");
                                var position = instruction.GetProperty("position");
                                _print += $"{position.GetDouble()}. {displayText.GetString()} \n";

                            }
                            _print = _print;
                        }


                    }
                    catch (KeyNotFoundException)
                    {
                        _print = "That recipe/food doesn't exist so please try again!";
                    }
                }

            }

        }

    }





    }

