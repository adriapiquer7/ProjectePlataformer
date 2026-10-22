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
