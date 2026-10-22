using UnityEngine;

public class CamaraSa : MonoBehaviour
{
    [SerializeField] private Transform objetivo;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);

    void Update()
    {
        transform.position = objetivo.position+offset;
    }
}
