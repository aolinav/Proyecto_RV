using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed;
    
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);
    
        if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            //para que mire hacia donde apunta el joystick
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            //poner animacion movimiento
        }
        //else{ poner animacion standBy}
    }
}
