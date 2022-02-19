using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectionController : MonoBehaviour
{
    private AlchemyMenuManager manager;

    private void Awake()
    {
        manager = AlchemyMenuManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // Nullable prevention
        if(manager == null)
        {
            Debug.LogError("No alchemy menu manager in scene");
            return;
        }

        // Set options if option selected flag is false
        if (!manager.IsOptionSelected)
        {
            manager.SetOption(collision.gameObject.GetComponent<OptionInformation>().option);
            return;
        }


        // Set families if family selected flag is false
        if (!manager.IsFamilySelected)
        {
            manager.SetFamily(collision.gameObject.GetComponent<FamilyInformation>().family);
            return;
        }

        ItemInformation myInformation = collision.gameObject.GetComponent<ItemInformation>();
        manager.SetItem(myInformation.itemType, myInformation.index);
    }
}
