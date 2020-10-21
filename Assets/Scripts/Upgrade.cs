using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade")]
public class Upgrade : ScriptableObject {
  public new string name;
  public Sprite icon;
  public int cost;
  public string description;
  public int duration;
}
