using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageItemDisplay : MonoBehaviour
{
  [SerializeField]
  private Item item;

  [SerializeField]
  private Text nameText;

  [SerializeField]
  private Text count;

  [SerializeField]
  private Image icon;


  private float timer;

  public void Setup(Item item)
  {
    this.item = item;
    nameText.text = item.name;
    icon.sprite = item.icon;
  }

  void Update()
	{
	//	generateItem();
  count.text = item.count.ToString();
	}

	private void generateItem()
	{
    timer += Time.deltaTime;

    if(timer >= item.productionTime && item.count < Storage.Instance.maxStorageCount)
    {
      item.count++;
      count.text = item.count.ToString();
      timer = 0.0F;
    }
    // if(item.count >= Storage.Instance.maxStorageCount)
    // {
    //   item.count = Storage.Instance.maxStorageCount;
    //   count.text = item.count.ToString();
    // }

	}

}
