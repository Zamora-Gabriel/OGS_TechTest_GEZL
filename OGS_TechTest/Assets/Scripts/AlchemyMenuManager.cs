using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class AlchemyMenuManager : MonoBehaviour
{
	[SerializeField] public int numberOfOptions = 4;
	[SerializeField] public int numberOfFamilies = 6;
	[SerializeField] public GameObject rightClickMenu;


	[Header("Option Selection Events")]
	[SerializeField] UnityEvent fusionEvent;
	[SerializeField] UnityEvent discoverEvent;
	[SerializeField] UnityEvent forgeEvent;
	[SerializeField] UnityEvent mixEvent;

	[Header("Family Selected Event")]
	[SerializeField] UnityEvent<SELECTEDFAMILY> familyEvent;

	/*[Header("Button Events")]
	[SerializeField] UnityEvent insideButtonEvent;
	[SerializeField] UnityEvent outsideButtonEvent;
	[SerializeField] UnityEvent confirmButtonEvent;*/

	[Header("Toast Variables")]
	[SerializeField] GameObject toastDisplay;
	[SerializeField] TextMeshProUGUI toastTMP;
	[SerializeField] float toastDisplayTime = 1f;

	// Enumerators for selected options and families
	private SELECTEDOPTION optionSelected = SELECTEDOPTION.FORGE;
	private SELECTEDFAMILY familySelected = SELECTEDFAMILY.RED;

	// Flags for states
	private bool isOptionSelected = false;
	private bool isFamilySelected = false;

	// Getters
	public SELECTEDOPTION OptionSelected => optionSelected;
	public SELECTEDFAMILY FamilySelected => familySelected;
	public bool IsOptionSelected => isOptionSelected;
	public bool IsFamilySelected => isFamilySelected;

	private void Awake()
	{
		Dictionary.ResetLanguage();
	}

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
		switch (familySelected)
		{
			case SELECTEDFAMILY.RED:
				familyEvent.Invoke(FamilySelected);
				break;
			case SELECTEDFAMILY.YELLOW:
				familyEvent.Invoke(FamilySelected);
				break;
			case SELECTEDFAMILY.GREEN:
				familyEvent.Invoke(FamilySelected);
				break;
			case SELECTEDFAMILY.CYAN:
				familyEvent.Invoke(FamilySelected);
				break;
			case SELECTEDFAMILY.BLUE:
				familyEvent.Invoke(FamilySelected);
				break;
			default:
				familyEvent.Invoke(FamilySelected);
				break;
		}
	}

	public void MessageChanger(string msg)
	{
		// Update message of the toast
		toastTMP.text = msg;
	}

	public void Toast()
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
	}

	public void ToggleOptionSelectedFlag(bool option)
    {
		isOptionSelected = option;
	}

	public void ToggleFamilySelectedFlag(bool option)
    {
		isFamilySelected = option;
	} 
}
