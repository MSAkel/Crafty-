using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Building : MonoBehaviour {
	[SerializeField]
	private int generatedGold;

	[SerializeField]
	private float productionRate;

	[SerializeField]
	private int maxWorkers;

	[SerializeField]
	private int workerCost;

	[SerializeField]
	private Image buildingIcon;

	public bool didUpgrade = false;
	public int Level { get; private set; }
	public int CurrentWorkers { get; private set; }
	public BuildingUpgrade[] Upgrades { get; protected set; }

	private CraftingList craftingList;
	private Item[] items;

	public BuildingUpgrade NextUpgrade
	{
		get
		{
			if(Upgrades.Length > Level - 1)
			{
				return Upgrades[Level - 1];
			}

			return null;
		}
	}

	private void Awake()
	{
		craftingList = FindObjectOfType<CraftingList>();
		items = Resources.LoadAll<Item>("Items");
		// Event listener for clicking on the building icon, sets the selected building
		// to the current instance
		GetComponent<Button>().onClick.AddListener(onViewBuilding);
		Level = 1;
	}

	// Pass this instance to the building manager
	private void onViewBuilding()
	{
		BuildingManager.Instance.SelectBuilding(this);
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public virtual Sprite GetBuildingIcon()
	{
		return buildingIcon.sprite;
	}

	
	public virtual string GetStats()
	{
		if(NextUpgrade != null)
		{
			return string.Format("\nLevel: {0} \nGold/s: {1} <color=#00ff00ff> +{3}</color>\nMaximum Workers: {2} <color=#00ff00ff>+{4}</color>", Level, generatedGold, maxWorkers, NextUpgrade.GoldRate, NextUpgrade.MaxWorkers);
		}
		return string.Format("Level: {0} \nGold/s: {1} \nMaximum Workers: {2}", Level, generatedGold, maxWorkers);
	}

	public virtual string GetWorkers()
	{
		return string.Format("Workers: {0}/{1}", CurrentWorkers, maxWorkers);
	}

	public virtual string GetWorkersCost()
	{
		return string.Format("{0}", workerCost);
	}


	public virtual void Hire()
	{	
		if(CurrentWorkers < maxWorkers && workerCost <= GameManager.Instance.Currency)
		{
			GameManager.Instance.Currency -= workerCost;
			workerCost = workerCost * 3;
			CurrentWorkers++;
			BuildingManager.Instance.UpdateBuildingPanel();
		}
	}

	public void GenerateGold()
	{
		GameManager.Instance.Currency += (generatedGold * CurrentWorkers);
	}

	public void Select()
	{
		BuildingManager.Instance.UpdateBuildingPanel();
	}

	public virtual void Upgrade()
	{
		GameManager.Instance.Currency -= NextUpgrade.Price;
		this.generatedGold = NextUpgrade.GoldRate;
		this.maxWorkers = NextUpgrade.MaxWorkers;
		this.productionRate = NextUpgrade.ProductionRate;
		Level++;
		BuildingManager.Instance.UpdateBuildingPanel();
		didUpgrade = true;
	}

	public virtual void ProduceItem(Item item)
	{
		item.count++;
	}

	public virtual void populateItems()
	{
		foreach (Item item in items)
		{
			if(item.producer == this.name && item.tier == Level && item.initial)
			{
				Storage.Instance.AddItem(item);
				Production.Instance.AddItem(item);
			}
		}
		craftingList.RefreshDisplay();
	}
}
