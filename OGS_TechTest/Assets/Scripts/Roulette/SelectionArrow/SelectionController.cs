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

        // Debug.Log($"{collision.gameObject.name}");
        if (!manager.IsOptionSelected)
        {
            Debug.Log(collision.gameObject.name);
            manager.SetOption(collision.gameObject.GetComponent<OptionInformation>().option);
            return;
        }

        if (!manager.IsFamilySelected)
        {
            manager.SetFamily(collision.gameObject.GetComponent<FamilyInformation>().family);
            return;
        }
    }
}
