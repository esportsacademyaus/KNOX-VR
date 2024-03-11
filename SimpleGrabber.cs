using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SimpleGrabber : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;

    private XRDirectInteractor interactor;

    void Start()
    {
        interactor = GetComponent<XRDirectInteractor>();
    }

    void Update()
    {
        // Detect grab button press
        if (interactor.selectTarget)
        {
            if (interactor.selectTarget is XRGrabInteractable)
            {
                grabInteractable = interactor.selectTarget as XRGrabInteractable;
                grabInteractable.transform.SetParent(transform);
                grabInteractable.transform.localPosition = Vector3.zero;
                grabInteractable.transform.localRotation = Quaternion.identity;
            }
        }
        else if (grabInteractable != null) // Detect grab button release
        {
            grabInteractable.transform.SetParent(null); 
            grabInteractable = null;
        }
    }
}
