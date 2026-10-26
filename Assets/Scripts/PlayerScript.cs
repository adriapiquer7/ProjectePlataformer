using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [Header("Vida Player")]
    [SerializeField]
    private int hp = 10;
    [SerializeField]
    private float speed = 4f;
    [SerializeField]
    private float jump = 4f;
    [SerializeField]
    private int municion = 25;
    
    [Header("Moviment basic")]
    [SerializeField]
    private Transform _player;

    [Header("Moviment personalitzat")]
    [SerializeField]
    private InputActionReference _Jump;
    [SerializeField]
    private InputActionReference _Moure;
    [SerializeField]
    private InputActionReference _disparar;   

    private Rigidbody2D _rigidbody2D;
    private bool _estaAlTerra;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Suelo"))
        {
            _estaAlTerra = true;
        }else if (collision.gameObject.CompareTag("Plataformas"))
        {
            _estaAlTerra = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Suelo"))
        {
            _estaAlTerra = false;
        }
    }

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        _Jump.action.performed += Saltar;
    }

    void OnDisable()
    {
        _Jump.action.performed -= Saltar;
    }


    private void Saltar(InputAction.CallbackContext context)
    {
        if (_estaAlTerra)
        {
            _rigidbody2D.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Vector2 joystick = _Moure.action.ReadValue<Vector2>();
        _rigidbody2D.linearVelocityX = joystick.x * speed;
    }
}
