using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WarriorBase : ScriptableObject
{
    //this is set of methods every child has to implement
    public abstract void Attack();
    public abstract void Move();
    public abstract void TakeDmg();
    public abstract void SetDefaultBaseStats();
}
