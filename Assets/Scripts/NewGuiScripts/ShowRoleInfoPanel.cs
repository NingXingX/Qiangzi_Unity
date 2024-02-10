using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShowRoleInfoPanel : MonoBehaviour
{
    //���뵭������
    public float fadeDuration = 1f;//���
    public float fadeDelay = 0f;//�ӳ�

    //�ж���Ϣ���Ƿ���
    public bool isInfoDisplay = false;

    //��ʹ�õ�CanvasGroup���
    public CanvasGroup infoCanvasGroup;

    public void roleInfoPanelFade()
    {
        if (isInfoDisplay == false )
        {
            // ʹ��DoTween���ʵ��UI�����͸���Ƚ���
            infoCanvasGroup.DOFade(1f, fadeDuration).SetDelay(fadeDelay);

            //��CanvasGroup������Ա�����
            infoCanvasGroup.interactable = true;
            infoCanvasGroup.blocksRaycasts = true;

            //�ı��жϱ���
            isInfoDisplay = true;
        }
        else
        {
            // ʹ��DoTween���ʵ��UI�����͸���Ƚ���
            infoCanvasGroup.DOFade(0f, fadeDuration).SetDelay(fadeDelay);

            //��CanvasGroup������Ա�����
            infoCanvasGroup.interactable = false;
            infoCanvasGroup.blocksRaycasts = false;

            //�ı��жϱ���
            isInfoDisplay = false;
        }

    }
}
