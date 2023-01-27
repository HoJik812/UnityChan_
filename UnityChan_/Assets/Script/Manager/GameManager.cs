using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    public PlayerStatus player;
    public float chance;//실패확률 변수
    private float ratio;//최대체력 대비 현재체력 비율

    private void Awake()
    {
        //base.Awake();
       EventManager.Instance.gameOpening.EventOn();//오프닝 실행!!
        //EventManager.Instance.superRest.EventOn();//오프닝 실행!!
        player = GetComponent<PlayerStatus>();        
    }


    private void Start()
    {
        chance = 0;
        ratio = 0;
    }

    private void Update()
    {
        UIManager.Instance.statusTest.text = "HP : " + player.Health + " / " + player.MaxHealth + "\n" + "Str : " + player.Str + "\n" + "Int : " + player.Intel;
        ratio = (float)player.Health / (float)player.MaxHealth * 10;//최대채력 비례 현재 체력 비율
        MakeChance(ratio);
        //Debug.Log("Chance = " + chance);
    }

    public void MakeChance(float f)//실패확률 측정 함수
    {
        if((f <= 5) && (4<f))
        {
            chance = 5;
        }
        else if((f<=4) && (3<f))
        {
            chance = 6;
        }
        else if((f<=3) && (2<f))
        {
            chance = 7;
        }
        else if((f<=2) && (1<f))
        {
            chance = 8;
        }
        else if((f<=1) && (0<f))
        {
            chance = 9;
        }
        else if(f == 0)
        {
            chance = 10;
        }
        else
        {
            chance = 0;
        }
    }
}
