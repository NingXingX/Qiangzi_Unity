using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MoveStorePanel : MonoBehaviour
{
    public RectTransform uiComponent;
    public bool isStoreDisplay = false;
    public Vector3 initialPosition;
    public Vector3 endPosition;
    void Start()
    {
        // ��ȡUI����ĳ�ʼλ��
        initialPosition = uiComponent.anchoredPosition3D;
        // ��ȡUI������յ�λ��
        endPosition = new Vector3(initialPosition.x, initialPosition.y - 1000f, initialPosition.z);
    }


    public void ChangeStorePanel()
    {
        Vector3 nowPosition = uiComponent.anchoredPosition3D;

        if (isStoreDisplay == false && nowPosition == initialPosition)
        {
            //�õ���ǰλ��
            nowPosition = uiComponent.anchoredPosition3D;

            // ����Ŀ��λ��
            Vector3 targetPosition = new Vector3(initialPosition.x, initialPosition.y - 1000f, initialPosition.z);

            // ʹ��DoTween���ʵ��UI������ƶ�
            uiComponent.DOAnchorPos3D(targetPosition, 1f);

            //�ı����
            isStoreDisplay = true;

        }
        else if ( isStoreDisplay == true && nowPosition == endPosition)
        {
            // ����Ŀ��λ��
            Vector3 targetPosition = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);

            // ʹ��DoTween���ʵ��UI������ƶ�
            uiComponent.DOAnchorPos3D(targetPosition, 1f);

            //�ı����
            isStoreDisplay = false;
        }

    }
}

