using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [Header("Stats Player")]
    [SerializeField]
    private float _hp_max = 100;
    [SerializeField]
    private float _hp=100;
    [SerializeField]
    private float speed = 4f;
    [SerializeField]
    private float jump = 8f;
    
    [Header("Moviment personalitzat")]
    [SerializeField]
    private InputActionReference _Jump;
    [SerializeField]
    private InputActionReference _Moure;  

    private Rigidbody2D _rigidbody2D;
    private bool _estaAlTerra=true;
    private bool _mirandoDerecha = true;
    [Header("Animacion")]
    private Animator _animator;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //comprovacions per saber si pot saltar o no
        if(collision.gameObject.CompareTag("Suelo"))
        {
            _estaAlTerra = true;
        }
        if (collision.gameObject.CompareTag("enemic"))
        {
            _animator.Play("Hit");
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        //comprovacions per saber si pot saltar o no
        if(collision.gameObject.CompareTag("Suelo"))
        {
            _estaAlTerra = false;
        }
    }

    void Awake()
    {
        //agafem el component animator i rigidbody del player
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
    }

    void OnEnable()
    {
        //subscripcio del jump
        _Jump.action.performed += Saltar;
    }

    void OnDisable()
    {
        //desubscripcio del jump
        _Jump.action.performed -= Saltar;
    }


    private void Saltar(InputAction.CallbackContext context)
    {
        //input per poder saltar
        if (_estaAlTerra)
        {
            _rigidbody2D.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        //un update que recull el valor del moure del player, cada update es pasa el valor al moure 
        //i gestiona el gir
        Vector2 joystick = _Moure.action.ReadValue<Vector2>();
        _rigidbody2D.linearVelocityX = joystick.x * speed;
        Mover(joystick.x);
        if (!_estaAlTerra)
        {
            if (_rigidbody2D.linearVelocityY > 0.1f)
                _animator.Play("Jump");
            else
                _animator.Play("Bajada");
        }
        else if (joystick.x != 0)
        {
            _animator.Play("Run");
        }
        else
        {
            _animator.Play("Idle");
        } 
    }

    private void Mover(float mover)
    {   
        //aquesta funcio comprova amb les variables que he creat a dalt i les que lo arriben
        // cap a on mira el player i crida a la funcio girar. 
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
        //aquesta funcio gestiona el mirar cap a dreta o esquerra amb els seus components
        _mirandoDerecha=!_mirandoDerecha;
        //aixo ho he tret d'un video de youtube, gira el player i els seus components.
        // ho faig servir per poder disparar on estta mirant el player
        transform.eulerAngles = new Vector3(0,transform.eulerAngles.y+180,0);
    }
}
