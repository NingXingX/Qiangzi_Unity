using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleComp : MonoBehaviour
{
    public int RowPos;
    public int ColPos;

    public ulong Gid;
    public int TeamId;

    public Role data;

    public void Init(int characterID, int level = 1)
    {
        this.data = new Role();
        this.data.Init(characterID, this, level);

    }

    public void AddComp(int equipId)
    {
        this.data.AddEquip(equipId);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
