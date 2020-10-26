using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Buildable Object", menuName ="Buildable object")]
public class BuildableObject : ScriptableObject
{
    public GameObject prefab;
    public Vector3 hitboxSize;
    public Vector3 offset;
}
