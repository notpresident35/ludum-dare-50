using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemyManager : MonoBehaviour
{
    
    [HideInInspector]
    public List<Ingredient> AllIngredients;
    [HideInInspector]
    public List<Monster> AllMonsters;

    private void Awake() {
		AllIngredients.AddRange(Resources.LoadAll<Ingredient>("ScriptableObjects/Ingredients"));
		AllMonsters.AddRange(Resources.LoadAll<Monster>("ScriptableObjects/Monsters"));
    }

    // Returns null if recipe fizzles
    public Monster GetMonster (List<Ingredient> ingredients) {

        string recipe = IngredientsToRecipe(ingredients);

        return GetMonster(recipe);
    } 

    // Returns null if recipe fizzles
    public Monster GetMonster (string recipe) {
        string sortedRecipe = SortString(recipe);
        foreach (Monster monster in AllMonsters) {
            if (monster.Recipes.Contains(sortedRecipe)) {
                return monster;
            }
        }
        return null;
    } 

    // Use just for testing plz and ty
    public Monster GetRandomMonster () {
        return AllMonsters[Random.Range(0, AllMonsters.Count)];
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

    static string SortString(string input)
    {
        char[] characters = input.ToCharArray();
        System.Array.Sort(characters);
        return new string(characters);
    }
}
