using UnityEngine;

public class BalaEnemic : MonoBehaviour
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
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerScript>().HacerDaño(_dany);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
