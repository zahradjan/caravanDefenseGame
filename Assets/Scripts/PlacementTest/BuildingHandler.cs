using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{
    public BuildableObject[] buildables;
    [SerializeField] private int selectionIndex;
    public Camera mainCamera;
    public LayerMask buidlableAreaMask;
    public Material ghostMaterial;
    public Material collisionMaterial;
    public Grid grid;
    private GameObject ghost;
    //private CharacterSelector 

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Select(int index)
    {
        if (index >= 0 || index < buildables.Length)
        {
            selectionIndex = index;
        }
    }
    public void Deselect()
    {
        selectionIndex = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (selectionIndex >= 0)
        {

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, Mathf.Infinity, buidlableAreaMask);



            if (hit.collider != null && NotPressingCanvasButton())
            {
                Vector3 position = grid.GetNearestPointOnGrid(hit.point);
                BuildableObject buildable = buildables[selectionIndex];
                if (ghost == null)
                {
                    
                    ghost = Instantiate(buildable.prefab, position + buildable.offset, Quaternion.identity);
                    // tohle funguje jenom pro kostku a krychli
                    //ghost.GetComponent<Renderer>().material = ghostMaterial;
                }
                else
                {

                    ghost.transform.position = position + buildable.offset;
                    
                }


                if (Input.GetMouseButtonDown(0))
                {

                    if (NotPressingCanvasButton())
                        Destroy(ghost);
                    Instantiate(buildable.prefab, position + buildable.offset, Quaternion.identity);

                }
            }
            else
            {
                Destroy(ghost);

            }
        }
    }

    //TODO: tohle zatim nefunguje a jeste tam je problem s character full ze nema reference na instance of object
    bool CanPlaceObject()
    {
        return ghost.GetComponent<Ghost>().colliding != true;
    }

    bool NotPressingCanvasButton()
    {
        return !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
    }




}
