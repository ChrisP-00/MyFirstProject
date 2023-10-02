using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButtonForPool : MonoBehaviour
{

    [SerializeField] MonsterNormalFactory monsterNormalFactory = null;

    public void GenerateShortMonster()
    {
        monsterNormalFactory.Spawn((Monster_Normal.SHORT_RANGE));
    }


    public void GenerateLongMonster()
    {
        monsterNormalFactory.Spawn((Monster_Normal.LONG_RANGE));
    }

    public void GenerateEliteMonster()
    {
        monsterNormalFactory.Spawn((Monster_Normal.ELITE));
    }

}
