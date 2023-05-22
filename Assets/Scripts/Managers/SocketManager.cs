using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _socketParents;

    public static Action<int> OnUnlockDoor;
    public static Action<int, int> OnUpdateScore;
    public static Action<int> OnResetScore;

    private int _roomId = 0;
    private int _fakePapers = 0;
    private bool _toReset = false;

    private void Update()
    {
        Debug.Log(StateManager.gameOver);

        if (CheckSockets())
        {
            if (CheckCompletion())
            {
                OnUnlockDoor?.Invoke(_roomId);
                if (_roomId < _socketParents.Count - 1)
                {
                    _roomId++;
                }
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
                if (_toReset)
                {
                    OnResetScore?.Invoke(_roomId);
                    _toReset = false;
                    _fakePapers = 0;
                }
                return false;
            }
        }
        return true;
    }

    private bool CheckCompletion()
    {
        if (!_toReset)
        {
            foreach (Transform child in _socketParents[_roomId].transform)
            {
                var socket = child.GetComponent<XRSocketInteractor>();
                IXRSelectInteractable paper = socket.GetOldestInteractableSelected();
                if (!paper.transform.name.StartsWith("Paper"))
                {
                    _fakePapers++;
                    _toReset = true;
                }
            }
            OnUpdateScore?.Invoke(_roomId, _fakePapers);
        }

        if (_fakePapers > 0)
        {
            return false;
        }
        else
        {
            foreach (Transform child in _socketParents[_roomId].transform)
            {
                var socket = child.GetComponent<XRSocketInteractor>();
                IXRSelectInteractable paper = socket.GetOldestInteractableSelected();
                BoxCollider boxCollider = paper.transform.GetComponent<BoxCollider>();
                boxCollider.enabled = false;
            }
        }

        return true;
    }
}
