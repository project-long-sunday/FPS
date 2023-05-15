using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInteractable : Interactable
{
    [SerializeField] List<Light> lights;
    
    bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Light l in lights)
        {
            l.enabled = true;
        }
        isOn = true;
    }

    protected override void Interact(GameObject interactor)
    {
        ControllLights();
    }

    void ControllLights()
    {
        isOn = !isOn;
        foreach (Light l in lights)
        {
            l.enabled = isOn;
        }
    }

}
