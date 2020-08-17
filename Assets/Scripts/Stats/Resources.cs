using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    //don't know if needed
    #region Singleton    
    public static Resources instance;

    void Awake()
    {
        if (instance != null) //just warning
        {
            Debug.LogWarning("More then one instance of Resources found!");
            return;
        }

        instance = this;
    }
    #endregion 

    public int currentResources;

    public void AddResources(int amountToAdd)
    {
        if (amountToAdd != 0)
        {
            currentResources += amountToAdd;
        }


    }


}
