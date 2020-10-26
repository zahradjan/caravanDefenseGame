using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    [SerializeField] LayerMask collisionLayers;
    [SerializeField] Color noCollisionColor;
    [SerializeField] Color collisionColor;


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
                SetColor(collisionColor);
                colliding = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (collisionLayers == (collisionLayers | (1 << other.gameObject.layer)))
        {
            SetColor(noCollisionColor);
            colliding = false;
        }
    }
}
