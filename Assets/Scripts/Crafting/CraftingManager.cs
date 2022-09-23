using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    [SerializeField] private Recipe[] _recipes;

    public void TryCrafting()
    {
        var itemsInCraftingInventory = Inventory.Instance.CraftingInventorySlots.Count(t => t.IsEmpty == false);
        print(itemsInCraftingInventory);

        foreach (var recipe in _recipes)
        {
            if(IsMatchingRecipe(recipe, Inventory.Instance.CraftingInventorySlots))
            {
                print("Found the recipe " + recipe.name);
                return;
            }
        }
    }

    private bool IsMatchingRecipe(Recipe recipe, ItemSlot[] craftingInventorySlots)
    {
        for (int i = 0; i < recipe.Ingredients.Count; i++) //loop through each ingredient
        {
            if (recipe.Ingredients[i] != craftingInventorySlots[i].Item)
                return false;
        }

        return true;
    }

#if UNITY_EDITOR
    private void OnValidate() => _recipes = SleepingDaemon.GetAllInstances<Recipe>();
#endif
}
