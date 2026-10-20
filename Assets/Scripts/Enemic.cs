using UnityEngine;

public class Enemic : MonoBehaviour
{
    [SerializeField]
    private float _vida;

    public void HacerDaño(float _daño)
    {
        _vida-=_daño;
        if(_vida<=0)
        {
            Destroy(gameObject);
        }
    }
}
