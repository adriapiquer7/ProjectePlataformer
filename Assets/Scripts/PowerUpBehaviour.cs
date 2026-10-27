using UnityEngine;

public class PowerUpBehaviour : MonoBehaviour
{
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

}
