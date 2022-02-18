using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInformation : MonoBehaviour
{
    public SELECTEDITEM itemType;

    // Index in the wheel
    [Range(0,5)]
    public int index;

    // Materials required
    // 0. White
    // 1. Red
    // 2. Yellow
    // 3. Green
    // 4. Cyan
    // 5. Blue
    // 6. Magenta
    public int[] materials = new int[7];
}
