using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Drag3D : MonoBehaviour
{
    #region Private Properties
    float ZPosition;
    Vector3 Offset;
    Camera mainCamera;
    bool Dragging;
    public GameObject finalobject;
    #endregion
    #region Inspector Variables
    [SerializeField]
    public UnityEvent OnBeginDrag;
    [SerializeField]
    public UnityEvent OnEndDrag;
    #endregion
    #region Unity Functions
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        ZPosition = mainCamera.WorldToScreenPoint(transform.position).z;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Dragging)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Terrain.activeTerrain.GetPosition().z);
            finalobject.transform.position = mainCamera.ScreenToWorldPoint(position + new Vector3(Offset.x, Offset.y));
        }
    }
    private void OnMouseDown()
    {
        if (!Dragging)
        {
            BeginDrag();
        }
    }
    private void OnMouseUp()
    {
        EndDrag();
    }
    public void BeginDrag()
    {

        OnBeginDrag.Invoke();
        Instantiate(finalobject);
        Dragging = true;
        Offset = mainCamera.WorldToScreenPoint(transform.position) - Input.mousePosition;
    }
    public void EndDrag()
    {
        OnEndDrag.Invoke();
        Dragging = false;
    }
    #endregion
}
