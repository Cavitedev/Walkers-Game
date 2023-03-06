using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnProfit : MonoBehaviour
{
    public ProfitSpawner ProfitSpawner { get; set; }

    public void Pick()
    {
        ProfitSpawner.MoveProfitObject(transform);
    }
}
