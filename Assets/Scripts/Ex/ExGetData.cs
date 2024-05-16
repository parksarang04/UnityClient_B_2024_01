using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExGetData : MonoBehaviour
{
    public Entity_monster monster;
    //Start is called before the first frame update
    void Start()
    {
        foreach(Entity_monster.Param param in monster.sheets[0].list)
        {
            Debug.Log(param.Index + " - " + param.name + " - " + param.hp + " - " + param.mp);
        }

    }
}
