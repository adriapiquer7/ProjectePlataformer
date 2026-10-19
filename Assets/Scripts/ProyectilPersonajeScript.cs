using UnityEngine;
using UnityEngine.InputSystem;

public class ProyectilPersonajeScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _objeto;
    [SerializeField]
    private float _tiempoEntreBala;
    [SerializeField]
    private PlayerScript _player;

    private float _posicioXPlayer;

    private float _tiempoReal;

    void Update()
    {
        _posicioXPlayer = _player.transform.position.x;
        _tiempoReal+=Time.deltaTime;
        if (_tiempoReal >= _tiempoEntreBala)
        {
            _tiempoReal-=_tiempoEntreBala;
            GameObject objetoInstanciat = Instantiate(_objeto);
            objetoInstanciat.transform.position = new Vector2 (_posicioXPlayer,0);
        }
    }


}
