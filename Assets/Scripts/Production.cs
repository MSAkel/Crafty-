using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Production : Singleton<Production>
{
  [SerializeField]
	private GameObject itemPrefab;

	[SerializeField]
	private Transform productionPanel;

  private void Start() 
  {
    //Building building = BuildingManager.Instance.selectedBuilding;
    // List<Item> items = Storage.Instance.unlockedItems;
    // foreach(Item item in items)
    // {
    //   Debug.Log(item.name);
    //   AddItem(item);
    // }
  }

  public void AddItem(Item item)
	{
		//unlockedItems.Add(item);
		GameObject itemObj = Instantiate(itemPrefab, productionPanel);
		ProductionItemDisplay display = itemObj.GetComponent<ProductionItemDisplay>();
		display.Setup(item);
	}
}
