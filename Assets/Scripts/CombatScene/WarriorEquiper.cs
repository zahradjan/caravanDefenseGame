using UnityEngine;

public class WarriorEquiper : MonoBehaviour
{
    #region Singleton
    public static WarriorEquiper instance;

    void Awake()
    {
        instance = this;
    }

    #endregion
    SelectWarrior selectWarrior;
    Warrior selectedWarrior;
    public SkinnedMeshRenderer targetMesh; // empty player body mesh
    public GameObject handBone;
    [HideInInspector]
    public Item[] currentEquipment;   //currently equiped items
    SkinnedMeshRenderer[] currentMeshes;


    //for weapons
    public Vector3 pickPosition;
    public Vector3 pickRotation;
    public Vector3 pickScale;

    void Start()
    {
        //characterSelector = SelectWarrior.instance;
        ////Debug.Log(characterSelector.selectedWarrior.name);

        //selectedCharacter = characterSelector.selectedWarrior;

        //currentEquipment = selectedCharacter.currentEquipment;


        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;

        ////Debug.Log(numSlots);
        currentMeshes = new SkinnedMeshRenderer[numSlots];
        //Debug.Log(currentMeshes);

    }



    //public void RenderMeshes()
    //{

    //    //todle asi nebude fungovat
    //    for (int i = 0; i < currentMeshes.Length; i++)
    //    {
    //        if (currentMeshes[i] != null)
    //        {
    //            UpdateCurrentMesh(selectedCharacter);
    //        }
    //    }
    //}




    // tohle pro loopovat pro vsechny elementy co ma ve scriptable object
    //ten target mesh musi bejt samostatne pro kazdyho warriora
    public void UpdateCurrentMesh(Warrior warrior, SkinnedMeshRenderer targetMesh, GameObject handbone)
    {



        //Debug.Log(targetMesh);
        currentEquipment = warrior.currentEquipment;
        //Debug.Log(currentEquipment.Length);
        //Debug.Log("CLICK");
        //Debug.Log("Meshes " + currentMeshes);
        for (int i = 0; i < currentEquipment.Length; i++) //problém je tady, instantiate nedělá co má
        {
           
            if (currentEquipment[i] != null)
            {
                Item newItem = currentEquipment[i];

                SkinnedMeshRenderer newMesh = Instantiate(newItem.mesh);
                //Debug.Log(newMesh.gameObject.name);
                //Debug.Log(newMesh.gameObject.transform.localPosition);
                newMesh.transform.parent = targetMesh.transform; //parent the equipment mesh to player mesh

                newMesh.bones = targetMesh.bones;
                if (newItem.equipSlot != EquipmentSlot.Weapon) //if item is weapon, parrenting is different
                {
                    newMesh.rootBone = targetMesh.rootBone;
                }
                else
                {
                    newMesh.transform.parent = handbone.transform;
                    newMesh.transform.localPosition = pickPosition;
                    newMesh.transform.localEulerAngles = pickRotation;
                    newMesh.transform.localScale = pickScale;

                    //Debug.Log("Position:" + newMesh.gameObject.transform.localPosition);
                }
                //Debug.Log(newMesh.GetInstanceID());
                currentMeshes[i] = newMesh;
            }
        }

    }
    public void Equip(Item newItem)
    {
        selectedWarrior = selectWarrior.selectedWarrior; //makes sure the right character is selected
        currentEquipment = selectedWarrior.currentEquipment;   //udělat OnCharacterSwich() nebo tak něco
        int slotIndex = (int)newItem.equipSlot;

        if (currentMeshes[slotIndex] != null)
        {
            Destroy(currentMeshes[slotIndex].gameObject);
        }



        currentEquipment[slotIndex] = newItem;
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        newMesh.transform.parent = targetMesh.transform; //parent the equipment mesh to player mesh


        newMesh.bones = targetMesh.bones;
        if (newItem.equipSlot != EquipmentSlot.Weapon)
        {
            newMesh.rootBone = targetMesh.rootBone;
        }
        else
        {
            //GameObject handBone = targetArmature.transform.Find("weapon_bone").gameObject; // make weapon a child of handbone         
            newMesh.transform.parent = handBone.transform;
            // newMesh.transform.position = handBone.transform.position;
            newMesh.transform.localPosition = pickPosition;
            newMesh.transform.localEulerAngles = pickRotation;
            newMesh.transform.localScale = pickScale;

        }

        currentMeshes[slotIndex] = newMesh;






    }

}