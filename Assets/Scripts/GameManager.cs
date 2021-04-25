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
		//GameObject.Find("BuildingsListPanel").GetComponent<CanvasGroup>().alpha = 0;
		//GameObject.Find("BuildingsListPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
		storageButton.onClick.AddListener(OpenStoragePanel);
		craftingButton.onClick.AddListener(OpenCraftingPanel);

		detailsButton.onClick.AddListener(OpenDetailsPanel);
		productionButton.onClick.AddListener(OpenProductionPanel);
		upgradesButton.onClick.AddListener(OpenUpgradesPanel);
		//GameObject.Find("StoragePanel").SetActive(true);

		GameObject.Find("CraftingPanel").GetComponent<CanvasGroup>().transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("StoragePanel").GetComponent<CanvasGroup>().transform.localScale = new Vector3(0, 0, 0);

		GameObject.Find("ProductionPanel").GetComponent<CanvasGroup>().transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("UpgradesPanel").GetComponent<CanvasGroup>().transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("BuildingPanel").GetComponent<CanvasGroup>().transform.localScale = new Vector3(0, 0, 0);

		Currency = 75000;
	}

	public void OpenCraftingPanel()
	{
		//GameObject.Find("BuildingsListPanel").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find("CraftingPanel").GetComponent<CanvasGroup>().transform.localScale = new Vector3(1, 1, 1);
		HideUI();
	}
	
	public void OpenStoragePanel()
	{
		//GameObject.Find("BuildingsListPanel").GetComponent<CanvasGroup>().alpha = 0;
		//GameObject.Find("CraftingPanel").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find("StoragePanel").GetComponent<CanvasGroup>().transform.localScale = new Vector3(1, 1, 1);
		//GameObject.Find("BuildingPanel").GetComponent<CanvasGroup>().alpha = 0;
		HideUI();

	}
	
	public void OpenDetailsPanel()
	{
		GameObject.Find("DetailsPanel").GetComponent<CanvasGroup>().transform.localScale = new Vector3(1, 1, 1);
		GameObject.Find("ProductionPanel").GetComponent<CanvasGroup>().transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("UpgradesPanel").GetComponent<CanvasGroup>().transform.localScale = new Vector3(0, 0, 0);
		HideUI();
	}
	
	public void OpenProductionPanel()
	{
		GameObject.Find("DetailsPanel").GetComponent<CanvasGroup>().transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("ProductionPanel").GetComponent<CanvasGroup>().transform.localScale = new Vector3(1, 1, 1);
		GameObject.Find("UpgradesPanel").GetComponent<CanvasGroup>().transform.localScale = new Vector3(0, 0, 0);
		HideUI();
	}
	
	public void OpenUpgradesPanel()
	{
		GameObject.Find("DetailsPanel").GetComponent<CanvasGroup>().transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("ProductionPanel").GetComponent<CanvasGroup>().transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("UpgradesPanel").GetComponent<CanvasGroup>().transform.localScale = new Vector3(1, 1, 1);
		HideUI();
	}

	private void HideUI()
  {
		GameObject.Find("UIButtons").GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -150, 0);
		GameObject.Find("CurrenciesBar").GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 150, 0);
	}

	
	
	public void OnCurrencyChanged()
	{
		if (Changed != null)
		{
			Changed();
		}
	}
}
