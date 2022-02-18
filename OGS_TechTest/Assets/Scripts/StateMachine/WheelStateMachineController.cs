using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WheelStateMachineController : MonoBehaviour
{
    [SerializeField] private WheelEvent[] _insideBttnEvents;
    [SerializeField] private WheelEvent[] _outsideBttnEvents;

    private AlchemyMenuManager manager;

    private void Awake()
    {
        manager = AlchemyMenuManager.Instance;
    }

    public void InsideButtonListener()
    {
        // Confirm option
        if (!manager.IsOptionSelected)
        {
            manager.ToggleOptionSelectedFlag(true);
            _insideBttnEvents[0].FireEvent();
            return;
        }
        
        // Confirm family
        manager.ToggleFamilySelectedFlag(true);    
        _insideBttnEvents[1].FireEvent();
        return;
    }

    public void OutsideButtonListener()
    {
        // Return to option selection
        if (!manager.IsFamilySelected)
        {
            manager.ToggleOptionSelectedFlag(false);
            _outsideBttnEvents[0].FireEvent();
            return;
        }

        // Return to family selection
        manager.ToggleFamilySelectedFlag(false);
        _outsideBttnEvents[1].FireEvent();
        return;
    }
}
