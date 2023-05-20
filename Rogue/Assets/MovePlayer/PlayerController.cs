using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (BoxCollider))]

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private CharacterController _xxx;
    public float SpeedRoration;
    //[SerializeField] private Animator _animator;

    [SerializeField] private float _moveSpeed;

    private void FixedUpdate()
    {
        //_rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);
        var moveright = transform.right * _joystick.Horizontal * _moveSpeed;
        var moveforward = transform.forward * _joystick.Vertical * _moveSpeed;
        //var movement = new Vector3(_joystick.Horizontal * _moveSpeed, 0, _joystick.Vertical * _moveSpeed);
        var movement = moveright + moveforward;
        _xxx.Move(Physics.gravity*Time.fixedDeltaTime*100);
        _xxx.Move(movement*Time.fixedDeltaTime);

        

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), SpeedRoration * Time.fixedDeltaTime);                    
        //    _animator.SetBool("isRunning", true);
        }
        //else
        //    _animator.SetBool("isRunning", false);

        
    }
}
