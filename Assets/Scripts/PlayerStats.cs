using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class PlayerStats : MonoBehaviour
{
    
    public int goal;
    
    public delegate void CountUpdate(int hp);
    public CountUpdate OnCountUpdate;

    public delegate void WinUpdate();

    public WinUpdate OnWin;

    private int _count;
    public int Count
    {
        get => _count;
        set
        {
            _count = value;
            OnCountUpdate(value);

            if (_count >= goal)
            {
                OnWin();
            }
            
        }
    }
    
    public delegate void HpUpdate(int hp);
    public HpUpdate OnHpUpdate;

    //Another simpler way to create events without delegates
    public event Action OnDie; 
    
    private int _hp;
    public int Hp
    {
        get { return _hp; }
        set
        {
            _hp = value;
            OnHpUpdate(value);

            if (_hp <= 0)
            {
                OnDie.Invoke();
            }
        }
    }
    
    

    
    // Start is called before the first frame update
    void Start()
    {
        Count = 0;
        Hp = 3;
    }


    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Profit Object"))
        {
            other.transform.position = new Vector3(Random.Range(-9.0f, 9.0f), 0.5f, Random.Range(-9.0f, 9.0f));
            Count = Count + 1;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag ("Minion Enemigo"))
        {
            Hp = Hp - 1;
        }
    }


}