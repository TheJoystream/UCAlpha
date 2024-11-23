using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private Rigidbody _rigidbody;
    private PlayerAwareness _playerAwareness;
    private Vector3 _targetDirection;

    // Start is called before the first frame update
    private  void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerAwareness = GetComponent<PlayerAwareness>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()

    {
        if (_playerAwareness.AwareOfPlayer)
        {
            _targetDirection = _playerAwareness.DirectionToPlayer;
        }
        else
        {
            _targetDirection = Vector3.zero;
        }
    }
    
    
    

    private void RotateTowardsTarget()
    {

        if (_targetDirection == Vector3.zero)
        {
            return;
        }
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        _rigidbody.MoveRotation(rotation);
    }

    private void SetVelocity()
    {
        if (_targetDirection == Vector3.zero)
        {
            _rigidbody.velocity = Vector3.zero;
        }
        else
        {
            _rigidbody.velocity = transform.up * _speed;
        }

    }


    



}
