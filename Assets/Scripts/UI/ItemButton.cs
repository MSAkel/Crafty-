using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    [SerializeField]
    private Button button;

    [SerializeField]
    private Text nameText;

    [SerializeField]
    private Image icon;

    // [SerializeField]
    private Item item;
    private CraftingList craftingList;

    void Start () 
    {
		button.onClick.AddListener(HandleClick);
	}

    public void Setup(Item currentItem, CraftingList currentCraftingList)
    {
        item = currentItem;
        nameText.text = item.name;
        icon.sprite = item.icon;

        craftingList = currentCraftingList;
    }

    public void HandleClick()
    {
        craftingList.handleItemTransfer(item);
    }
}
