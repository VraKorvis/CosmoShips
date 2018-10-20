using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats/ShipsSetup", fileName = "shipsSetup")]
[Game, Unique]
public class ShipsSetup : ScriptableObject   {
    [SerializeField]
    public GameObject[] playerShips;

    public int Count() {
        return playerShips != null ? playerShips.Length : 0;
    }

    public GameObject this[int index] {
        get { return playerShips[index]; }
    }

}