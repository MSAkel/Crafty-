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

  [SerializeField]
  private Text value;

  [SerializeField]
  private Button sellAllButton;


  private float timer;
  private bool isValid;


  private void Start()
  {
    sellAllButton.onClick.AddListener(SellAll);
  }

  public void Setup(Item item)
  {
    this.item = item;
    nameText.text = item.name;
    icon.sprite = item.icon;
    value.text = item.value.ToString();
  }

  void Update()
	{
    count.text = item.count.ToString();

    CheckRequirements();
    if (isValid)
    {
      GenerateItem();
    }
  }


  private void SellAll()
  {
    GameManager.Instance.Currency += (item.value * item.count);
    item.count = 0;
  }


  private void CheckRequirements()
  {

    if (item.item01 != null)
    {
      if (item.item02 != null)
      {
        if (item.item01.count > 0 && item.item02.count > 0)
        {
          item.item01.count -= 1;
          item.item02.count -= 1;
          isValid = true;
        }
      }
      else
      {
        item.item01.count -= 1;
        GenerateItem();
        isValid = true;
      }
    }
    else
    {
      GenerateItem();
      isValid = true;
    }
  }


  private void GenerateItem()
  {
    item.productionProgress += Time.deltaTime;
    if (item.productionProgress >= item.productionTime && item.count < Storage.Instance.maxStorageCount)
    {
      item.count++;
      item.productionProgress = 0.0F;
      isValid = false;
    }
  }

}
