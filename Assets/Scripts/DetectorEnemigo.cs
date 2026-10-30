
using System.Numerics;
using UnityEngine;

public class DetectorEnemigo : MonoBehaviour
{

    [SerializeField]
    private Enemigo enemigo;

    void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Ha entrat");

        if(collision.gameObject.CompareTag("Player"))
        {

            // He buscado este comando para poder saber desde donde te ha tocado el enemigo para poder
            // saber en que direccion moverse el enemigo.
            // Lo que hace es mostrarte el primero punto de contacto


            //Esto es para moverse respecto donde esta el enemigo
            //Moverse izquierda
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
    void OnTriggerExit2D()
    {
        Debug.Log("Ha surtit");
        enemigo.SetSpeed(0);
    }
}
