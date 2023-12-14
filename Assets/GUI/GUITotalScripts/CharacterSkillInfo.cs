using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkillInfo : MonoBehaviour
{
    public GameObject tooltipPanel; // ��Ϣ��������

    private bool isHovering; // �Ƿ������ͣ��UI�����

    private void Update()
    {
        if(isHovering)
        {
            tooltipPanel.SetActive(true);
            // ����Ϣ�������ΪCanvas�������ʾ˳��
            tooltipPanel.transform.SetAsLastSibling();
        }
        else
        {
            tooltipPanel.SetActive(false);
        }
    }

    public void PointEnterUI()
    {
        isHovering = true;
        print("�������˼���UI");
    }

    public void PointExitUI()
    {
        isHovering = false;
        print("����˳��˼���UI");
    }
}
