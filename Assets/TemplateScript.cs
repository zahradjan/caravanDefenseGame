using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateScript : MonoBehaviour
{
    [SerializeField]
    private GameObject finalObject;

    private Vector3 mousePos;
    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,0f)));
        transform.position = new Vector3(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y), 0f);

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("POSX: " + mousePos.x);
            Debug.Log("POSY: " + mousePos.y);
            Debug.Log("POSeX: " + transform.position.x);
            Debug.Log("POSeY: " + transform.position.y);
            Instantiate(finalObject, transform.position, Quaternion.identity);
        }
    }
}
