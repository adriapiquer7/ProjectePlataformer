using System;
using System.Collections;
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
    private float _speed = 4f;
    [SerializeField]
    private float _jump = 8f;
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
    private bool _estaAlTerra=true;
    private bool _mirandoDerecha = true;
    [Header("Animacion")]
    private Animator _animator;

    private Coroutine _hitCoroutine;

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Suelo"))
        {
            _estaAlTerra = true;
        } 
        else if (collision.gameObject.CompareTag("Plataformas"))
        {
            _estaAlTerra = true;
        }
        if (collision.gameObject.CompareTag("enemic"))
        {
            if(_hitCoroutine is not null)
                StopCoroutine(_hitCoroutine);
            _hitCoroutine = StartCoroutine(HitCoroutine());
        }
    }

    private void PlayAnimation(string animation)
    {
        if(_hitCoroutine is null)
            _animator.Play(animation);
    }


    private IEnumerator HitCoroutine()
    {
        _animator.Play("Hit");
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        _hitCoroutine = null;
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
            _rigidbody2D.AddForce(Vector2.up * _jump, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp"))
        {
            //StartCoroutine(ApplyPowerUp(other.GetComponent<PowerUpBehaviour>()));
        }
    }


    private void FixedUpdate()
    {
        //un update que recull el valor del moure del player, cada update es pasa el valor al moure 
        //i gestiona el gir
        Vector2 joystick = _Moure.action.ReadValue<Vector2>();
        _rigidbody2D.linearVelocityX = joystick.x * _speed;
        Mover(joystick.x);
        if (!_estaAlTerra)
        {
            if (_rigidbody2D.linearVelocityY > 0.1f)
                PlayAnimation("Jump");
            else
                PlayAnimation("Bajada");
        }
        else if (joystick.x != 0)
        {
            PlayAnimation("Run");
        }
        else
        {
            PlayAnimation("Idle");
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

    //private IEnumerator ApplyPowerUp(PowerUpBehaviour powerUp)
    //{
    //    //switch (powerUp.elegirTipoPowerUp())
    //    //{
    //    //    case PowerUpBehaviour._powerUpType.Speed:
    //    //        speed += 2f;
    //    //        yield return new WaitForSeconds(2f);
    //    //        speed -= 2f;
    //    //        break;
    //    //    case PowerUpBehaviour._powerUpType.Jump:
    //    //        jump += 2f;
    //    //        yield return new WaitForSeconds(2f);
    //    //        jump -= 2f;
    //    //        break;
    //    //    case PowerUpBehaviour._powerUpType.Ammo:
                
    //    //        int municionPrevia = municion;
    //    //        municion = 999;
    //    //        yield return new WaitForSeconds(2f);
    //    //        municion = municionPrevia;
    //    //        break;
    //    //    case PowerUpBehaviour._powerUpType.Health:
    //    //        int vidaPrevia = hp;
    //    //        hp = 999;
    //    //        yield return new WaitForSeconds(2f);
    //    //        hp = vidaPrevia;
    //    //        break;
    //    //}
    //}



}
