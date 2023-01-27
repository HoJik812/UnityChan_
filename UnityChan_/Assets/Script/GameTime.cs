using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour//게임의 시간 흐름을 담당하는 클래스
{
    private int time;
    private int day;
    
    public int Time
    {
        get {
            
            if (time == 5)
            {
               day++;
               time = 1;
               Debug.Log("하루가 지났습니다");
               
            } 
            return time; 
        }
        set { time = value;}
    }

    public int Day
    {
        get { return day; }     
        set { day = value; }
    }

    private void Awake()
    {
        day = 1;
        time = 2;
       
    }

 }
