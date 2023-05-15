using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleMovment : MonoBehaviour
{
    [SerializeField] InputAction moveAction;
    [SerializeField] float speed = 20f;


    Vector3 velocity = new Vector3(0, 0, 0);
    CharacterController cc;

    private void OnEnable()
    {
        moveAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
    }

    void OnValidate()
    {
        // Provide default bindings for the input actions.
        // Based on answer by DMGregory: https://gamedev.stackexchange.com/a/205345/18261
        if (moveAction == null)
        {
            moveAction = new InputAction(type: InputActionType.Button);
        }
        if (moveAction.bindings.Count == 0)
            moveAction.AddCompositeBinding("2DVector")
                .With("Up", "<Keyboard>/W")
                .With("Down", "<Keyboard>/S")
                .With("Left", "<Keyboard>/A")
                .With("Right", "<Keyboard>/D");
    }

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 movement = moveAction.ReadValue<Vector2>();
        velocity.x = movement.x * speed;
        velocity.z = movement.y * speed;

        cc.Move(velocity * Time.deltaTime);
    }
}
