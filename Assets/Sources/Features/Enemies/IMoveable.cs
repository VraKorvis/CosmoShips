using UnityEngine;
using System.Collections;
using Entitas;

public interface IMoveable  {

    void Move(EnemiesEntity e, float time);

}
