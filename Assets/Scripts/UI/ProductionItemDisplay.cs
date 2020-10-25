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

	public float productionProgress;

	[SerializeField]
	private Slider slider;

	private bool isValid;

	public void Setup(Item item)
	{
		this.item = item;
		nameText.text = item.name;
		icon.sprite = item.icon;
		slider.maxValue = item.productionTime;
		this.name = item.name + " Prod";
		productionProgress = item.productionProgress;
	}


  void Update()
  {
		//CheckRequirements();
		//if(isValid)
  //  {
			GenerateItem();
  //  }
  }

	/**
		* Check for item requiremnts to produce item, if any
		* if item item01 field is not null, check for item02
		* if both are true, deduct 1 from each, if only item01 is true deduct only from item01
		* if both are false, don't deduct from any
		* once all checks are done, set isValid to true to all generation of item.
	*/
	private void CheckRequirements()
  {
		
		if (item.item01 != null)
    {
			if(item.item02 != null)
      {
				if(item.item01.count > 0 && item.item02.count > 0)
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
		// timer += Time.deltaTime;
		productionProgress = item.productionProgress;
		progressText.text = string.Format("{0} sec", Mathf.Round((item.productionTime - productionProgress) * 1f) / 1f);

		//if(timer >= item.productionTime && item.count < Storage.Instance.maxStorageCount)
		//{
		//  item.count++;
		//  timer = 0.0F;
		//  slider.value = 0;
		//	isValid = false;
		//}

		//if(productionProgress >= item.productionTime)
		//{
		//	slider.value = 0;
		//}

		// slider.value = Mathf.Lerp(slider.value, productionProgress, Time.deltaTime * fillSpeed);
		slider.value = productionProgress;
	}
}
