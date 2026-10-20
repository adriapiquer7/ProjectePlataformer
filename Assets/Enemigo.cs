using UnityEngine;
using UnityEngine.PlayerLoop;

public class Enemigo : MonoBehaviour
{

    [SerializeField]
    private float _speed = 0.1f;

    private float _timeMove = 0;

    private float _timeMoveTMP = 0;

    [SerializeField]
    private float _vida;

    private Rigidbody2D _rigidbody2D;

    public void HacerDaño(float _daño)
    {
        _vida-=_daño;
        if(_vida<=0)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        _timeMove += Time.deltaTime;
        if (_timeMove < _timeMoveTMP && _timeMoveTMP != 0)
        {
            direccio();
        } else {
            direccioNova();
        }
    }

    void direccio()
    {
        _rigidbody2D.linearVelocityX = _speed;
    }

    void direccioNova()
    {
        _timeMove -= _timeMoveTMP;
        _timeMoveTMP = Random.Range(2f,6f);
        float opDireccio = Random.Range(1f,3f);

        float _moviment = Random.Range(0.2f,0.8f);

        if(opDireccio == 1)
        {
            _speed = _moviment;
        } else
        {
            _speed = -_moviment;
        }

    }

}
