using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject {
  public new string name;
	public string producer;
	public byte tier;
	public int count;
	public int value;
	public float productionTime;
	public float productionProgress;
	public Sprite icon;
	public bool initial;

	public Item item01;
	public Item item02;
}
