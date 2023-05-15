using UnityEngine;
using UnityEngine.InputSystem;

public class GernadeThrower : MonoBehaviour
{


    [SerializeField] float throwForce = 40f;
    [SerializeField] InputAction throwAction = new InputAction(type: InputActionType.Button);
    [SerializeField] GameObject gernade;
    [SerializeField] GameObject throwPosition;

    private void OnEnable()
    {
        throwAction.Enable();
    }

    private void OnDisable()
    {
        throwAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (throwAction.WasPerformedThisFrame())
        {
            ThrowGernade();
        }
    }

    void ThrowGernade()
    {
        GameObject g = Instantiate(gernade, throwPosition.transform.position, throwPosition.transform.rotation);
        Rigidbody rb = g.GetComponent<Rigidbody>();
        if (rb is not null)
        {
            rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
        }
    }
}
