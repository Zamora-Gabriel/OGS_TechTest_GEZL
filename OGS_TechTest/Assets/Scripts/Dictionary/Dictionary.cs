using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Dictionary
{
    public static LANGUAGE activeLanguage = LANGUAGE.ESP;

    // Spanish and english lists
    public static List<string> englishAlchTexts = new List<string>
    {
        // Fusion
        "Fusion Particles of All of each family to create white " +
        "PoA that will be of utility in different sections. " +
        "Turn the wheel to select other option and keep the center button pressed to confirm",
        // Discover
        "Discover the exact mix to create runes in the alchemy laboratory." +
        " Turn the wheel to select other option and keep the center button pressed to confirm",
        // Forge
        "The science to upgrade your power archives to level them up and make them more powerful. " +
        "Turn the wheel to select other option and keep the center button pressed to confirm",
        // Mezclar
        "Mix PoA RAVCAM in exact proporcions to create runes. " +
        "Turn the wheel to select other option and keep the center button pressed to confirm"
    };

    public static List<string> spanishAlchTexts = new List<string>
    {
        // Fusionar
        "Fusiona Part�culas del Todo de todas las familias para crear PdT " +
        "blancas que te ser�n de utilidad en las diferentes secciones. " +
        "Gira la rueda para seleccionar otra opci�n y mant�n presionado el " +
        "bot�n grande para confirmar.",
        // Descubrir
        "Descubre la mezcla exacta para crear runas en el laboratorio de alquimia." +
        " Gira la rueda para seleccionar otra opci�n y usa " +
        "los botones de abajo para continuar",
        // Forjar
        "La ciencia de mejorar tus archivos de poder para subirlos de nivel y hacerlos m�s poderosos. " +
        "Gira la rueda para seleccionar otra opci�n " +
        "y usa los botones de abajo para continuar",
        // Mezclar
        "Mezcla PdT RAVCAM en proporciones exactas para crear runas. " +
        "Gira la rueda para seleccionar otra opci�n " +
        "y usa los botones de abajo para continuar"
    };

    public static List<string> alchemyOptionsEng = new List<string>
    {
        "Fusion",
        "Discover",
        "Forge",
        "Mix"
    };

    public static List<string> alchemyOptionsEsp = new List<string>
    {
        "Fusionar",
        "Descubrir",
        "Forjar",
        "Mezclar"
    };

    public static List<string> itemResultsEng = new List<string>
    {
        "White Particles",
        "Pure Red Rune",
        "Crimson Rune",
        "Pure Yellow Rune",
        "Orange Rune",
        "Emerald Rune",
        "Turquoise Rune",
        "Deep Blue Rune",
        "Purple Rune"
    };

    public static List<string> itemResultsEsp = new List<string>
    {
        "Part�culas Blancas",
        "Runa Roja Pura",
        "Runa Carmes�",
        "Runa Amarilla Pura",
        "Runa Naranja",
        "Runa Esmeralda",
        "Runa Turquesa",
        "Runa Azul Profundo",
        "Runa Morada"
    };

    public static Dictionary<string, string> wordDictionary = new Dictionary<string, string>()
    {
        ["quantityEng"] = "Quantity",
        ["quantityEsp"] = "Cantidad",
    };
}
