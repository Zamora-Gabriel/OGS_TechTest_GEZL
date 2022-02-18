using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeTableManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _tradeItemTables;

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
}
