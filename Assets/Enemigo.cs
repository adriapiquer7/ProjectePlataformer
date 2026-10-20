using UnityEngine;
using UnityEngine.PlayerLoop;

public class Enemigo : MonoBehaviour
{

    [SerializeField]
    private float _speed = Random.Range(1.2f,1.8f);

    private float _timeMove = 0;

    private float _timeMoveTMP = Random.Range(2f,6f);

    [SerializeField]
    private float _vida;

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
        direccio();
        _timeMove += Time.deltaTime;
        if (_timeMove >= _timeMoveTMP)
        {
            direccioNova();
        }
    }

    void direccio()
    {
        

        int opDireccio = (int) Random.Range(1f,3f);

        if(opDireccio == 1)
        {
            transform.Translate(Vector2.left*_speed*Time.deltaTime);
        } else
        {
            transform.Translate(Vector2.right*_speed*Time.deltaTime);
        }
    }

    void direccioNova()
    {
        _timeMove -= _timeMoveTMP;
        _timeMoveTMP = Random.Range(2f,6f);
        _speed = Random.Range(1.2f,2.2f);

    }

}
