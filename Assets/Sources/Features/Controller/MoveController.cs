using UnityEngine;
using System.Collections;
using Entitas;

public class MoveController : MonoBehaviour, IMoveable {
    public virtual void Move(EnemiesEntity e, float time) {}
}
