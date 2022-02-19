using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TranslatorScript : MonoBehaviour
{
    [Header("Text Information")]
    [SerializeField] TextMeshProUGUI descriptionTMP;
    [SerializeField] TextMeshProUGUI themeTMP;
    [SerializeField] TextMeshProUGUI bttnTMP;
    [SerializeField] TextMeshProUGUI languageBttnTMP;

    [Header("Text from Wheels")]
    [SerializeField] TextMeshProUGUI[] outerWheelOptionText = new TextMeshProUGUI[4];
    [SerializeField] TextMeshProUGUI[] wheelOptionText = new TextMeshProUGUI[4];

    [Header("Result Text")]
    [SerializeField] TextMeshProUGUI resultNameTMP;
    [SerializeField] TextMeshProUGUI quantityResultTMP;

    private AlchemyMenuManager manager;

    private void Awake()
    {
        manager = AlchemyMenuManager.Instance;
    }

    public void ChangeLang()
    {
        if (Dictionary.activeLanguage == LANGUAGE.ESP)
        {
            Dictionary.activeLanguage = LANGUAGE.ENG;
        }
        else
        {
            Dictionary.activeLanguage = LANGUAGE.ESP;
        }

        MessageChanger();
    }


    public void MessageChanger()
    {
        // Update message according to language and option selected

        WheelOptionTextChanger();

        if (Dictionary.activeLanguage == LANGUAGE.ENG)
        {
            descriptionTMP.text = Dictionary.englishAlchTexts[(int)manager.OptionSelected];
            themeTMP.text = Dictionary.alchemyOptionsEng[(int)manager.OptionSelected];
            bttnTMP.text = Dictionary.alchemyOptionsEng[(int)manager.OptionSelected];
            ItemResultText(true);
            quantityResultTMP.text = $"{Dictionary.wordDictionary["quantityEng"]}: ";
            languageBttnTMP.text = "EN";
            return;
        }

        descriptionTMP.text = Dictionary.spanishAlchTexts[(int)manager.OptionSelected];
        themeTMP.text = Dictionary.alchemyOptionsEsp[(int)manager.OptionSelected];
        bttnTMP.text = Dictionary.alchemyOptionsEsp[(int)manager.OptionSelected]; 
        ItemResultText(false);
        quantityResultTMP.text = $"{Dictionary.wordDictionary["quantityEsp"]}: ";
        languageBttnTMP.text = "ES";
    }

    private void ItemResultText(bool isEnglish)
    {
        List<string> text = Dictionary.itemResultsEsp;
        
        if (isEnglish)
        {
            text = Dictionary.itemResultsEng;
        }

        if (manager.OptionSelected == SELECTEDOPTION.FUSION)
        {
            resultNameTMP.text = text[0];
            return;
        }
        resultNameTMP.text = text[(int)manager.ItemSelected + 1];
        return;
    }

    private void WheelOptionTextChanger()
    {
        // Update each wheel text option
        for (int i = 0; i < wheelOptionText.Length; i++)
        {
            if (Dictionary.activeLanguage == LANGUAGE.ENG)
            {
                outerWheelOptionText[i].text = Dictionary.alchemyOptionsEng[i];
                wheelOptionText[i].text = Dictionary.alchemyOptionsEng[i];
            }
            else
            {
                outerWheelOptionText[i].text = Dictionary.alchemyOptionsEsp[i];
                wheelOptionText[i].text = Dictionary.alchemyOptionsEsp[i];
            }
        }
    }
}
