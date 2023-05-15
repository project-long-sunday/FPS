using Assembly_CSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponShooting : MonoBehaviour
{
    [SerializeField] int magSize;
    [SerializeField] int totalMags;
    [SerializeField] BulletController bullet;
    [SerializeField] Transform bulletExitPoint;
    [SerializeField] TextUI magsUi;
    [SerializeField] TextUI promptUi;


    [SerializeField] InputAction fireInput = new InputAction(type: InputActionType.Button);
    [SerializeField] InputAction reloadInput = new InputAction(type: InputActionType.Button);


    int currentMag;
    int magsLeft;
    private void OnEnable()
    {
        fireInput.Enable();
        reloadInput.Enable();
    }

    private void OnDisable()
    {
        fireInput.Disable();
        reloadInput.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        magsLeft = totalMags;
        currentMag = magSize;
        magsUi.UpdateText(currentMag + " / " + magsLeft * magSize);
    }


    // Update is called once per frame
    void Update()
    {
        if (fireInput.WasPerformedThisFrame() && currentMag > 0)
        {
            Shoot();
            currentMag--;
            if (currentMag == 0)
            {
                // show reaload text
                promptUi.UpdateText("Reload");
            }
        }

        if (reloadInput.WasPerformedThisFrame() && currentMag < magSize)
        {
            if (magsLeft > 0)
            {
                currentMag = magSize;
                magsLeft--;
            }
            promptUi.UpdateText("");
        }
        magsUi.UpdateText(currentMag + " / " + magsLeft * magSize);
    }

    private void Shoot()
    {
        BulletController b = Instantiate(bullet, bulletExitPoint.position, bulletExitPoint.transform.rotation);
        b.speed = 15f;
        b.direction = Camera.main.transform.forward;
    }


    public void MaxAmmo()
    {
        currentMag = magSize;
        magsLeft = totalMags;
    }

}
