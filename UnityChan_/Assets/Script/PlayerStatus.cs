using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    private int health;//ü��
    [SerializeField]
    private int str;//��
    [SerializeField] 
    private int intel;//����
    [SerializeField]
    private int maxHealth = 100;
    public int Health
    {
        get
        {
            if (health >= maxHealth)//�ִ�ü�º��� �������� �ʰ�
            {
                health = maxHealth;
            }
            else if(health <=0)//0 ������ �������� �ʰ�
            {
                health = 0;
            }
                return health;
        }
        set {
                health = value;
            }
    }

    public int Str
    {
        get {
             if(str <=0)
            {
                str = 0;
            }
            return str; } 
        set { str = value; }
    }
    public int Intel
    {
        get {
            if(intel <=0)
            {
                intel = 0;
            }
            return intel; }   
        set { intel = value; }
    }

    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    private void Awake()
    {
        health = maxHealth;
        str = 10;
        intel = 10;  
    }


}
