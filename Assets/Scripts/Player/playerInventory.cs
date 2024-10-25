using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class playerInventory : MonoBehaviour
{
    public int NumberOfRocks { get; private set; }
    public int NumberOfKeys { get; private set; }

    public UnityEvent<playerInventory> OnRockCollected;
    public UnityEvent<playerInventory> OnKeyCollected;

    public void RockCollected()
    {
        NumberOfRocks++;
        OnRockCollected.Invoke(this);
    }


    public void KeyCollected()
    {

    NumberOfKeys++;
        OnKeyCollected.Invoke(this);
    }


}
