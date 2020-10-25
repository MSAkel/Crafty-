using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUpgrade
{

	public int cost { get; private set; }
	public int maxWorkers { get; private set; }
	//public int GoldRate { get; private set; }
	public int upgradeTime { get; private set; }
	//public float ProductionRate { get; private set; }

	public BuildingUpgrade(int cost, int maxWorkers, int upgradeTime)
	{
		this.cost = cost;
		this.maxWorkers = maxWorkers;
		//this.GoldRate = goldRate;
		this.upgradeTime = upgradeTime;
		//this.ProductionRate = productionRate;
	}
}
