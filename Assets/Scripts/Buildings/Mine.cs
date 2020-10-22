using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Building 
{
	void Start()
	{
		populateItems();
	
		Upgrades = new BuildingUpgrade[]
		{
			new BuildingUpgrade(5000, 5, 100, 7200, 0.5f),
			new BuildingUpgrade(10000, 8, 400, 14400, 1f),
		};
	}
	
	void Update () 
	{
		if (didUpgrade)
		{
			populateItems();
			didUpgrade = false;
		}
	}
}
