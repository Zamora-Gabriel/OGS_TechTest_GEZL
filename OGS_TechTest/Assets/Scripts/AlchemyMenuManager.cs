using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class AlchemyMenuManager : MonoBehaviour
{
	[SerializeField] public int numberOfOptions = 4;
	[SerializeField] public int numberOfFamilies = 6;

	[Header("Option Selection Events")]
	[SerializeField] UnityEvent fusionEvent;
	[SerializeField] UnityEvent discoverEvent;
	[SerializeField] UnityEvent forgeEvent;
	[SerializeField] UnityEvent mixEvent;

	// Place the wheel item manager's function to change color selection wheel
	[Header("Family Selected Event")]
	[SerializeField] UnityEvent<SELECTEDFAMILY> familyEvent;

	// Select the correct trade table for the item selected
	[Header("Item Event")]
	[SerializeField] UnityEvent<SELECTEDITEM> itemEvent;

	[Header("Translator Objects")]
	[SerializeField] GameObject msgDisplay;
	[SerializeField] TranslatorScript translator;

	// Enumerators for selected options and families
	private SELECTEDOPTION optionSelected = SELECTEDOPTION.FORGE;
	private SELECTEDFAMILY familySelected = SELECTEDFAMILY.RED;
	private SELECTEDITEM itemSelected = SELECTEDITEM.PURERED;
	
	// For the current index in the wheel of items
	private int selectedItemIndex;

	// Flags for states
	private bool isOptionSelected = false;
	private bool isFamilySelected = false;

	// Getters
	public SELECTEDOPTION OptionSelected => optionSelected;
	public SELECTEDFAMILY FamilySelected => familySelected;
	public SELECTEDITEM ItemSelected => itemSelected;
	public int SelectedItemIndex => selectedItemIndex;
	public bool IsOptionSelected => isOptionSelected;
	public bool IsFamilySelected => isFamilySelected;

	// Singleton for the alchemy menu manager
	public static AlchemyMenuManager shared;
	public static AlchemyMenuManager Instance
	{
		get
		{
			if (!shared)
			{
				AlchemyMenuManager[] managers = GameObject.FindObjectsOfType<AlchemyMenuManager>();
				if (managers != null)
				{
					if (managers.Length == 1)
					{
						shared = managers[0];
						return managers[0];
					}
				}

				GameObject go = new GameObject("InventoryManager", typeof(AlchemyMenuManager));
				shared = go.GetComponent<AlchemyMenuManager>();

				DontDestroyOnLoad(shared.gameObject);
			}
			return shared;
		}
		set
		{
			shared = value as AlchemyMenuManager;
		}
	}


	/* Option Related Functions*/

	// Setter for options
	public void SetOption(SELECTEDOPTION newOption)
    {
		optionSelected = newOption;
		UpdateOptionUI();
    }

	// Check Option selected and invoke corresponding event
	private void UpdateOptionUI()
    {
        switch (optionSelected)
        {
			case SELECTEDOPTION.FORGE:
				forgeEvent.Invoke();
				break;
			case SELECTEDOPTION.DISCOVER:
				discoverEvent.Invoke();
				break;
			case SELECTEDOPTION.FUSION:
				fusionEvent.Invoke();
				break;
			default:
				mixEvent.Invoke();
				break;
		}

		// Call the function to change the description and titles
		translator.MessageChanger();
	}

	// Family related functions
	public void SetFamily(SELECTEDFAMILY newFamily)
	{
		familySelected = newFamily;
		UpdateFamilyUI();
	}


	// Check family selected and invoke corresponding event
	private void UpdateFamilyUI()
	{
		// invoke the family selected event
		familyEvent.Invoke(FamilySelected);
	}


	// item related functions
	public void SetItem(SELECTEDITEM newItem, int itemIndex)
	{
		itemSelected = newItem;
		selectedItemIndex = itemIndex;
		UpdateItemUI();
	}

	// Check Option selected and invoke corresponding event
	private void UpdateItemUI()
	{
		// invoke the item event
		itemEvent.Invoke(ItemSelected);

		// Call the function to change the description and titles
		translator.MessageChanger();
	}

	/*public void Toast()
	{
		// Prevent toast coroutine spam
		StopAllCoroutines();
		toastDisplay.SetActive(false);

		StartCoroutine(ToastCoroutine());
	}

	IEnumerator ToastCoroutine()
	{
		toastDisplay.SetActive(true);
		yield return new WaitForSeconds(toastDisplayTime * 2);
		toastDisplay.GetComponent<Animator>().SetTrigger("Disappear");
		yield return new WaitForSeconds(toastDisplayTime);
		toastDisplay.SetActive(false);
	}*/

	public void ToggleOptionSelectedFlag(bool option)
    {
		isOptionSelected = option;
	}

	public void ToggleFamilySelectedFlag(bool option)
    {
		isFamilySelected = option;
	} 
}
