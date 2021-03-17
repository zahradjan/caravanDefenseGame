using UnityEngine;

public class SelectWarrior : MonoBehaviour
{
    #region Singleton
    public static SelectWarrior instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject gameManager;
    public GameObject UiCanvas;
    public Camera mainCamera;
    public LayerMask buildableAreaMask;
    public Warrior selectedWarrior;
    [SerializeField] private int selectionIndex;
    public Grid grid;
    private GameObject ghost;
    // public Vector3 playerSpawnPosition = new Vector3(0, 1, -7);
    public Warrior[] warriors; // potreba nejak predvyplnit uz  z te equipment faze
    public WarriorEquiper warriorEquiper;

    void Start()
    {
        //ty warriors budou muset chodit z te equipment sceny
        selectionIndex = -1;
        //selectedCharacter = characters[0];
        warriorEquiper = gameManager.GetComponent<WarriorEquiper>();


    }

    void Update()
    {
        if (selectionIndex >= 0)
        {
            RaycastHit hit = getCollisionWithGround();

            if (hit.collider != null && NotPressingCanvasButton())
            {
                Vector3 position = grid.GetNearestPointOnGrid(hit.point);
                //Warrior warrior = warriors[selectionIndex];
                if (ghost == null)
                {

                    ghost = Instantiate(selectedWarrior.basicModel, position + selectedWarrior.offset, Quaternion.identity);
                    // tohle funguje jenom pro kostku a krychli
                    //ghost.GetComponent<Renderer>().material = ghostMaterial;
                }
                else
                {
                    if(CanPlaceObject(ghost)) ghost.transform.position = position + selectedWarrior.offset;

                }


                if (Input.GetMouseButtonDown(0))
                {

                    if (NotPressingCanvasButton() && CanPlaceObject(ghost))
                        Destroy(ghost);
                        Instantiate(selectedWarrior.equipedModel, position + selectedWarrior.offset, Quaternion.identity);

                }
            }
            else
            {
                Destroy(ghost);

            }


        }

        if (Input.GetMouseButtonDown(1))
        {
            Destroy(ghost);
            selectionIndex = -1;

        }


    }

    private RaycastHit getCollisionWithGround()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, Mathf.Infinity, buildableAreaMask);
        return hit;
    }

    //TODO: tohle zatim nefunguje a jeste tam je problem s character full ze nema reference na instance of object
    bool CanPlaceObject(GameObject ghost)
    {
        Debug.Log(ghost.GetComponent<Ghost>().colliding != true);
        return ghost.GetComponent<Ghost>().colliding != true;
    }

    bool NotPressingCanvasButton()
    {
        return !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
    }

    public void WarriorSelect(int warriorChoice)
    {
       
        selectedWarrior = warriors[warriorChoice];
        GameObject model = Instantiate(selectedWarrior.basicModel);
        Debug.Log("Bone: " + model.transform.Find("Armature/ik_wrist_right/right_hand/weapon_bone"));
        GameObject handBone = model.transform.Find("Armature/ik_wrist_right/right_hand/weapon_bone").gameObject; 
        //GameObject character = model.Find
        Debug.Log("NAME " + handBone.transform.localPosition);
        SkinnedMeshRenderer targetMesh = model.GetComponentInChildren<SkinnedMeshRenderer>();
        warriorEquiper.UpdateCurrentMesh(selectedWarrior, targetMesh, handBone);
        selectedWarrior.equipedModel = model;


        selectionIndex = warriorChoice;


    }





    //public void NextCharacterButton(int characterChoice)
    //{
    //    Debug.Log("currentCharacterChoice = " + currentCharacterChoice);
    //    if (currentCharacterChoice >= characters.Length - 1)
    //    {
    //        currentCharacterChoice = 0;
    //        CharacterSelect(currentCharacterChoice);
    //    }
    //    else
    //    {
    //        currentCharacterChoice += 1;
    //        CharacterSelect(currentCharacterChoice);
    //    }

    //}
    public void WarriorButton(int characterChoice)
    {
        //Na stisk tlacitka vybere toho charactera
        WarriorSelect(characterChoice);

    }

}