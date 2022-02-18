using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TradeTableManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _tradeItemTables;
    [SerializeField] private InventoryScript _inventory;

    [Header("UI Selection Objects")]
    [SerializeField] private Slider _valSlider;
    [SerializeField] private TMP_InputField _inputField;

    private AlchemyMenuManager _manager;
    private int _maxItemQuantity;
    private int _quantitySelected;

    private void Awake()
    {
        _manager = AlchemyMenuManager.Instance;
    }

    // 0 Pure red event
    // 1 crimson event
    // 2 Pure yellow event
    // 3 Orange event
    // 4 Emerald event
    // 5 Turquoise event
    // 6 Deep blue event
    // 7 Purple event
    public void UpdateItemUI(SELECTEDITEM itemSelection)
    {
        UIObjectDeactivator((int)itemSelection);
        _maxItemQuantity = _inventory.CheckMaxQuantity();
        _valSlider.maxValue = _maxItemQuantity;
    }

    public void UpdateFusionUI()
    {
        _maxItemQuantity = _inventory.CheckMaxQuantity();
        _valSlider.maxValue = _maxItemQuantity;
    }

    // Activate only selected family's items
    private void UIObjectDeactivator(int activeIndex)
    {
        for (int i = 0; i < _tradeItemTables.Length; i++)
        {
            if (i == activeIndex)
            {
                _tradeItemTables[i].SetActive(true);
            }
            else
            {
                _tradeItemTables[i].SetActive(false);
            }
        }
    }

    public void Trade()
    {
        if (_manager.OptionSelected == SELECTEDOPTION.FUSION)
        {
            FusionTrade();
        }

        if (_manager.OptionSelected == SELECTEDOPTION.MIX)
        {
            MixTrade();
        }
    }

    private void FusionTrade()
    {
        for (int i = 1; i < _inventory.MaterialQuantities.Length - 1; i++)
        {
            // Substract the quantity required from each material to make the white particles
            _inventory.SubstractMaterials(i, _quantitySelected);
        }

        // Add white particles
        _inventory.AddMaterials(0, _quantitySelected);
    }

    private void MixTrade()
    {
        for (int i = 0; i < _inventory.MaterialQuantities.Length - 1; i++)
        {
            // Substract the quantity required from each material to make the white particles
            _inventory.SubstractMaterials(i, _quantitySelected);
        }

        // Add item selected
        _inventory.AddItem(_quantitySelected);
    }

    // Input field functions
    public void UpdateWithInputField()
    {
        if (int.Parse(_inputField.text) >= _maxItemQuantity)
        {
            _inputField.text = _maxItemQuantity.ToString();
        }

        _valSlider.value = int.Parse(_inputField.text);

        _quantitySelected = (int)Mathf.Floor(_valSlider.value);
    }

    // slider functions
    public void UpdateWithSlider()
    {
        _valSlider.value = (int)Mathf.Floor(_valSlider.value);

        if (_valSlider.value >= _maxItemQuantity)
        {
            _valSlider.value = _maxItemQuantity;
        }

        _inputField.text = ((int)Mathf.Floor(_valSlider.value)).ToString();
        _quantitySelected = (int)Mathf.Floor(_valSlider.value);
    }

    // Button functions
    public void IncrementQuantity()
    {
        _valSlider.value += 1;
        _inputField.text = ((int)Mathf.Floor(_valSlider.value)).ToString();
        _quantitySelected = (int)Mathf.Floor(_valSlider.value);
    }

    public void DecrementQuantity()
    {
        _valSlider.value -= 1;
        _inputField.text = ((int)Mathf.Floor(_valSlider.value)).ToString();
        _quantitySelected = (int)Mathf.Floor(_valSlider.value);
    }
}
