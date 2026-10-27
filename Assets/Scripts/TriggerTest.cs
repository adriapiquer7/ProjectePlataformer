using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"He entrat {collision.gameObject}");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log($"He sortit {collision.gameObject}");
    }
}
