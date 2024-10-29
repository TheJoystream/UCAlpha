using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class playerInventory : MonoBehaviour
{
    public bool hasKey;
    public float hasKeys;
    public int keysAmount { get; private set; }
    public int NumberOfRocks { get; private set; }
    public int NumberOfKeys { get; private set; }

    public UnityEvent<playerInventory> OnRockCollected;
    public UnityEvent<playerInventory> OnKeyCollected;

    private void Start()
    {
        
    }

    public void RockCollected()
    {
        NumberOfRocks++;
        OnRockCollected.Invoke(this);
    }


    public void KeyCollected()
    {

        keysAmount++;
        OnKeyCollected.Invoke(this);
    }
    public void Update()
    {

   
    }

    public void OnTriggerEnter(Collider other)
    {
        if(NumberOfKeys >= 0)
        {
            hasKey = true;
            
        }
        
    }
    
}
     



