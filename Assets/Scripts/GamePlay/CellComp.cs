using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CellComp : MonoBehaviour, IPointerClickHandler
{
    public int Row_Id;
    public int Col_Id;
    public Text DebugText;

    private RectTransform rect;
    private BoardMapCtrl boardCtrl;

    public void Init(int row, int col, Vector2 size, BoardMapCtrl board)
    {
        this.rect = this.transform as RectTransform;
        this.Row_Id = row;
        this.Col_Id = col;
        this.rect.sizeDelta = size;
        this.boardCtrl = board;
        this.DebugText.text = string.Format("{0},{1}", row.ToString(), col.ToString());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (boardCtrl != null)
        {
            this.boardCtrl.OnCellClick(this.Row_Id, this.Col_Id);
        }
    }

    private void Awake()
    {
        this.rect = this.transform as RectTransform;
    }

    private void Start()
    {
        this.DebugText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
