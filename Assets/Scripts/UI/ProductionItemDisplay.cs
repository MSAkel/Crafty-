using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductionItemDisplay : MonoBehaviour {

	[SerializeField]
  private Item item;
	private float fillSpeed = 5f;
	public Text nameText;
	public Image icon;
	public Text progressText;

	private float timer;

	[SerializeField]
	private Slider slider;

  // [SerializeField]
  // private RectTransform panelRectTransform;


 	public void Setup(Item item)
  {
    this.item = item;
    nameText.text = item.name;
    icon.sprite = item.icon;
		slider.maxValue = item.productionTime;
  }

	private void Awake() 
  {
    //slider = gameObject.GetComponent<Slider>();
    // slider.maxValue = item.productionTime;
  }

	void Update () {
    if(BuildingManager.Instance.selectedBuilding)
    {
      if(item.producer == BuildingManager.Instance.selectedBuilding.name)
      {
        this.transform.localScale = new Vector3(1, 1, 1);
      } else {
        this.transform.localScale = new Vector3(0, 0, 0);
      }
    }
		generateItem();
	}

		private void generateItem()
	{

    timer += Time.deltaTime;
		progressText.text = string.Format("{0} sec", Mathf.Round((item.productionTime - timer )* 10f) / 10f);


    if(timer >= item.productionTime && item.count < Storage.Instance.maxStorageCount)
    {
      item.count++;
      timer = 0.0F;
    }

		slider.value = Mathf.Lerp(slider.value, timer, Time.deltaTime * fillSpeed);
    // if(item.count >= Storage.Instance.maxStorageCount)
    // {
    //   item.count = Storage.Instance.maxStorageCount;
    //   count.text = item.count.ToString();
    // }
	}
}
