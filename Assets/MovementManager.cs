using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _teleportationControllers;
    
    [Header("Providers")]
    [SerializeField] private ActionBasedContinuousMoveProvider _continuousMovementController;
    [SerializeField] private TeleportationProvider _teleportationProvider;
    [SerializeField] private ActionBasedSnapTurnProvider _snapTurnProvider;
    
    [Space]
    [SerializeField] private InputActionProperty _leftHandTurn;

    private bool _isTeleportationEnabled = true;
    private InputActionProperty _uselessProperty = new InputActionProperty();

    public void CheckMovementSystem()
    {
        if (_isTeleportationEnabled)
        {
            EnableContinuousMovement(true);
            EnableTeleportation(false);
            EnableSnapTurn(false);
            _isTeleportationEnabled = false;
        }
        else
        {
            EnableContinuousMovement(false);
            EnableTeleportation(true);
            EnableSnapTurn(true);
            _isTeleportationEnabled = true;
        }
    }

    private void EnableTeleportation(bool value)
    {
        foreach (var controller in _teleportationControllers)
        {
            controller.SetActive(value);
        }
        _teleportationProvider.enabled = value;
    }

    private void EnableContinuousMovement(bool value)
    {
        _continuousMovementController.enabled = value;
    }

    private void EnableSnapTurn(bool value)
    {
        if (value)
        {
            _snapTurnProvider.leftHandSnapTurnAction = _leftHandTurn;
        }
        else
        {
            _snapTurnProvider.leftHandSnapTurnAction = _uselessProperty;
        }
    }
}
