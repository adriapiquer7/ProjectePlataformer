using System;
using UnityEngine;

public class BalaScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private PlayerScript _player;

    private float _posicioXPlayer;


    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.linearVelocity = Vector2.right*Speed;
    }

    public void Disparar(Transform player, Vector3 direccio, float velocitat, float dmg)
    {
        
    }

    void Update()
    {
        _posicioXPlayer = _player.transform.position.x;
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
}
