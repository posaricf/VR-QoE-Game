using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _socketParents;

    public static Action<int> OnUnlockDoor;

    private int _roomId = 0;

    private void Update()
    {
        if (CheckSockets())
        {
            if (CheckCompletion())
            {
                OnUnlockDoor?.Invoke(_roomId);
                _roomId++;
            }
        }
    }

    private bool CheckSockets()
    {
        foreach (Transform child in _socketParents[_roomId].transform)
        {
            var socket = child.GetComponent<XRSocketInteractor>();
            if (!socket.hasSelection)
            {
                return false;
            }
        }
        return true;
    }

    private bool CheckCompletion()
    {
        foreach (Transform child in _socketParents[_roomId].transform)
        {
            var socket = child.GetComponent<XRSocketInteractor>();
            IXRSelectInteractable paper = socket.GetOldestInteractableSelected();
            if (!paper.transform.name.StartsWith("Paper"))
            {
                return false;
            }
        }
        return true;
    }
}
