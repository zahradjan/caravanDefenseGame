using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{

    Rigidbody rb;
    int rotationSpeed = 25;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void RotateLeft()
    {
        rb.transform.Rotate(Vector3.up * rotationSpeed);
    }
    public void RotateRight()
    {
        rb.transform.Rotate(Vector3.up * -rotationSpeed);
    }
}
