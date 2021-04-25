using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : Singleton<BuildingManager>
{
  [SerializeField]
	private GameObject buildingPanel;

	public Building selectedBuilding;

	[SerializeField]
	private Text buildingName;

	[SerializeField]
	private Image buildingIcon;

	//[SerializeField]
	//private Text levelText;

	[SerializeField]
	private Text statsText;

  [SerializeField]
	private Text workersText;

  [SerializeField]
	private Text workersCost;

	[SerializeField]
	private Button upgradeButton;

	[SerializeField]
	private Button hireButton;

	private void Start()
  {
		upgradeButton.onClick.AddListener(UpgradeBuilding);
		hireButton.onClick.AddListener(HireWorker);
	}

	//public void CloseBuildPanel()
	//{
	//	GameObject.Find("BuildingPanel").GetComponent<CanvasGroup>().alpha = 0;
	//	GameObject.Find("BuildingPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;

	//	GameObject.Find("DetailsPanel").GetComponent<CanvasGroup>().alpha = 0;
	//	GameObject.Find("ProductionPanel").GetComponent<CanvasGroup>().alpha = 0;
	//	GameObject.Find("UpgradesPanel").GetComponent<CanvasGroup>().alpha = 0;

	//	GameObject.Find("DetailsPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
	//	GameObject.Find("ProductionPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;
	//	GameObject.Find("UpgradesPanel").GetComponent<CanvasGroup>().blocksRaycasts = false;

	//	GameObject[] prodItems = GameObject.FindGameObjectsWithTag("ProductionItem");

	//	for (var i = 0; i < prodItems.Length; i++)
	//	{
	//		Destroy(prodItems[i]);
	//	}
	//}

	public void SelectBuilding(Building building)
	{
		// Remove any existing items within the production tab
		GameObject[] prodItems = GameObject.FindGameObjectsWithTag("ProductionItem");
		for (var i = 0; i < prodItems.Length; i++)
		{
			Destroy(prodItems[i]);
		}

		// commented out as it was selecting twice
		//if (selectedBuilding != null)
		//{
		//    //Select the building
		//    selectedBuilding.Select();
		//}

		//Sets the selected building
		selectedBuilding = building;
    selectedBuilding.Select();

		buildingPanel.transform.localScale = new Vector3(1, 1, 1);
		//GameObject.Find("BuildingPanel").GetComponent<CanvasGroup>().alpha = 1;
		//GameObject.Find("BuildingPanel").GetComponent<CanvasGroup>().blocksRaycasts = true;
		GameObject.Find("DetailsPanel").GetComponent<CanvasGroup>().transform.localScale = new Vector3(1, 1, 1);
		GameObject.Find("ProductionPanel").GetComponent<CanvasGroup>().transform.localScale = new Vector3(0, 0, 0);
		GameObject.Find("UpgradesPanel").GetComponent<CanvasGroup>().transform.localScale = new Vector3(0, 0, 0);

	}

	public void DeselectBuilding()
	{
		// commented out as seems unnecessary
		//if (selectedBuilding != null)
		//{
		//	//Select the building
		//	selectedBuilding.Select();
		//}

		buildingPanel.transform.localScale = new Vector3(0, 0, 0);
		//deselects selected building
		selectedBuilding = null;
	}



  public void UpgradeBuilding()
	{
		if(selectedBuilding != null)
		{
			if(selectedBuilding.Level <= selectedBuilding.Upgrades.Length && GameManager.Instance.Currency >= selectedBuilding.NextUpgrade.cost)
			{
				selectedBuilding.Upgrade();
			}
		}
	}

  //Script for hire button
	public void HireWorker()
	{
		if(selectedBuilding != null)
		{
			selectedBuilding.Hire();
		}
	}
	
    // Updates the content on the building panel to reflect the currerntly selected building
   public void UpdateBuildingPanel()
	{
		if (selectedBuilding != null)
		{
			buildingName.text = selectedBuilding.name;
			SetDetailsContent(selectedBuilding.GetBuildingIcon(), selectedBuilding.GetStats(), selectedBuilding.GetWorkers(), selectedBuilding.GetWorkersCost());
			SetProductionContent();
			//buildingIcon.sprite = selectedBuilding.GetBuildingIcon();
			//statsText.text = selectedBuilding.GetStats();
			//workersText.text = selectedBuilding.GetWorkers();
			//this.workersCost.text = selectedBuilding.GetWorkersCost();
		}
	}

   // Sets the content for the building panel
   public void SetDetailsContent(Sprite icon ,string stats, string currentWorkers, string workersCost)
	 {
			buildingIcon.sprite = icon;
			statsText.text = stats;
	 		workersText.text = currentWorkers;
			this.workersCost.text = workersCost;
	 }

	// Populates the items in the building production panel
	public void SetProductionContent()
  {
		foreach(Item item in Storage.Instance.unlockedItems)
    {
			if (item.producer == selectedBuilding.name) { 


			Production.Instance.AddItem(item);
      }
    }
  }

}
