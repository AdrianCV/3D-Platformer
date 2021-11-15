using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Variables", menuName = "ScriptableObjects/Variables")]
public class Variables : ScriptableObject
{
    public Vector3 checkpoint;
    public int health;
}
