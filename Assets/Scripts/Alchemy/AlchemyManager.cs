using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemyManager : MonoBehaviour
{
    
    public List<Ingredient> AllIngredients;
    public List<Monster> AllMonsters;

    public Monster GetMonster (List<Ingredient> ingredients) {
        string recipe = IngredientsToRecipe(ingredients);

        return GetMonster(recipe);
    } 

    // Returns null if recipe fizzles
    public Monster GetMonster (string recipe) {
        foreach (Monster monster in AllMonsters) {
            if (monster.Recipes.Contains(recipe)) {
                return monster;
            }
        }
        return null;
    } 

    public List<Ingredient> RecipeToIngredients (string ingredients) {
        
        List<Ingredient> output = new List<Ingredient>();

        for (int i = 0; i < ingredients.Length; i++) {
            foreach (Ingredient ingredient in AllIngredients) {
                if (ingredients[i] == ingredient.Abbreviation) {
                    output.Add(ingredient);
                    break;
                }
            }
        }

        return output;
    }

    public string IngredientsToRecipe (List<Ingredient> ingredients) {
        
        string output = "";

        foreach (Ingredient ingredient in AllIngredients) {
            output += ingredient.Abbreviation;
        }

        return output;
    }

    // Tester
    /*private void Start() {
        print (GetMonster("MM"));
    }*/
}
