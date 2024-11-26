using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    public AudioSource footstepSound;
    public GameObject player;

    private void Update()
    {
        if (player.GetComponent<Character>().isMoving == true)
        {
            footstepSound.Play();
        }

    }
}
