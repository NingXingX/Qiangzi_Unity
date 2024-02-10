using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MoveRoleStatusPanel : MonoBehaviour
{
    [Header("���»���")]
    public RectTransform uiComponent;
    public bool isRoleDisplay = false;
    public Vector3 PageStartPosition;//ҳ�濪ʼλ��
    public Vector3 PageEndPosition;//ҳ�����λ��

    [Header("�л�ҳ��")]
    public int nowPage = 1;
    public Text nowPageTitle;//��ǰҳ������
    public Text nowPageNum;//��ǰҳ��ҳ��
    public RectTransform pageComponent_1;
    public RectTransform pageComponent_2;
    public Vector3 PageStartPosition_1;//ҳ��1��ʼλ��
    public Vector3 PageEndPosition_1;//ҳ��1����λ��

    public Vector3 PageStartPosition_2;//ҳ��2��ʼλ��
    public Vector3 PageEndPosition_2;//ҳ��2����λ��

    private void Start()
    {
        //���»�������
        // ��ȡUI����ĳ�ʼλ��
        PageStartPosition = uiComponent.anchoredPosition3D;
        // ��ȡUI������յ�λ��
        PageEndPosition = new Vector3(PageStartPosition.x, PageStartPosition.y - 1000f, PageStartPosition.z);

        //����ҳ���л�����
        // ���ҳ��1�ĳ�ʼλ��
        PageStartPosition_1 = pageComponent_1.anchoredPosition3D;
        // ��ȡҳ��1���յ�λ��
        PageEndPosition_1 = new Vector3(PageStartPosition_1.x - 800f, PageStartPosition_1.y, PageStartPosition_1.z);

        // ���ҳ��2��ʼλ��
        PageStartPosition_2 = pageComponent_2.anchoredPosition3D;
        // ���ҳ��2����λ��
        PageEndPosition_2 = new Vector3(PageStartPosition_2.x - 800f, PageStartPosition_2.y, PageStartPosition_2.z);
    }

    //��ɫ״̬�������»�������
    public void ChangeRoleStatusPanel()
    {
        
        Vector3 nowPosition = uiComponent.anchoredPosition3D;

        if( isRoleDisplay == false && nowPosition == PageStartPosition)
        {
            //�õ���ǰλ��
            nowPosition = uiComponent.anchoredPosition3D;

            // ����Ŀ��λ��
            Vector3 targetPosition = new Vector3(PageStartPosition.x, PageStartPosition.y - 1000f, PageStartPosition.z);

            // ʹ��DoTween���ʵ��UI������ƶ�
            uiComponent.DOAnchorPos3D(targetPosition, 1f);

            //�ı����
            isRoleDisplay = true;

        }
        else if ( isRoleDisplay == true && nowPosition == PageEndPosition)
        {
            // ����Ŀ��λ��
            Vector3 targetPosition = new Vector3(PageStartPosition.x, PageStartPosition.y, PageStartPosition.z);

            // ʹ��DoTween���ʵ��UI������ƶ�
            uiComponent.DOAnchorPos3D(targetPosition, 1f);

            //�ı����
            isRoleDisplay = false;
        }
        
    }

    //��ɫ״̬�������һ����л�ҳ�빦��
    //���һ���
    public void ChangeRoleStatusPanelPage_ToRight()
    {
        //���ݵ�ǰҳ���ж�
        if( nowPage == 1)
        {
            // ����Ŀ��λ��
            Vector3 targetPosition1 = PageEndPosition_1;
            Vector3 targetPosition2 = PageEndPosition_2;

            // ʹ��DoTween���ʵ��ҳ��2���ƶ�
            pageComponent_1.DOAnchorPos3D(targetPosition1, 1f);

            // ʹ��DoTween���ʵ��ҳ��1���ƶ�
            pageComponent_2.DOAnchorPos3D(targetPosition2, 1f);

            //�ı�ҳ��
            nowPage = 2;

            //�ı��ı�
            nowPageTitle.text = "ҳ��2";
            nowPageNum.text = "2/2";
        }
    }
    //�����ƶ�
    public void ChangeRoleStatusPanelPage_ToLeft()
    {
        //���ݵ�ǰҳ���ж�
        if (nowPage == 2)
        {
            // ����Ŀ��λ��
            Vector3 targetPosition1 = PageStartPosition_1;
            Vector3 targetPosition2 = PageStartPosition_2;

            // ʹ��DoTween���ʵ��ҳ��2���ƶ�
            pageComponent_1.DOAnchorPos3D(targetPosition1, 1f);

            // ʹ��DoTween���ʵ��ҳ��1���ƶ�
            pageComponent_2.DOAnchorPos3D(targetPosition2, 1f);

            //�ı�ҳ��
            nowPage = 1;

            //�ı��ı�
            nowPageTitle.text = "��ɫ��Ϣ";
            nowPageNum.text = "1/2";
        }
    }
}
