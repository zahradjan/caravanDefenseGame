using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileMovement : MonoBehaviour
{
    public float speed = 20f;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        //najde cíl
        target = GameObject.FindGameObjectWithTag("Team1").transform;
    }

    // Update is called once per frame
    void Update()
    {
       

        ////nastaví rotaci
        //Vector3 direction = target.position - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(direction);
        //transform.rotation = rotation;
        //transform.Rotate(Vector3.forward);

        //pohyp vpřed ve směru rotace
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
