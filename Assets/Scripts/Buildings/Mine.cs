using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Mine : Building {


	void Start()
	{
		Upgrades = new BuildingUpgrade[]
		{
			new BuildingUpgrade(15000, 5, 1000, 0.5f),
			new BuildingUpgrade(50000, 8, 4000, 1f),
		};
	}
	void Update()
	{

	}
}
