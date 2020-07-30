using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOverview : MonoBehaviour
{
    CharacterStats characterStats;

    Rigidbody rb;
    int rotationSpeed = 25;

    //public GameObject selectedCharacter;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        //transform.localScale = characterStats.characterHeight; //error
            
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
