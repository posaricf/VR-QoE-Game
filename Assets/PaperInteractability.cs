using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PaperInteractability : MonoBehaviour
{
    [SerializeField] private List<GameObject> _papers;
    [SerializeField] private List<GameObject> _decoyPapers;

    private void OnEnable()
    {
        SocketManager.OnUnlockDoor += RemoveInteractability;
    }

    private void OnDisable()
    {
        SocketManager.OnUnlockDoor -= RemoveInteractability;
    }

    private void RemoveInteractability(int roomId)
    {
        foreach (Transform child in _decoyPapers[roomId].transform)
        {
            XRGrabInteractable xRGrab = child.GetComponent<XRGrabInteractable>();
            xRGrab.enabled = false;
        }
    }
}
