using UnityEngine;
using UnityEngine.PlayerLoop;

public class Enemigo : MonoBehaviour
{

    [SerializeField]
    private float _speed = 0.1f;

    private float _timeMove = 0;

    private float _timeMoveTMP = 0;

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
        transform.Translate(transform.transform.localPosition.x + (1*_speed), 0 , 0);
    }

    void direccioNova()
    {
        _timeMove -= _timeMoveTMP;
        _timeMoveTMP = Random.Range(3,11);
        float moviment = Random.Range(1,3);

        if(moviment == 1)
        {
            _speed = 0.2f;
        } else
        {
            _speed = -0.2f;
        }

    }

}
