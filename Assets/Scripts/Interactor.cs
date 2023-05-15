using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    [SerializeField] LayerMask interactableLayerMask;
    [SerializeField] InputAction interactionInput = new InputAction(type: InputActionType.Button);
    [SerializeField] float distance = 2f;
    [SerializeField] TextUI playerUi;

    Interactable interactable;

    bool IsCloseToInteractable(out RaycastHit hit) => Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance, interactableLayerMask);
    string GetInteractableText(Interactable interactable) => "Press " + interactionInput.GetBindingDisplayString() + " " + interactable.promptMessage;


    private void OnEnable()
    {
        interactionInput.Enable();
    }

    private void OnDisable()
    {
        interactionInput.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        playerUi.Clear();

        RaycastHit hit;
        // out for sending by reference
        if (IsCloseToInteractable(out hit))
        {
            if (hit.collider.GetComponent<Interactable>() is not null)
            {
                interactable = hit.collider.GetComponent<Interactable>();
                playerUi.UpdateText(GetInteractableText(interactable));

                if (interactionInput.WasPerformedThisFrame())
                {
                    interactable.BaseInteract(gameObject);
                }
            }
        }
    }
}
