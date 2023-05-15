using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoInteractable : Interactable
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Interact(GameObject interactor)
    {
        var inventory = interactor.GetComponent<WeaponInventory>();
        if (inventory is null) return;

        var currentWeapon = inventory.currentWepon;
        if (currentWeapon is null) return;

        var weaponShooting = currentWeapon.GetComponent<WeaponShooting>();
        if (weaponShooting is null) return;

        weaponShooting.MaxAmmo();
    }

}
