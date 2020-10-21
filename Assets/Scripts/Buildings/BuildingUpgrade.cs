﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUpgrade
{

	public int Price { get; private set; } //upgrade cost
	public int MaxWorkers { get; private set; }
	public int GoldRate { get; private set; }
	public float ProductionRate { get; private set; }

	public BuildingUpgrade(int price, int maxWorkers, int goldRate, float productionRate)
	{
		this.Price = price;
		this.MaxWorkers = maxWorkers;
		this.GoldRate = goldRate;
		this.ProductionRate = productionRate;
	}
}
