using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickChecker : MonoBehaviour
{

    #region ClickTimeVariables
    private float lastClickTime;
    private const float DOUBLE_CLICK_TIME = .2f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        DoubleClicked();

    }

    public void DoubleClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float timeSinceLastClick = Time.time - lastClickTime;

            if(timeSinceLastClick <= DOUBLE_CLICK_TIME)
            {
                Debug.Log("DoubleClick!!");
            }
            else
            {
                Debug.Log("NormalClick!!");
            }

            lastClickTime = Time.time;

        }
        
    }

 
}
