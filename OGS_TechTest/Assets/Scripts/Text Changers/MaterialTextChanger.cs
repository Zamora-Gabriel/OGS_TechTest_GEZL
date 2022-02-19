using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaterialTextChanger : MonoBehaviour
{
    [SerializeField] private SELECTEDITEM _ItemType;
    [SerializeField] private MATERIAL _materialColor;
    [SerializeField] private TextMeshProUGUI _thisMatNumberText;

    private void Start()
    {
        // Subscribe to event
        TextEvent.instance.onChangedQuantity += ChangeMaterialNumber;
    }

    private void OnDestroy()
    {
        // UnSubscribe to event
        TextEvent.instance.onChangedQuantity -= ChangeMaterialNumber;
    }

    private void ChangeMaterialNumber()
    {
        if(AlchemyMenuManager.Instance.OptionSelected == SELECTEDOPTION.FUSION)
        {
            int matToConsume = ItemTextManager.Instance.MaterialNumToConsume[(int)_materialColor];
            int matRequired = ItemTextManager.Instance.MaterialNumRequired[(int)_materialColor];
            Debug.Log($"{matToConsume} / {matRequired}");
            _thisMatNumberText.text = $"{matToConsume} / {matRequired}";
        }

        if(_ItemType == AlchemyMenuManager.Instance.ItemSelected)
        {
            int matToConsume = ItemTextManager.Instance.MaterialNumToConsume[(int)_materialColor];
            int matRequired = ItemTextManager.Instance.MaterialNumRequired[(int)_materialColor];
            _thisMatNumberText.text = $"{matToConsume} / {matRequired}";
        }
    }
}
