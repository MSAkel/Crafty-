using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingButton : MonoBehaviour {
	[SerializeField]
	private int price;
	[SerializeField]
	private Text priceText;

	[SerializeField]
	private Text buyButtonText;

	[SerializeField]
	private GameObject building;

	public int Price
	{
		get
		{
			return price;
		}
	}

	private void Start()
	{
		GameManager.Instance.Changed += new CurrencyChanged(PriceCheck);
		GetComponent<Button>().onClick.AddListener(onClickBuy);
	}

	private void PriceCheck()
	{
		if (price <= GameManager.Instance.Currency)
		{
			GetComponent<Image>().color = Color.white;
			priceText.color = Color.white;
		} else
		{
			GetComponent<Image>().color = Color.gray;
			buyButtonText.text = "lul";
			// priceText.color = Color.red;
		}
	}

	private void onClickBuy()
	{
		if (price <= GameManager.Instance.Currency)
		{
			GameManager.Instance.Currency -= price;
			gameObject.SetActive(false);
			building.GetComponent<Button>().interactable = true;

			if(building.name == "Farm") building.GetComponent<Farm>().enabled = true;
			if(building.name == "Mine") building.GetComponent<Mine>().enabled = true;
			//if(building.name == "Alchemist") building.GetComponent<Alchemist>().enabled = true;
		} 
	}
}
