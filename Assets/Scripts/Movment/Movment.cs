using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Movment : MonoBehaviour
{
    [SerializeField] float jumpForce = 6f;
    [SerializeField] float defualtSpeed = 3.5f;
    [SerializeField] float sprintSpeed = 6f;
    [SerializeField] float speed = 3.5f;

    [SerializeField] float gravity = 9.81f;
    [SerializeField] InputAction moveAction;
    [SerializeField] InputAction jumpInput;
    [SerializeField] InputAction sprintInput;


    private CharacterController cc;
    private void OnEnable()
    {
        moveAction.Enable();
        jumpInput.Enable();
        sprintInput.Enable();
    }

    private void OnDisable() { moveAction.Disable(); }


    void OnValidate()
    {
        // Provide default bindings for the input actions.
        // Based on answer by DMGregory: https://gamedev.stackexchange.com/a/205345/18261
        if (moveAction == null)
            moveAction = new InputAction(type: InputActionType.Button);
        if (jumpInput == null)
            jumpInput = new InputAction(type: InputActionType.Button);
        if (sprintInput == null)
            sprintInput = new InputAction(type: InputActionType.Button);
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
        speed = defualtSpeed;
    }


    Vector3 velocity = new Vector3(0, 0, 0);

    // Update is called once per frame
    void Update()
    {
        if (sprintInput.WasPressedThisFrame())
        {
            speed = sprintSpeed;
            Debug.Log(speed);
        }

        if (sprintInput.WasReleasedThisFrame())
        {
            speed = defualtSpeed;
            Debug.Log(speed);
        }


        Vector3 movement = moveAction.ReadValue<Vector2>(); // Implicitly convert Vector2 to Vector3, setting z=0.
        velocity.x = movement.x * speed;
        velocity.z = movement.y * speed;
        if (cc.isGrounded)
        {

            if (jumpInput.WasPerformedThisFrame())
            {
                velocity.y = jumpForce;
            }
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime;
        }



        // Move in the direction you look:
        velocity = transform.TransformDirection(velocity);

        cc.Move(velocity * Time.deltaTime);
    }
}
