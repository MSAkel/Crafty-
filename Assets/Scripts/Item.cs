using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject {
  public new string name;
	public string producer;
	public byte tier;
	public int count;
	public float productionTime;
	public Sprite icon;
	public bool initial;
}
