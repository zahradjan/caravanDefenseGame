using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TemplateScript : MonoBehaviour
{
    [SerializeField]
    private GameObject finalObject;

    private MeshRenderer meshM;
    private MeshFilter meshF;
    private GameObject currentPlaceableObject;
    private float mCoorZ;

    //NavMeshAgent agent;
    Vector3 moffSet;
    
    bool isDragging;
    

    private void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        meshM = GameObject.Find("Mesh").GetComponent<MeshRenderer>();
        meshF = GameObject.Find("Mesh").GetComponent<MeshFilter>();

    }

    // Update is called once per frame
    void Update()
    {
      

     
        //Debug.Log("Mym " + meshM.mesh.);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            //for (int i = 0; i <= meshM.mesh.vertices.Length; i++)
            //{
            //    if (meshM.mesh.vertices[i] != hit.point)
            //    {
            //        Debug.Log("Jsem mimo vertices!");
            //    }
            //}
           


            if (hit.point != meshM.bounds.center)
            {
                Debug.Log(meshM.bounds.center);
            }

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Pozice: " + hit.point);
                //Instantiate(finalObject);
                //currentPlaceableObject = Instantiate(finalObject);

                for (int i = 0; i < meshF.mesh.vertices.Length; i++)
                {
                    Debug.Log("Vertice: " + meshF.mesh.vertices[i]);
                }

            }
            else
            {
               
            }

            if (Input.GetMouseButton(0))
            {
                //finalObject.transform.position = hit.point;
               
            }
        }

    }

   

    //private void OnMouseDown()
    //{
    //    mCoorZ = Camera.main.WorldToScreenPoint(finalObject.transform.position).z;
    //    moffSet = finalObject.transform.position - GetMousePosition();
    //    Instantiate(finalObject);
    //}

    //private void OnMouseDrag()
    //{
    //    finalObject.transform.position = GetMousePosition() + moffSet;
    //}

    private Vector3 GetMousePosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mCoorZ;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
