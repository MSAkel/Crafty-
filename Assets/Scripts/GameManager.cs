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
		GameObject.Find("BuildingsListPanel").transform.localScale = new Vector3(0, 0, 0);

		storageButton.onClick.AddListener(openStoragePanel);
		GameObject.Find("StoragePanel").transform.localScale = new Vector3(0, 0, 0);

		craftingButton.onClick.AddListener(openCraftingPanel);
		GameObject.Find("CraftingPanel").transform.localScale = new Vector3(0, 0, 0);

		detailsButton.onClick.AddListener(openDetailsPanel);
		productionButton.onClick.AddListener(openProductionPanel);
		upgradesButton.onClick.AddListener(openUpgradesPanel);
		GameObject.Find("ProductionPanel").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("UpgradesPanel").transform.localScale = new Vector3(0, 0, 0);

		Currency = 75000;
	}

	public void openBuildPanel()
	{
		GameObject.Find("BuildingsListPanel").transform.localScale = new Vector3(1, 1, 1);
	}
	
	public void closeBuildPanel()
	{
		GameObject.Find("BuildingsListPanel").transform.localScale = new Vector3(0, 0, 0);
	}

	public void openCraftingPanel()
	{
		GameObject.Find("CraftingPanel").transform.localScale = new Vector3(1, 1, 1);
	}
	
	public void closeCraftingPanel()
	{
		GameObject.Find("CraftingPanel").transform.localScale = new Vector3(0, 0, 0);
	}

	public void openStoragePanel()
	{
		GameObject.Find("StoragePanel").transform.localScale = new Vector3(1, 1, 1);
	}
	
	public void closeStoragePanel()
	{
		GameObject.Find("StoragePanel").transform.localScale = new Vector3(0, 0, 0);
	}

	public void openDetailsPanel()
	{
		// GameObject.Find("DetailsPanel").SetActive(true);
		// GameObject.Find("ProductionPanel").SetActive(false);
		// GameObject.Find("UpgradesPanel").SetActive(false);
		GameObject.Find("DetailsPanel").transform.localScale = new Vector3(1, 1, 1);
		GameObject.Find("ProductionPanel").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("UpgradesPanel").transform.localScale = new Vector3(0, 0, 0);

	}
	
	public void openProductionPanel()
	{
		// GameObject.Find("ProductionPanel").SetActive(true);
		// GameObject.Find("DetailsPanel").SetActive(false);
		// GameObject.Find("UpgradesPanel").SetActive(false);
		GameObject.Find("DetailsPanel").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("ProductionPanel").transform.localScale = new Vector3(1, 1, 1);
		GameObject.Find("UpgradesPanel").transform.localScale = new Vector3(0, 0, 0);
	}
	
	public void openUpgradesPanel()
	{
		// GameObject.Find("UpgradesPanel").SetActive(true);
		// GameObject.Find("DetailsPanel").SetActive(false);
		// GameObject.Find("ProductionPanel").SetActive(false);
		GameObject.Find("DetailsPanel").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("ProductionPanel").transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("UpgradesPanel").transform.localScale = new Vector3(1, 1, 1);
	}
	
	
	public void OnCurrencyChanged()
	{
		if (Changed != null)
		{
			Changed();
		}
	}
}
