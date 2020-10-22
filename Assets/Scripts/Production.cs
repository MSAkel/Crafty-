using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Production : Singleton<Production>
{
  [SerializeField]
	private GameObject itemPrefab;

	[SerializeField]
	private Transform productionPanel;

  public void AddItem(Item item)
	{
		GameObject itemObj = Instantiate(itemPrefab, productionPanel);
		ProductionItemDisplay display = itemObj.GetComponent<ProductionItemDisplay>();
		display.Setup(item);
	}
}
