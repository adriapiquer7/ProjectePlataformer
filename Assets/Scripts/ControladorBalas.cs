using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorBalas : MonoBehaviour
{
    [SerializeField]
    private InputActionReference _Moure;
    /*
    Aquest script serveix per poder moure "l'arma" y poder disparar cap a dalt i abaix, cap a dreta i
    esquerra es gestiona al PlayerScript.
    */
    void Update()
    {
        Vector2 joystick = _Moure.action.ReadValue<Vector2>();

        if (joystick.y > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 90);
        }
        else if (joystick.y < 0)
        {
            transform.localEulerAngles = new Vector3(0,0,-90);
        }
        else
        {
            transform.localEulerAngles = new Vector3(0,0,0);
        }
    }
}
