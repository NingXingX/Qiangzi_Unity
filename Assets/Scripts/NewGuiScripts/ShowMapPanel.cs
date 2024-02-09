using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShowMapPanel : MonoBehaviour
{
    //���뵭�������̲���CanvasGroup���
    public CanvasGroup canvasGroupLeft;
    public CanvasGroup canvasGroupRight;

    //���뵭������
    public float fadeDuration = 1f;//���
    public float fadeDelay = 0f;//�ӳ�

    //�жϵ�ͼ�Ƿ���
    public bool isMapDisplay = false;

    public void chessBoardFade()
    {
        //����ͼû�п���ʱ
        if( isMapDisplay == false )
        {
            // ʹ��DoTween���ʵ��UI�����͸���Ƚ���
            canvasGroupLeft.DOFade(0f, fadeDuration).SetDelay(fadeDelay);
            canvasGroupRight.DOFade(0f, fadeDuration).SetDelay(fadeDelay);

            //��CanvasGroup����޷�������
            canvasGroupLeft.interactable = false;
            canvasGroupLeft.blocksRaycasts = false;
            canvasGroupRight.interactable = false;
            canvasGroupRight.blocksRaycasts = false;

            //�ı��жϱ���
            isMapDisplay = true;
        }
        //����ͼ����ʱ
        else
        {
            // ʹ��DoTween���ʵ��UI�����͸���Ƚ���
            canvasGroupLeft.DOFade(1f, fadeDuration).SetDelay(fadeDelay);
            canvasGroupRight.DOFade(1f, fadeDuration).SetDelay(fadeDelay);

            //��CanvasGroup������Ա�����
            canvasGroupLeft.interactable = true;
            canvasGroupLeft.blocksRaycasts = true;
            canvasGroupRight.interactable = true;
            canvasGroupRight.blocksRaycasts = true;

            //�ı��жϱ���
            isMapDisplay = false;
        }
    }
}
