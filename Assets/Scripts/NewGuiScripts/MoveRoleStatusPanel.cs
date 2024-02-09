using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MoveRoleStatusPanel : MonoBehaviour
{
    public RectTransform uiComponent;
    public bool isRoleDisplay = false;
    public Vector3 initialPosition;
    public Vector3 endPosition;

    private void Start()
    {
        // ��ȡUI����ĳ�ʼλ��
        initialPosition = uiComponent.anchoredPosition3D;
        // ��ȡUI������յ�λ��
        endPosition = new Vector3(initialPosition.x, initialPosition.y - 1000f, initialPosition.z);
    }


    public void ChangeRoleStatusPanel()
    {
        
        Vector3 nowPosition = uiComponent.anchoredPosition3D;

        if( isRoleDisplay == false && nowPosition == initialPosition )
        {
            //�õ���ǰλ��
            nowPosition = uiComponent.anchoredPosition3D;

            // ����Ŀ��λ��
            Vector3 targetPosition = new Vector3(initialPosition.x, initialPosition.y - 1000f, initialPosition.z);

            // ʹ��DoTween���ʵ��UI������ƶ�
            uiComponent.DOAnchorPos3D(targetPosition, 1f);

            //�ı����
            isRoleDisplay = true;

        }
        else if ( isRoleDisplay == true && nowPosition == endPosition )
        {
            // ����Ŀ��λ��
            Vector3 targetPosition = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);

            // ʹ��DoTween���ʵ��UI������ƶ�
            uiComponent.DOAnchorPos3D(targetPosition, 1f);

            //�ı����
            isRoleDisplay = false;
        }
        
    }
}
