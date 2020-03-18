using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class detectHit : MonoBehaviour
{

    public Slider healthBar;
    Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        healthBar.value -= 20;
        Debug.Log("Hit!");

        if(healthBar.value <= 0)
        {
            anim.SetBool("isDead", true);
        }
        else
        {
            anim.SetBool("isDead", false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
