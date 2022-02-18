using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    // Material Index values
    /*
     * 0 - White
     * 1 - Red
     * 2 - Yellow
     * 3 - Green
     * 4 - Cyan
     * 5 - Blue
     * 6 - Magenta
     */
    [SerializeField] private int[] _materialQuantities = new int[7];

    private int[] _itemQuantities = new int[8];

    private int[] matRequirements;

    public int[] MaterialQuantities => _materialQuantities;

    public int CheckMaxQuantity()
    {
        // Maximum amount of items that can be made with the actual materials
        matRequirements = TradeTableValues.MaterialRequirements(AlchemyMenuManager.Instance.OptionSelected, AlchemyMenuManager.Instance.ItemSelected);
        int[] itemsByMaterial = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
        // Number for the max quantity items that can be made with actual materials, start at infinity to be decreasing afterwards
        float maxQuantityItems = Mathf.Infinity;

        for (int i = 0; i < matRequirements.Length-1; i++)
        {
            // Check every material's needs if it is 0 is not a required item
            if(matRequirements[i] > 0)
            {
                itemsByMaterial[i] = DivisionResult(_materialQuantities[i], matRequirements[i]);

                Debug.Log($"item no. {i}, quantity {itemsByMaterial[i]}");
                // Ternary operator to get the max items that can be made
                maxQuantityItems = itemsByMaterial[i] < maxQuantityItems ? itemsByMaterial[i] : maxQuantityItems;
            }
        }

        Debug.Log($"The maximum number of items that can be made is: {maxQuantityItems}");
        return (int)maxQuantityItems;
    }

    private int DivisionResult(int valueToDivide, int dividingValue)
    {
        // if trying to divide by 0 or less than 0, return false
        if (dividingValue > 0)
        {
            return (int)Mathf.Floor(valueToDivide / dividingValue);
        }

        return 0;
    }

    public void AddMaterials(int materialIndex, int quantity)
    {
        _materialQuantities[materialIndex] += quantity;
    }

    public void SubstractMaterials(int materialIndex, int quantity)
    {
        _materialQuantities[materialIndex] -= matRequirements[materialIndex] * quantity;
    }

    public void AddItem(int quantity)
    {
        _itemQuantities[(int)AlchemyMenuManager.Instance.ItemSelected] += quantity;
    }

    public void SubstractItem(int quantity)
    {
        _itemQuantities[(int)AlchemyMenuManager.Instance.ItemSelected] -= quantity;
    }
}
