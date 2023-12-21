using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterStateViewComp : MonoBehaviour
{
    public GameObject ChatacterStatePrefab;

    private List<ChaStatsPrefab> cs;

    private void Awake()
    {
        this.cs = new List<ChaStatsPrefab>();
    }

    void Update()
    {
        var roleDic = RoleSystem.Instance.GetRoleDic();

        int cnt = 0;

        foreach (var pair in roleDic)
        {
            ulong gid = pair.Key;
            Role role = pair.Value;

            if (role.TeamId == 2)
            {
                continue;
            }

            if (cnt == this.cs.Count)
            {
                this.AddNewCS();
            }

            this.cs[cnt].UpdateStatsInfo(role);
            ++cnt;
        }

        while (this.cs.Count > cnt)
        {
            int index = this.cs.Count - 1;
            var back = this.cs[index];
            Destroy(back.gameObject);
            this.cs.RemoveAt(index);
        }
    }

    private void AddNewCS()
    {
        var go = Instantiate(ChatacterStatePrefab, this.transform);
        this.cs.Add(go.GetComponent<ChaStatsPrefab>());
    }
}
