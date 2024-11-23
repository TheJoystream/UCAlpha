using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAwareness : MonoBehaviour
{
    private CharacterController characterController;
    public bool AwareOfPlayer { get; private set; }

    public Vector3 DirectionToPlayer {  get; private set; }

    [SerializeField]
    private float _playerAwarenessDistance;

    private Transform _player;

private void Awake()
    {
        _player = FindObjectOfType<Character>().transform;
    }

    private void Update()
    {
        Vector3 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= _playerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        
    }
       

    }
}
