using System;
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

    public void HacerDaño(float _daño)
    {
        _vida-=_daño;
        if(_vida<=0)
        {
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
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

    void Update()
    {
        
        if(_direccion != 0)
        {
            SetSpeed(_direccion);
        }

    }

}
