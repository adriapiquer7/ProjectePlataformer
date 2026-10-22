using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorBalas : MonoBehaviour
{
    [SerializeField]
    private InputActionReference _Moure;

    void Update()
    {
        Vector2 joystick = _Moure.action.ReadValue<Vector2>();

        if (joystick.y > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 90);
        }
        else
        {
            transform.localEulerAngles = new Vector3(0,0,0);
        }
    }
}
