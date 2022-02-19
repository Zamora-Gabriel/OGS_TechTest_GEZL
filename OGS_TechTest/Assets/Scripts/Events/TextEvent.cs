using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TextEvent : MonoBehaviour
{
    public static TextEvent instance;

    public event Action onChangedQuantity;

    public event Action onChangedMatNumber;

    private void Awake()
    {
        instance = this;
    }

    public void ChangedQuantity()
    {
        // Event Fired
        if (onChangedQuantity == null)
        {
            return;
        }

        onChangedQuantity();
    }

    public void ChangedMaterialNumber()
    {
        // Event Fired
        if (onChangedMatNumber == null)
        {
            return;
        }

        onChangedMatNumber();
    }
}
