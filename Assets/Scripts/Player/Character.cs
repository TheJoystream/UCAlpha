using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterController characterController;
    public bool isMoving = false;
    public float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        characterController.Move(move * Time.deltaTime * speed);

        if(Input.anyKeyDown)
        {
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.LeftShift) & isMoving == true)
        {
            characterController.Move(move * Time.deltaTime * speed * 2);
        }
    }
}
