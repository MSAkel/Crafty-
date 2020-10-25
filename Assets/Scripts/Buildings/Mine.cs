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
			new BuildingUpgrade(5000, 5, 7200),
			new BuildingUpgrade(10000, 8, 14400),
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
