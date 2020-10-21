using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class CraftingList : MonoBehaviour
{
  //public List<UnlockedItem> unlockedItems;
  public Transform contentPanel;
  public CraftingSlot craftingSlot;

  // Used to hold a reference to our object for adding or removing buttons
  public ItemPool itemButtonObjectPool;

  // private Storage storage;
  public Transform slot_1;
  public Transform slot_2;
  public Transform slot_3;

  public GameObject itemPrefab;

  private Recipe[] recipes;

  [SerializeField]
	private Button combineButton;

  [SerializeField]
	private GameObject SuccessPanel;


  [SerializeField]
  private Text unlockedItemName;

  [SerializeField]
  private Image unlockedItemIcon;

  void Start()
  {
    // storage = FindObjectOfType<Storage>();
    recipes = Resources.LoadAll<Recipe>("Recipes");
    combineButton.onClick.AddListener(HandleCombination);
    RefreshDisplay();
  }

  public void RefreshDisplay()
  {
    RemoveItemButtons();
    AddItemButtons();
  }
  /**
  * Go through the items list and see how many items are there
  * Add item buttons as needed for each item
  * Call the setup funtion in ItemButton
  */
  private void AddItemButtons()
  {
    for(int i = 0; i < Storage.Instance.unlockedItems.Count; i++)
    {
      // new item = the item at the current index in unlockedItems
      Item item = Storage.Instance.unlockedItems[i];
      // get an object from the pool and store the reference in the new button
      GameObject newItemButton = itemButtonObjectPool.GetObject();
      // set the parent of the new button to the content panel
      newItemButton.transform.SetParent(contentPanel, false);
	    newItemButton.transform.localScale = new Vector3(1, 1, 1);

      // Get a reference to the item button script
      ItemButton itemButton = newItemButton.GetComponent<ItemButton>();
      // pass item and a reference to this crafting list
      itemButton.Setup(item, this);
    }
  }

  private void RemoveItemButtons()
	{
		while (contentPanel.childCount > 0)
		{
			GameObject toRemove = transform.GetChild(0).gameObject;
			itemButtonObjectPool.ReturnObject(toRemove);
		}
	}

  // private void AddItem(Unlock itemToAdd, Sh)

  public void handleItemTransfer(Item unlockedItem)
  {
    if(slot_1.transform.childCount == 0)
    {
      GameObject itemObj = Instantiate(itemPrefab, slot_1);
      CraftingSlot slot = itemObj.GetComponent<CraftingSlot>();
      slot.Setup(unlockedItem, 1);
    } else if(slot_2.transform.childCount == 0) 
    {
      GameObject itemObj = Instantiate(itemPrefab, slot_2);
      CraftingSlot slot = itemObj.GetComponent<CraftingSlot>();
      slot.Setup(unlockedItem, 2);
    }  else if(slot_3.transform.childCount == 0) 
    {
      GameObject itemObj = Instantiate(itemPrefab, slot_3);
      CraftingSlot slot = itemObj.GetComponent<CraftingSlot>();
      slot.Setup(unlockedItem, 3);
    }
  }

  private void HandleCombination()
  {
    CraftingSlot item_1 = slot_1.GetComponentInChildren<CraftingSlot>();
    CraftingSlot item_2 = slot_2.GetComponentInChildren<CraftingSlot>();
    CraftingSlot item_3 = slot_3.GetComponentInChildren<CraftingSlot>();


    //var combinationList = new List<T>();

    List<string> combinationItems = new List<string>();

    if(item_1 != null)
    {
      combinationItems.Add(item_1.name);
    }
     if(item_2 != null)
    {
      combinationItems.Add(item_2.name);
    }
    //  if(item_3 != null)
    // {
    //   combinationItems.Add(item_3.name);
    // }

    // foreach(string item in combinationItems)
    // {
    //   Debug.Log(item);
    // }

    if(item_1 == null || item_2 == null) {
      return;
    }

    foreach(Recipe r in recipes)
    {
      Item[] items = {r.input01, r.input02};

      if((items.Any(item => item.name == item_1.name) &&
			  items.Any(item => item.name == item_2.name)))
      {
        if(!Storage.Instance.HasItem(r.result.name))
        {
          SuccessPanel.SetActive(true);
          unlockedItemName.text = r.result.name;
          unlockedItemIcon.sprite = r.result.icon; 
          //storage.unlockedItem.Add(new UnlockedItem(r.result.name, 0, r.result.producer, 1, r.result.icon));
          Storage.Instance.AddItem(r.result);
          Production.Instance.AddItem(r.result);
          RefreshDisplay();
        }

      }
    }
  }
}
