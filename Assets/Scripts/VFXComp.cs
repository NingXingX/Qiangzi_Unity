using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXComp : MonoBehaviour
{
    public List<Vector2> Path = new List<Vector2>();
    public float Length;

    private RectTransform rect;
    private float t;
    private float pathLen;

    private void Awake()
    {
        this.rect = this.transform as RectTransform;
    }

    void Start()
    {
        this.t = 0;
        this.rect.localScale = Vector3.one;
        this.rect.anchoredPosition = Path[0];
        this.pathLen = 0f;
        for (int i = 1; i < this.Path.Count; ++i)
        {
            this.pathLen += Vector2.Distance(this.Path[i], this.Path[i - 1]);
        }
        Destroy(this.gameObject, Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Path.Count == 1)
        {
            this.rect.anchoredPosition = this.Path[0];
            return;
        }
        this.t += Time.deltaTime;
        float curLen = this.t / this.Length * this.pathLen;
        float sumLen = 0;
        for (int i = 1; i < this.Path.Count; ++i) //想优化可以改前缀和（（（（（
        {
            float dis = Vector2.Distance(this.Path[i], this.Path[i - 1]);
            if (sumLen + dis < curLen)
            {
                sumLen += dis;
                continue;
            }
            float curT = (curLen - sumLen) / dis;
            this.rect.anchoredPosition = Vector2.Lerp(this.Path[i], this.Path[i - 1], curT);
        }
    }
}
