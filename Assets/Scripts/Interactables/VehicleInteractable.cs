using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleInteractable : Interactable
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject _camera;
    [SerializeField] Transform existPosition;
    [SerializeField] TextUI playerUI;

    [SerializeField] InputAction existAction = new InputAction(type: InputActionType.Button);

    private void OnDisable()
    {
        existAction.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (existAction.WasPerformedThisFrame())
        {
            ExistVechicle();
        }
    }

    void ExistVechicle()
    {

        GetComponent<VehicleMovment>().enabled = false;
        //GetComponent<WheelController>().enabled = false;

        _camera.SetActive(false);
        player.SetActive(true);
        player.transform.SetParent(null);
        Debug.Log("POS " + existPosition.transform.position);
    }


    protected override void Interact(GameObject interactor)
    {
        // Hide player 
        player.transform.SetParent(transform);
        player.SetActive(false);
        player.transform.position = existPosition.transform.position;

        // Set camera positon 
        _camera.SetActive(true);

        // enable exist the veichle inputs
        existAction.Enable();

        // attach the vechiacle script
        GetComponent<VehicleMovment>().enabled = true;
        playerUI.Clear();
    }
}
