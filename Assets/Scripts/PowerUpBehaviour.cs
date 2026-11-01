using UnityEngine;

public class PowerUpBehaviour : MonoBehaviour
{
    [SerializeField] private float amplitud = 0.1f;
    [SerializeField] private float velocidad = 0.5f;

    [Header("Sonidos")]
    [SerializeField] private float volumenSonido = 3f;
    [SerializeField] private AudioClip sonidoSpeed;
    [SerializeField] private AudioClip sonidoJump;
    [SerializeField] private AudioClip sonidoAmmo;
    [SerializeField] private AudioClip sonidoHealth;

    [Header("Sprites")]
    [SerializeField] private Sprite spriteSpeed;
    [SerializeField] private Sprite spriteJump;
    [SerializeField] private Sprite spriteAmmo;
    [SerializeField] private Sprite spriteHealth;

    private SpriteRenderer _spriteRenderer;
    private _powerUpType _tipo;

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

    public _powerUpType TipoPowerUp()
    {
        return _tipo;
    }

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _tipo = (_powerUpType)Random.Range(1, 5);
        AplicarSprite();
    }

    private void AplicarSprite()
    {
        switch (_tipo)
        {
            case _powerUpType.Speed:  _spriteRenderer.sprite = spriteSpeed;  break;
            case _powerUpType.Jump:   _spriteRenderer.sprite = spriteJump;   break;
            case _powerUpType.Ammo:   _spriteRenderer.sprite = spriteAmmo;   break;
            case _powerUpType.Health: _spriteRenderer.sprite = spriteHealth; break;
        }
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
            case _powerUpType.Speed:  clip = sonidoSpeed;  break;
            case _powerUpType.Jump:   clip = sonidoJump;   break;
            case _powerUpType.Ammo:   clip = sonidoAmmo;   break;
            case _powerUpType.Health: clip = sonidoHealth; break;
        }

        if (clip != null)
            AudioSource.PlayClipAtPoint(clip, transform.position, volumenSonido);
    }
}