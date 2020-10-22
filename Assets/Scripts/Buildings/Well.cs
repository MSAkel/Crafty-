using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : Building
{
  void Start()
	{
		populateItems();

    Upgrades = new BuildingUpgrade[0];

	}
}
