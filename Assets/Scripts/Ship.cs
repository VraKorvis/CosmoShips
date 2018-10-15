using UnityEngine;
using UnityEditor;
using System;

[Serializable]
public class BaseShip {
    
    //[Header("Player")]
    public String type;
    public int health;
    // [Header("shoot/ms")]
    public int shootSpeed;
    // [Header("unit")]
    public int mooveSpeed;
    [Range(0, 100)]
    public int mobility;
}

[Serializable]
public class ShipMultipliers {
    
    //[Header("Player")]
    public String type;    
    public int health;
    // [Header("shoot/ms")]
    public int shootSpeed;
    // [Header("unit")]
    public int mooveSpeed;
    [Range(0, 100)]
    public int mobility;
    public int weaponDamage;
}

public enum TypeShip {
    Player,
    Enemy,
    Boss
}