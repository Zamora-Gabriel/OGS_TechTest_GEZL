using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Dictionary
{
    public static LANGUAGE activeLanguage = LANGUAGE.ESP;

    public static void ResetLanguage()
    {
        activeLanguage = LANGUAGE.ESP;
    }
}
