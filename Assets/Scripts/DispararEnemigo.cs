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

    void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Ha entrat");

        if(collision.gameObject.CompareTag("Player"))
        {
            enemigo.SetSpeed(0);
            //Instantiate(_bala, _controladorDisparo.position, _controladorDisparo.rotation);

        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(enemigo.transform.position.x > collision.gameObject.transform.position.x) {
                enemigo.SetSpeed(-1);
                Debug.Log("Izq");

            } 
            //Moverse derecha
            else if(enemigo.transform.position.x < collision.gameObject.transform.position.x) {
                enemigo.SetSpeed(1);
                Debug.Log("Der");

            }
    }
}
