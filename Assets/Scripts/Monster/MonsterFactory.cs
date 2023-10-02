using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// create monster with requested monster type 
public abstract class MonsterFactory<T> : MonoBehaviour
{
    public Monster Spawn(T type)
    {
        Monster monster = this.GenerateMonster(type);

        return monster;
    }


    protected abstract Monster GenerateMonster(T type);

}
