using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIntactable : Interactable
{
    [SerializeField] WeaponInventory player;

    // Start is called before the first frame update
    void Start()
    {

    }

    protected override void Interact(GameObject interactor)
    {
        if (player.GrapWepon(gameObject))
            GetComponent<WeaponShooting>().enabled = true;
    }


}
