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

    public void OnTriggerEnter2d(Collider2D other)
    {
         if (other.CompareTag("enemic"))
        {
            other.GetComponent<Enemic>().HacerDaño(_dany);
            Destroy(gameObject);
        }  
    }

}
