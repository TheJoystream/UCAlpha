using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerInventory : MonoBehaviour
{
    public int NumberOfRocks { get; private set; }

    public UnityEvent<playerInventory> OnRockCollected;

    public void RockCollected()
    {
        NumberOfRocks++;
        OnRockCollected.Invoke(this);
    }
}
