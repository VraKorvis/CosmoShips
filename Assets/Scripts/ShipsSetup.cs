using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats/ShipsSetup", fileName = "shipsSetup")]
[Game, Unique]
public class ShipsSetup : ScriptableObject   {
    [SerializeField]
    public GameObject[] playerShips;
}