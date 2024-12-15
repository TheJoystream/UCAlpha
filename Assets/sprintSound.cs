using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprintSound : MonoBehaviour
{
    public AudioSource sprintingSound;

    public GameObject player;


    private void Update()
    {
        bool isMoving = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);

        sprintingSound.enabled = isMoving && isSprinting;

    }
}