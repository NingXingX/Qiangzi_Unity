using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkillInfo : MonoBehaviour
{
    public GameObject tooltipPanel; // 信息面板的引用

    private bool isHovering; // 是否鼠标悬停在UI组件上

    private void Update()
    {
        if(isHovering)
        {
            tooltipPanel.SetActive(true);
            // 将信息面板设置为Canvas的最高显示顺序
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
        print("鼠标进入了技能UI");
    }

    public void PointExitUI()
    {
        isHovering = false;
        print("鼠标退出了技能UI");
    }
}
