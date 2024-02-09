using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//添加装备测试按钮的脚本
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

