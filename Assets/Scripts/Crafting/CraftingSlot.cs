using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSlot : MonoBehaviour
{
  [SerializeField]
  private Button button;

  [SerializeField]
  private int slotNumber;

  public Image icon;

  public string name {get;set;}

   private Item item;

  void Start () 
  {
		button.onClick.AddListener(HandleClick);
	}


  public void Setup(Item currentItem, int slot)
  {
    item = currentItem;
    name = currentItem.name;
    slotNumber = slot;
    icon.sprite = currentItem.icon;
  }

  public void HandleClick()
  {
     Destroy(gameObject);
  }
}
