using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

// [System.Serializable]
// public class FarmItemsList
// {
// 	public ScriptableObject item;
// }


public class Farm : Building {

	// [SerializeField]
	// private List<FarmItemsList> FarmList;

	//private float firstTierProduction = 3f;
	//private float secondTierProduction = 7f;
	//private float thirdTierProduction = 15f;
	//private float rareProduction = 120f;
	private float timer;
	private float tierOne;
	private float tierTwo;

	// private Storage storage;
	private CraftingList craftingList;

	//private List<Mineral> mineralsList;

	//[SerializeField]
	//private Text storageText;

	private Item[] items;

	void Start()
	{
		// storage = FindObjectOfType<Storage>();
		craftingList = FindObjectOfType<CraftingList>();

		items = Resources.LoadAll<Item>("Items");

		foreach (Item item in items)
		{
			// Debug.Log(item.producer);
			if(item.producer == "Farm" && item.tier == 1 && item.initial)
			{
		 		// storage.unlockedItem.Add(new UnlockedItem(item.name, 0, item.producer, 1, item.icon));
				// craftingList.RefreshDisplay();
				Storage.Instance.AddItem(item);
				 Production.Instance.AddItem(item);
			}
		}

		craftingList.RefreshDisplay();
	
	//	craftingList = FindObjectOfType<CraftingList>();

		// if(!storage.mineralsList.Any(check=>check.MineralName == "Apple"))
		// {
		// 	storage.mineralsList.Add(new Mineral("Farm", 1, "Apple", 0, FarmList[0].Icon));
		// 	storage.mineralsList.Add(new Mineral("Farm", 1, "Carrot", 0, FarmList[1].Icon));
		// 	craftingList.RefreshDisplay();
		// }



			// storage.items.Add(new Item("Apple", FarmList[0].icon));
			// storage.items.Add(new Item("Carrot", FarmList[1].icon));
		
		//craftingList.RefreshDisplay();
		Upgrades = new BuildingUpgrade[]
		{
			new BuildingUpgrade(2000, 5, 100, 0.5f),
			new BuildingUpgrade(5000, 8, 400, 1f),
		};
	}
	
	void Update () {

		// if (didUpgrade)
		// {
		// 	if (Level == 2 && !storage.mineralsList.Any(check => check.MineralName == "Pumpkin"))
		// 	{
		// 		storage.mineralsList.Add(new Mineral("Farm", 2, "Pumpkin", 0, FarmList[2].Icon));
		// 		//craftingList.RefreshDisplay();
		// 		didUpgrade = false;
		// 	}
		// 	else if (Level == 3 && !storage.mineralsList.Any(check => check.MineralName == ""))
		// 	{
		// 		didUpgrade = false;
		// 	}
		// }

		timer += Time.deltaTime;
		tierOne += Time.deltaTime;
		tierTwo += Time.deltaTime;

		if (timer > 2f)
		{
			GenerateGold();
			timer = 0;
		}

		if(tierOne > 5f)
		{
			//storage.FarmTierOne();
			tierOne = 0;
		}
		
		if(tierTwo > 10f && Level == 2)
		{
		//	storage.FarmTierTwo();
			tierTwo = 0;
		}

	//	produceTierOneItem();
	}


}
