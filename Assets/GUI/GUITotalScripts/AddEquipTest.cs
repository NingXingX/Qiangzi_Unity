using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddEquipTest : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject bagEquipPrefab;

    public void AddEquipToBag()
    {
        if ( targetObject != null && bagEquipPrefab != null )
        {
            GameObject prefabInstance = Instantiate(bagEquipPrefab);

            prefabInstance.transform.SetParent(targetObject.transform);
        }
 
    }
}

