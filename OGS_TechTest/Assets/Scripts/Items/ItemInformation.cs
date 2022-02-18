using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInformation : MonoBehaviour
{
    public SELECTEDITEM itemType;

    // Index in the wheel
    [Range(0,5)]
    public int index;
}
