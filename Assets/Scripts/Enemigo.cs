using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;


public class Enemigo : MonoBehaviour
{

    [SerializeField]
    private float _speed = 4;

    [SerializeField]
    private float _vida;

    private Rigidbody2D _rigidbody2d;

    private int _direccion = 0;

    [Header("Animacion")]
    private Animator _animator;
    private bool _mirandoDerecha = true;

    private Coroutine _hitCoroutine;
    private bool _IsDead = false;

    void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    
    void Start()
    {
        SetSpeed(0);
    }
    public void SetSpeed(int direccion)
    {
        _direccion = direccion;
        _rigidbody2d.linearVelocityX = _speed * direccion;
    }

        private void FixedUpdate()
    {
        if (_IsDead) return;

        _rigidbody2d.linearVelocityX = _direccion * _speed;

        Mover(_direccion);

        if (_direccion != 0)
            PlayAnimation("Run");
        else
            PlayAnimation("Idle");
    }
    private void Mover(float mover)
    {
        if (mover > 0 && !_mirandoDerecha) 
            Girar();
        else if (mover < 0 && _mirandoDerecha) 
            Girar();
    }
    private void Girar()
    {
        _mirandoDerecha = !_mirandoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }
    private void PlayAnimation(string animation)
    {
        if (_IsDead)
            return;

        if (_hitCoroutine is null)
            _animator.Play(animation);
    }
    public void HacerDaño(float _daño)
    {
        if (_IsDead) return;

        _vida -= _daño;

        if (_vida <= 0)
        {
            _IsDead = true;
            if (_hitCoroutine is not null)
                StopCoroutine(_hitCoroutine);
            StartCoroutine(DeadCoroutine());
        }
        else
        {
            if (_hitCoroutine is not null)
                StopCoroutine(_hitCoroutine);
            _hitCoroutine = StartCoroutine(HitCoroutine());
        }
    }
    private IEnumerator HitCoroutine()
    {
        _animator.Play("Hit");
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        _hitCoroutine = null;
    }

    private IEnumerator DeadCoroutine()
    {
        _rigidbody2d.linearVelocity = Vector2.zero;
        _rigidbody2d.simulated = false;
        _animator.Play("Dead");
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        Destroy(gameObject);
    }
}
