using UnityEngine;
using UnityEngine.InputSystem;

public class DisparoJugador : MonoBehaviour
{
    [SerializeField] 
    private GameObject _bala;
    [SerializeField] 
    private Transform _controladorDisparo;
    [SerializeField] 
    private InputActionReference _disparo;

    /*
    Aquest script serveix per gestionar els dispars del jugador, recull l'input del boto per disparar,
    i gestiona amb Instantiate la creacio de bales cada cop que es clica el boto
    */
    void OnEnable()
    {
        _disparo.action.performed += Disparar;
    }

    void OnDisable()
    {
        _disparo.action.performed -= Disparar;
    }

    private void Disparar(InputAction.CallbackContext context)
    {

        Instantiate(_bala, _controladorDisparo.position, _controladorDisparo.rotation);

    }
}
