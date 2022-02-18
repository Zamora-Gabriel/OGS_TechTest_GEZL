using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TradeTableValues
{
    // Trade table conversions


    static int[] materialRequirements = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };

    // Material Index values
    /*
     * 0 - White
     * 1 - Red
     * 2 - Yellow
     * 3 - Green
     * 4 - Cyan
     * 5 - Blue
     * 6 - Magenta
     */
    public static int[] MaterialRequirements(SELECTEDOPTION optionSelected, SELECTEDITEM itemSelected)
    {
        // Return materials required
        if (optionSelected == SELECTEDOPTION.FUSION)
        {
            for(int i = 1; i < materialRequirements.Length-1; i++)
            {
                materialRequirements[i] = 1;
            }
        }

        if (optionSelected == SELECTEDOPTION.MIX)
        {
            for (int i = 0; i < materialRequirements.Length - 1; i++)
            {
                materialRequirements[i] = 0;
            }
            MatRequirementsMix(itemSelected);
        }
        
        return materialRequirements;
    }

    private static void MatRequirementsMix(SELECTEDITEM itemSelected)
    {
        switch (itemSelected)
        {
            case SELECTEDITEM.PURERED:
                // 20 white, 40 red
                materialRequirements[0] = 20;
                materialRequirements[1] = 40;
                break;
            case SELECTEDITEM.CRIMSON:
                // 20 white, 20 red, 10 yellow, 10 green
                materialRequirements[0] = 20;
                materialRequirements[1] = 20;
                materialRequirements[2] = 10;
                materialRequirements[3] = 10;
                break;
            case SELECTEDITEM.PUREYELLOW:
                // 20 white, 40 yellow
                materialRequirements[0] = 20;
                materialRequirements[2] = 40;
                break;
            case SELECTEDITEM.ORANGE:
                // 20 white, 20 red, 20 yellow
                materialRequirements[0] = 20;
                materialRequirements[1] = 20;
                materialRequirements[2] = 20;
                break;
            case SELECTEDITEM.EMERALD:
                // 20 white, 30 green, 10 cyan
                materialRequirements[0] = 20;
                materialRequirements[3] = 30;
                materialRequirements[4] = 10;
                break;
            case SELECTEDITEM.TURQUOISE:
                // 20 white, 10 green, 30 cyan
                materialRequirements[0] = 20;
                materialRequirements[3] = 10;
                materialRequirements[4] = 30;
                break;
            case SELECTEDITEM.DEEPBLUE:
                // 20 white, 30 blue, 10 magenta
                materialRequirements[0] = 20;
                materialRequirements[5] = 30;
                materialRequirements[6] = 10;
                break;
            case SELECTEDITEM.PURPLE:
                // 20 white, 10 blue, 30 magenta
                materialRequirements[0] = 20;
                materialRequirements[5] = 10;
                materialRequirements[6] = 30;
                break;
            default:
                break;
        }
    }
}
