using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemTextManager : MonoBehaviour
{
	/*[SerializeField] private TextMeshProUGUI[] _whiteMaterialTexts;
	[SerializeField] private TextMeshProUGUI[] _redMaterialTexts;
	[SerializeField] private TextMeshProUGUI[] _yellowMaterialTexts;
	[SerializeField] private TextMeshProUGUI[] _greenMaterialTexts;
	[SerializeField] private TextMeshProUGUI[] _cyanMaterialTexts;
	[SerializeField] private TextMeshProUGUI[] _blueMaterialTexts;
	[SerializeField] private TextMeshProUGUI[] _magentaMaterialTexts;*/

	// Singleton for the item text manager

	private int itemNumberToMake;
	private int[] materialNumberRequired = new int[7];
	private int[] materialNumberToConsume = new int[7];


	public int ItemNumToMake => itemNumberToMake;
	public int[] MaterialNumToConsume => materialNumberToConsume;
	public int[] MaterialNumRequired => materialNumberRequired;

	public static ItemTextManager shared;
	public static ItemTextManager Instance
	{
		get
		{
			if (!shared)
			{
				ItemTextManager[] managers = GameObject.FindObjectsOfType<ItemTextManager>();
				if (managers != null)
				{
					if (managers.Length == 1)
					{
						shared = managers[0];
						return managers[0];
					}
				}

				GameObject go = new GameObject("InventoryManager", typeof(ItemTextManager));
				shared = go.GetComponent<ItemTextManager>();

				DontDestroyOnLoad(shared.gameObject);
			}
			return shared;
		}
		set
		{
			shared = value as ItemTextManager;
		}
	}

	// Setter for item number to make
	public void SetItemQuantity(int number)
	{
		itemNumberToMake = number;
	}

	// Setter for the materials to consume
	public void SetMatToConsume(int[] matToConsume)
    {
		// Set the materials to consume
		materialNumberToConsume = matToConsume;
	}

	// Seter for the materials to consume
	public void SetMatRequired(int[] matRequired)
	{
		// Set the materials to consume
		materialNumberRequired = matRequired;
	}
}
