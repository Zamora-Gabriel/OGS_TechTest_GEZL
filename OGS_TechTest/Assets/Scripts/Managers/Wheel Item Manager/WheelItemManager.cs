using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WheelItemManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _innerWheelItems = new GameObject[6];
    [SerializeField] private GameObject[] _midWheelItems = new GameObject[6];

    // 0 Red event
    // 1 Yellow event
    // 2 Green event
    // 3 Cyan event
    // 4 Blue event
    // 5 Magenta event
    public void UpdateItemUI(SELECTEDFAMILY familySelection)
    {
        switch (familySelection)
        {
            case SELECTEDFAMILY.RED:
                UIObjectDeactivator(0);
                break;
            case SELECTEDFAMILY.YELLOW:
                UIObjectDeactivator(1);
                break;
            case SELECTEDFAMILY.GREEN:
                UIObjectDeactivator(2);
                break;
            case SELECTEDFAMILY.CYAN:
                UIObjectDeactivator(3);
                break;
            case SELECTEDFAMILY.BLUE:
                UIObjectDeactivator(4);
                break;
            default:
                UIObjectDeactivator(5);
                break;
        }
    }

    // Activate only selected family's items
    private void UIObjectDeactivator(int activeIndex)
    {
        for(int i=0; i < _innerWheelItems.Length; i++) 
        {
            if(i == activeIndex)
            {
                _innerWheelItems[i].SetActive(true);
                _midWheelItems[i].SetActive(true);
            }
            else
            {
                _innerWheelItems[i].SetActive(false);
                _midWheelItems[i].SetActive(false);
            }
        }
    }
}
