using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Monster_Normal
{
    SHORT_RANGE,
    LONG_RANGE,
    ELITE
}

public class MonsterNormalFactory : MonsterFactory<Monster_Normal>
{
    [SerializeField] private GameObject monsterShortRangePrefab = null;
    [SerializeField] private GameObject monsterLongRangePrefab = null;
    [SerializeField] private GameObject monsterElitePrefab = null;

    protected override Monster GenerateMonster(Monster_Normal type)
    {
        Monster monster = null;
        switch (type)
        {
            case Monster_Normal.SHORT_RANGE:
                // bring object from pool
                Debug.Log("monster short!");
                MonsterPoolManager.Inst.BringObject(monsterShortRangePrefab);
                break;

            case Monster_Normal.LONG_RANGE:
                // bring object from pool
                Debug.Log("monster Long!");
                MonsterPoolManager.Inst.BringObject(monsterLongRangePrefab);
                break;

            case Monster_Normal.ELITE:
                // bring object from pool
                Debug.Log("monster Elite!");
                MonsterPoolManager.Inst.BringObject(monsterElitePrefab);
                break;
        }
        return monster;
    }
}
