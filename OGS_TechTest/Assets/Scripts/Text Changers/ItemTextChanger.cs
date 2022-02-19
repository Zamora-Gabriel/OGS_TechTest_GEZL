using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemTextChanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _thisItemTMP;

    private void OnEnable()
    {
        // Subscribe to event
        TextEvent.instance.onChangedMatNumber += ChangeItemNumber;
    }

    private void OnDisable()
    {
        // UnSubscribe to event
        TextEvent.instance.onChangedMatNumber -= ChangeItemNumber;
    }

    private void ChangeItemNumber()
    {
        _thisItemTMP.text = ItemTextManager.Instance.ItemNumToMake.ToString();
    }
}
