using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggergatecontroller : MonoBehaviour
{
    [SerializeField] private Animator _gate = null;
    [SerializeField] private bool openTrigger = false;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                _gate.Play("gateopen", 0, 0.0f);
                gameObject.SetActive(false);

            }
        }
    }


}

