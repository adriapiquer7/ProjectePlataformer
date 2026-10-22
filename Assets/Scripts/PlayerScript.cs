using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [Header("Stats Player")]
    [SerializeField]
    private float speed = 4f;
    [SerializeField]
    private float jump = 4f;
    
    [Header("Moviment personalitzat")]
    [SerializeField]
    private InputActionReference _Jump;
    [SerializeField]
    private InputActionReference _Moure;  

    private Rigidbody2D _rigidbody2D;
    private bool _estaAlTerra;
    private bool _mirandoDerecha = true;
    private Vector2 _direccioPlayer;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Suelo"))
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
        Mover(joystick.x);
    }

    private void Mover(float mover)
    {   
        if(mover>0 && !_mirandoDerecha){
            Girar();
        }
        else if(mover < 0 && _mirandoDerecha)
        {
            Girar();
        }
    }
    private void Girar()
    {
        _mirandoDerecha=!_mirandoDerecha;
        //aixo ho he tret d'un video de youtube, gira el player i els seus components.
        // ho faig servir per poder disparar on estta mirant el player
        transform.eulerAngles = new Vector3(0,transform.eulerAngles.y+180,0);
    }
}
