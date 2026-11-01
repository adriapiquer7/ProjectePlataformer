using System;
using UnityEngine;

public class DispararEnemigo : MonoBehaviour
{
    [SerializeField]
    private Enemigo enemigo;
    [SerializeField]
    private GameObject _bala;
    [SerializeField] 
    private Transform _controladorDisparo;

    private Boolean _estaJugador = false;

    private float _temporizador;

    [SerializeField]
    private float _tiempoEntreDisparos = 1f;

    private float _contactoJugador;

    void Update()
{
    if  (_estaJugador)
    {
        _temporizador += Time.deltaTime;

        if(_temporizador >= _tiempoEntreDisparos)
        {
            _temporizador = 0;

            Disparar();
        }
    }
}

    void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Ha entrat");

        if(collision.gameObject.CompareTag("Player"))
        {

            _estaJugador = true;
            enemigo.SetSpeed(0);
            _contactoJugador = collision.gameObject.transform.position.x;
            
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) {
            _estaJugador = false;

            if(enemigo.transform.position.x > collision.gameObject.transform.position.x) {
                    enemigo.SetSpeed(-1);
                    Debug.Log("Moverse hacia izquierda");

                } 
                //Moverse derecha
                else if(enemigo.transform.position.x < collision.gameObject.transform.position.x) {
                    enemigo.SetSpeed(1);
                    Debug.Log("Moverse hacia derecha");

                }
        }
    }

    void Disparar ()
    {

            Debug.Log("Disparando");
                    //Disparar izquierda
            if(enemigo.transform.position.x > _contactoJugador) {
                
                Instantiate(_bala, _controladorDisparo.position, _controladorDisparo.rotation);

            } 
            //Disparar derecha
            else if(enemigo.transform.position.x < _contactoJugador) {
                
                Instantiate(_bala, _controladorDisparo.position, _controladorDisparo.rotation);

            }
    }
}
