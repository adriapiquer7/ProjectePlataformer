using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header ("Tiempo nivel")]
    [SerializeField]
    private int tiempoNivel = 100;
    public PlayerScript _jugador;

    void Start()
    {
        StartCoroutine(deathCounter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator deathCounter()
    {
        int tiempo = tiempoNivel;

        while (tiempo > 0)
        {
            ManagerUI.Instance.UpdateTimer(tiempo);
            yield return new WaitForSeconds(1f);
            tiempo--;
        }

        ManagerUI.Instance.UpdateTimer(0);
        _jugador.morir();

        yield return new WaitForSeconds(2f);
        //ManagerUI.Instance.MostrarGameOver();
    } 
}
