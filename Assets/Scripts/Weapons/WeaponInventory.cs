using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponInventory : MonoBehaviour
{

    [SerializeField] int numberOfWeapons;
    [SerializeField] GameObject weaponPosition;
    [SerializeField] GameObject magsUi;
    [SerializeField] GameObject promptUi;

    [SerializeField] InputAction switchWeaponInput;
    [SerializeField] InputAction dropWeaponInput;

    List<GameObject> weapons = new List<GameObject>();
    public GameObject currentWepon { get; private set; }

    private void OnEnable()
    {
        switchWeaponInput.Enable();
        dropWeaponInput.Enable();
    }

    private void OnDisable()
    {
        switchWeaponInput.Disable();
        dropWeaponInput.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (switchWeaponInput.WasPerformedThisFrame())
        {
            switchWeapon();
        }

        if (dropWeaponInput.WasPerformedThisFrame())
        {
            DropWepon();
        }
    }

    private void switchWeapon()
    {
        if (weapons.Count == 1)
        {
            return;
        }

        currentWepon.SetActive(false);
        int index = weapons.IndexOf(currentWepon);
        currentWepon = weapons[(index + 1) % weapons.Count];
        currentWepon.SetActive(true);
    }


    public bool GrapWepon(GameObject obj)
    {
        if (weapons.Count == numberOfWeapons)
        {
            return false;
        }

        currentWepon?.SetActive(false);
        //obj = Instantiate(obj, transform.position, transform.rotation);
        obj.transform.SetParent(Camera.main.transform);
        obj.transform.position = weaponPosition.transform.position;
        obj.transform.rotation = weaponPosition.transform.rotation;
        obj.GetComponent<BoxCollider>().isTrigger = true;
        weapons.Add(obj);
        currentWepon = obj;
        obj.GetComponent<Rigidbody>().isKinematic = true;
        magsUi.SetActive(true);
        promptUi.SetActive(true);
        return true;
    }

    public void DropWepon()
    {
        if (currentWepon is null)
        {
            return;
        }

        currentWepon.transform.SetParent(null);
        currentWepon.GetComponent<Rigidbody>().isKinematic = false;
        currentWepon.GetComponent<BoxCollider>().isTrigger = false;
        currentWepon.GetComponent<WeaponShooting>().enabled = false;
        weapons.Remove(currentWepon);
        if (weapons.Count == 0)
        {
            currentWepon = null;
            magsUi.SetActive(false);
            promptUi.SetActive(false);
            return;
        }
        currentWepon = weapons.ElementAt(0);
        currentWepon.SetActive(true);
        Debug.Log(weapons.Count + "  ");
    }


}
