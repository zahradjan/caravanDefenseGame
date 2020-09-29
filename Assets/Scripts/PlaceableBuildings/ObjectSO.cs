using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Warior", menuName = "ScriptableObject/Warior", order = 1)]
public class ObjectSO : ScriptableObject
{
    public string objectName = "Warior Name";
    public GameObject buildingPrefab;
    //public float buildTime;
    //public float cost;
    //public Icon icon;
}
