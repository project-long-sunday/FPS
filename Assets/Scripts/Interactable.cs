using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string promptMessage;

    public void BaseInteract(GameObject interactor)
    {
        Interact(interactor);
    }

    protected virtual void Interact(GameObject interactor)
    {

    }
}
