using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Stats : MonoBehaviour
{
    
    public int goal;
    
    
    [SerializeField, TagSelector] string enemyMinionTag;
    
    
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
            OnCountUpdate?.Invoke(value);

            if (_count >= goal)
            {
                OnWin?.Invoke();
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
            OnHpUpdate?.Invoke(value);

            if (_hp <= 0)
            {
                OnDie?.Invoke();
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
            var respawnProfit = other.GetComponent<RespawnProfit>();
            respawnProfit.Pick();
            Count = Count + 1;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag (enemyMinionTag))
        {
            Hp = Hp - 1;
        }
    }


}
