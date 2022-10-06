using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    [SerializeField] private Recipe[] _recipes;

    public void TryCrafting()
    {
        foreach (var recipe in _recipes)
        {
            if(IsMatchingRecipe(recipe, Inventory.Instance.CraftingInventorySlots))
            {
                Inventory.Instance.ClearCraftingSlots();

                foreach (var reward in recipe.Rewards)
                    Inventory.Instance.AddItem(reward, InventoryType.Crafting);

                print("Crafted the recipe " + recipe.name);
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

        for (int i = recipe.Ingredients.Count; i < craftingInventorySlots.Length; i++) // recipe doesn't match with the item slots
        {
            if (craftingInventorySlots[i].IsEmpty == false)
                return false;
        }

        return true;
    }

#if UNITY_EDITOR
    private void OnValidate() => _recipes = SleepingDaemon.GetAllInstances<Recipe>();
#endif
}
