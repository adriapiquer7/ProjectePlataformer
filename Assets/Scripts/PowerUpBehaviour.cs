using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PowerUpBehaviour : MonoBehaviour
{

    [SerializeField] private float amplitud = 0.1f;
    [SerializeField] private float velocidad = 0.5f;


    [Header("Sonidos")]
    [SerializeField] private AudioClip sonidoSpeed;
    [SerializeField] private AudioClip sonidoJump;
    [SerializeField] private AudioClip sonidoAmmo;
    [SerializeField] private AudioClip sonidoHealth;


    private Vector2 posicionInicial;
    private Vector2 posicionActual;
    private float direccion = 1f;

    public enum _powerUpType
    {
        Speed = 1,
        Jump = 2,
        Ammo = 3,
        Health = 4
    }
    public _powerUpType elegirTipoPowerUp()
    {
        _powerUpType tipoPowerUp = (_powerUpType)Random.Range(1, 5);
        return tipoPowerUp;
    }

    void Start()
    {
        posicionInicial = transform.position;
        posicionActual = posicionInicial;
    }

    void Update()
    {
        posicionActual.y += direccion * velocidad * Time.deltaTime;

        if (posicionActual.y > posicionInicial.y + amplitud)
            direccion = -1f;
        else if (posicionActual.y < posicionInicial.y - amplitud)
            direccion = 1f;

        transform.position = posicionActual;
    }

    public void ReproducirSonido(_powerUpType tipo)
    {
        AudioClip clip = null;

        switch (tipo)
        {
            case _powerUpType.Speed: clip = sonidoSpeed; break;
            case _powerUpType.Jump: clip = sonidoJump; break;
            case _powerUpType.Ammo: clip = sonidoAmmo; break;
            case _powerUpType.Health: clip = sonidoHealth; break;
        }

        if (clip != null)
            AudioSource.PlayClipAtPoint(clip, transform.position);
    }


}
