using System;
using Unity.VisualScripting;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField]
    private float _dany;

    [SerializeField]
    private float _velocitat;

    void Update()
    {
        transform.Translate(Vector2.right*_velocitat*Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemic"))
        {
            other.gameObject.GetComponent<Enemic>().HacerDaño(_dany);
            Destroy(gameObject);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
