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
	private Text levelText;

	[SerializeField]
	private Text statsText;

  [SerializeField]
	private Text workersText;

  [SerializeField]
	private Text workersCost;

	// [SerializeField]
	// private Button buildButton;


	void Start()
	{
		//buildButton.onClick.AddListener(openBuildPanel);
		GameObject.Find("BuildingPanel").transform.localScale = new Vector3(0, 0, 0);
	}

	public void closeBuildPanel()
	{
		GameObject.Find("BuildingPanel").transform.localScale = new Vector3(0, 0, 0);
	}



  public void SelectBuilding(Building building)
	{
    if (selectedBuilding != null)
    {
        //Select the building
        selectedBuilding.Select();
    }
    //Sets the selected building
    selectedBuilding = building;
    
    selectedBuilding.Select();

    buildingPanel.transform.localScale = new Vector3(1, 1, 1);
	}

	public void DeselectBuilding()
	{
		if (selectedBuilding != null)
		{
			//Select the building
			selectedBuilding.Select();
		}
		buildingPanel.transform.localScale = new Vector3(0, 0, 0);
		//deselects selected building
		selectedBuilding = null;
	}


    public void UpgradeBuilding()
	{
		if(selectedBuilding != null)
		{
			if(selectedBuilding.Level <= selectedBuilding.Upgrades.Length && GameManager.Instance.Currency >= selectedBuilding.NextUpgrade.Price)
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
	
    // Updates the content on the building panle to reflect the currerntly selected building
    public void UpdateBuildingPanel()
	{
		if(selectedBuilding != null)
		{
			SetPanelText(selectedBuilding.GetStats(), selectedBuilding.GetWorkers(), selectedBuilding.GetWorkersCost());
		}
	}

    // Sets the content for the building panel
    public void SetPanelText(string stats, string currentWorkers, string workersCost)
	{
		statsText.text = stats;
		workersText.text = currentWorkers;
    this.workersCost.text = workersCost;
	}

}
