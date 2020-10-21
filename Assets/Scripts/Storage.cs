using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Storage : Singleton<Storage> {
	public List<Item> unlockedItems;

	public int maxStorageCount = 100;

	[SerializeField]
	private GameObject itemPrefab;

	[SerializeField]
	private Transform storagePanel;

	public void AddItem(Item item)
	{
		unlockedItems.Add(item);
		GameObject itemObj = Instantiate(itemPrefab, storagePanel);
		StorageItemDisplay display = itemObj.GetComponent<StorageItemDisplay>();
		display.Setup(item);
	}

	public bool HasItem (string itemName)
	{
		foreach (Item item in unlockedItems)
		{
			if(item.name == itemName) {
				return true;
			}
		}
		return false;
	}
}