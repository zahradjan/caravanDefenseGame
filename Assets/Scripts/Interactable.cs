using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact()
    {
        //This method is ment to be overwriten
       // Debug.Log("Interacting with " + transform.name);
    }

     void Update()
    {
        //OnMouseDown();
    }

    
}
