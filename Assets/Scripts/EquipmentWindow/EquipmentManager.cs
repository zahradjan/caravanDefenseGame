using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

     void Awake()
    {
        instance = this;
    }

    #endregion

    public SkinnedMeshRenderer targetMesh; // empty player body mesh
    public GameObject handBone;
    Equipment[] currentEquipment;   //currently equiped items
    SkinnedMeshRenderer[] currentMeshes;
    

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    public Vector3 pickPosition;
    public Vector3 pickRotation;
    public Vector3 pickScale;

    void Start()
    {
        inventory = Inventory.instance;

      int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];

    }

    public void Equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null) //swap items if something's already equiped
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        newMesh.transform.parent = targetMesh.transform; //parent the equipment mesh to player mesh
        

        newMesh.bones = targetMesh.bones;
        if (newItem.equipSlot != EquipmentSlot.Weapon)
        {
            newMesh.rootBone = targetMesh.rootBone;
        }
        else{
            //GameObject handBone = targetArmature.transform.Find("weapon_bone").gameObject; // make weapon a child of handbone
            Debug.Log("Item is Weapon!");
            newMesh.transform.parent = handBone.transform;
           // newMesh.transform.position = handBone.transform.position;
           newMesh.transform.localPosition = pickPosition;
            newMesh.transform.localEulerAngles = pickRotation;
            newMesh.transform.localScale = pickScale;

        }

        currentMeshes[slotIndex] = newMesh;

       
    }

    public void Unequip (int slotIndex) 
    {
        if (currentEquipment[slotIndex] != null)
        {
            if (currentMeshes[slotIndex] !=null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }

            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }

}
