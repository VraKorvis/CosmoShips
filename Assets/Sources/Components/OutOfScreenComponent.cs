using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Bullets, Enemies, FlagPrefix("flag")]
public class OutOfScreenComponent : IComponent {
}
