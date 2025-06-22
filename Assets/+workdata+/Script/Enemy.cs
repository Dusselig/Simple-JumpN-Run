using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    Rigidbody2D _enemyRigidBody2D;
    private readonly int _unitsToMove = 2;
    private readonly float _enemySpeed = 50;
    private bool _isFacingInRightDir;
    private bool _moveRight = true;
    [SerializeField]private float startPos;
    [SerializeField]private float endPos;
    
    
    public void Awake()
    {
        _enemyRigidBody2D = GetComponent<Rigidbody2D>();
        startPos = transform.position.x;
        endPos = startPos + _unitsToMove;
        _isFacingInRightDir = transform.localScale.x > 0;
    }
    public void Update()
    {

        if (_moveRight)
        {
            _enemyRigidBody2D.AddForce(Vector2.right * (_enemySpeed * Time.deltaTime));
            if (!_isFacingInRightDir)
                Flip();
        }

        if (_enemyRigidBody2D.position.x >= endPos)
            _moveRight = false;

        if (!_moveRight)
        {
            _enemyRigidBody2D.AddForce(-Vector2.right * (_enemySpeed * Time.deltaTime));
            if (_isFacingInRightDir)
                Flip();
        }

        if (_enemyRigidBody2D.position.x <= startPos)
        {
            _moveRight = true;
        }

        if (_enemyRigidBody2D.position.y <= -1)
        {
            Destroy(gameObject);
        }
    }

    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _isFacingInRightDir = transform.localScale.x > 0;
    }
}
