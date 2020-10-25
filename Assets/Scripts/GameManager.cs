using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Delegate for currency change
public delegate void CurrencyChanged();

public class GameManager : Singleton<GameManager> {

	//An event which is triggered when the currency changes
	public event CurrencyChanged Changed;

	private int currency;
	[SerializeField]
	private Text currencyText;

	[SerializeField]
	private Button buildButton;

	[SerializeField]
	private Button craftingButton;

	[SerializeField]
	private Button storageButton;
	
	[SerializeField]
	private Button detailsButton;

	[SerializeField]
	private Button productionButton;

	[SerializeField]
	private Button upgradesButton;

	public int Currency
	{
		get{return currency;}
		set
		{
			//Sets currency value and checks for change in value
			currency = value;
			this.currencyText.text = value.ToString();

			OnCurrencyChanged();
		}
	}

	void Start ()
	{
		buildButton.onClick.AddListener(openBuildPanel);
		GameObject.Find("BuildingsListPanel").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find("BuildingsListPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;

		craftingButton.onClick.AddListener(openCraftingPanel);
		GameObject.Find("CraftingPanel").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find("CraftingPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;

		storageButton.onClick.AddListener(openStoragePanel);
		GameObject.Find("StoragePanel").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find("StoragePanel").GetComponent<CanvasGroup>().blocksRaycasts = false;

		GameObject.Find("BuildingPanel").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find("BuildingPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;

		detailsButton.onClick.AddListener(openDetailsPanel);
		productionButton.onClick.AddListener(openProductionPanel);
		upgradesButton.onClick.AddListener(openUpgradesPanel);

		GameObject.Find("ProductionPanel").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find("UpgradesPanel").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find("ProductionPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
		GameObject.Find("UpgradesPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;

		Currency = 75000;
	}

	public void openBuildPanel()
	{
		//GameObject.Find("BuildingsListPanel").transform.localScale = new Vector3(1, 1, 1);
		GameObject.Find("BuildingsListPanel").GetComponent<CanvasGroup>().alpha = 1;
		GameObject.Find("CraftingPanel").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find("StoragePanel").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find("BuildingPanel").GetComponent<CanvasGroup>().alpha = 0;

		GameObject.Find("BuildingPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
		GameObject.Find("BuildingsListPanel").GetComponent<CanvasGroup>().blocksRaycasts = true;
		GameObject.Find("CraftingPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
		GameObject.Find("StoragePanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	
	public void closeBuildPanel()
	{
		GameObject.Find("BuildingsListPanel").GetComponent<CanvasGroup>().alpha = 0;
		//GameObject.Find("BuildingsListPanel").transform.localScale = new Vector3(0, 0, 0);
	}

	public void openCraftingPanel()
	{
		GameObject.Find("BuildingsListPanel").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find("CraftingPanel").GetComponent<CanvasGroup>().alpha = 1;
		GameObject.Find("StoragePanel").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find("BuildingPanel").GetComponent<CanvasGroup>().alpha = 0;

		GameObject.Find("BuildingPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
		GameObject.Find("BuildingsListPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
		GameObject.Find("CraftingPanel").GetComponent<CanvasGroup>().blocksRaycasts = true;
		GameObject.Find("StoragePanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	
	public void closeCraftingPanel()
	{
		GameObject.Find("CraftingPanel").GetComponent<CanvasGroup>().alpha = 0;
		//GameObject.Find("CraftingPanel").transform.localScale = new Vector3(0, 0, 0);
	}

	public void openStoragePanel()
	{
		GameObject.Find("BuildingsListPanel").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find("CraftingPanel").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find("StoragePanel").GetComponent<CanvasGroup>().alpha = 1;
		GameObject.Find("BuildingPanel").GetComponent<CanvasGroup>().alpha = 0;

		GameObject.Find("BuildingPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
		GameObject.Find("BuildingsListPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
		GameObject.Find("CraftingPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
		GameObject.Find("StoragePanel").GetComponent<CanvasGroup>().blocksRaycasts = true;
	}
	
	public void closeStoragePanel()
	{
		GameObject.Find("StoragePanel").GetComponent<CanvasGroup>().alpha = 0;
	}

	public void openDetailsPanel()
	{
		GameObject.Find("DetailsPanel").GetComponent<CanvasGroup>().alpha = 1;
		GameObject.Find("ProductionPanel").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find("UpgradesPanel").GetComponent<CanvasGroup>().alpha = 0;

		GameObject.Find("DetailsPanel").GetComponent<CanvasGroup>().blocksRaycasts = true;
		GameObject.Find("ProductionPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
		GameObject.Find("UpgradesPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;

	}
	
	public void openProductionPanel()
	{
		GameObject.Find("DetailsPanel").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find("ProductionPanel").GetComponent<CanvasGroup>().alpha = 1;
		GameObject.Find("UpgradesPanel").GetComponent<CanvasGroup>().alpha = 0;

		GameObject.Find("DetailsPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
		GameObject.Find("ProductionPanel").GetComponent<CanvasGroup>().blocksRaycasts = true;
		GameObject.Find("UpgradesPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	
	public void openUpgradesPanel()
	{
		GameObject.Find("DetailsPanel").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find("ProductionPanel").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find("UpgradesPanel").GetComponent<CanvasGroup>().alpha = 1;

		GameObject.Find("DetailsPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
		GameObject.Find("ProductionPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
		GameObject.Find("UpgradesPanel").GetComponent<CanvasGroup>().blocksRaycasts = true;
	}
	
	
	public void OnCurrencyChanged()
	{
		if (Changed != null)
		{
			Changed();
		}
	}
}
