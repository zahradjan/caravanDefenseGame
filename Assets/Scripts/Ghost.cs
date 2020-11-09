using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Ghost : MonoBehaviour
{

    [SerializeField] LayerMask collisionLayers;



    public bool colliding { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetColor(Color c)
    {
        GetComponent<Renderer>().material.SetColor("_TintColor", c);
    }

    void OnTriggerEnter(Collider other)
    {
        if (collisionLayers == (collisionLayers | (1 << other.gameObject.layer)))
        {
            if (other.gameObject.transform.root.gameObject.GetInstanceID() != transform.root.gameObject.GetInstanceID())
            {
               
                colliding = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (collisionLayers == (collisionLayers | (1 << other.gameObject.layer)))
        {
          
            colliding = false;
        }
    }
}
