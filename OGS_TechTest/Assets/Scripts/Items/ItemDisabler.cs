using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisabler : MonoBehaviour
{
    // Script to disableor enable selected game objects
    [SerializeField] private GameObject[] _items;


    public void DisableGO()
    {
        if(_items.Length <= 0)
        {
            // No items in array
            Debug.LogError("Array is empty");
            return;
        }

        foreach(GameObject go in _items)
        {
            go.SetActive(false);
        }
    }

    public void EnableGO()
    {
        if (_items.Length <= 0)
        {
            // No items in array
            Debug.LogError("Array is empty");
            return;
        }

        foreach (GameObject go in _items)
        {
            go.SetActive(true);
        }
    }
}
