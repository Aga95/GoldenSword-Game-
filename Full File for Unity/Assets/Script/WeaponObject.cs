using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponObject : ScriptableObject {

    public string weaponName = "Weapon Name Here";
    public int cost = 50;
    public string description;
    public Sprite sprite;

    public int damage;
    public float swingRate = 1f;
}
