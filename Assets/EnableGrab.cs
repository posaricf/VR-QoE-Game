using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EnableGrab : MonoBehaviour
{
    void Update()
    {
        if (StateManager.lectionRead)
        {
            GetComponent<XRGrabInteractable>().enabled = true;
            this.enabled = false;
        }
    }
}
