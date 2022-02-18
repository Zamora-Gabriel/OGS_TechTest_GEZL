using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WheelEvent : MonoBehaviour
{
    // Scipt for all events ocurred by clicking inside or outside button
    [SerializeField] private UnityEvent _wheelEvent;

    public void FireEvent()
    {
        _wheelEvent.Invoke();
    }
}
