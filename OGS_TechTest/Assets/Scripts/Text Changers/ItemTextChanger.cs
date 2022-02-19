using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemTextChanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _thisItemTMP;

    private void Start()
    {
        // Subscribe to event
        TextEvent.instance.onChangedQuantity += ChangeItemNumber;
    }

    private void OnDestroy()
    {
        // UnSubscribe to event
        TextEvent.instance.onChangedQuantity -= ChangeItemNumber;
    }

    public void ChangeItemNumber()
    {
        _thisItemTMP.text = ItemTextManager.Instance.ItemNumToMake.ToString();
    }
}
