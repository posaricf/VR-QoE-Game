using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _doors;

    public static Action<int> OnActivateTeleportationArea;

    private void OnEnable()
    {
        SocketManager.OnUnlockDoor += UnlockDoor;
    }

    private void OnDisable()
    {
        SocketManager.OnUnlockDoor -= UnlockDoor;
    }

    private void UnlockDoor(int doorId)
    {
        _doors[doorId].GetComponent<XRGrabInteractable>().enabled = true;
        _doors[doorId].GetComponent<Rigidbody>().isKinematic = false;
        _doors[doorId].GetComponent<Rigidbody>().useGravity = true;
        OnActivateTeleportationArea?.Invoke(doorId);

        if (doorId == _doors.Count - 1)
        {
            StateManager.gameOver = true;
        }
    }
}
