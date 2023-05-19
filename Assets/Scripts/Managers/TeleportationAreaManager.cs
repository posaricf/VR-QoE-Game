using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationAreaManager : MonoBehaviour
{
    [SerializeField] private List<TeleportationArea> _teleportationAreas;

    public static Action<int> OnNewVideo;

    private void OnEnable()
    {
        DoorManager.OnActivateTeleportationArea += ActivateTeleportationArea;
    }

    private void OnDisable()
    {
        DoorManager.OnActivateTeleportationArea += ActivateTeleportationArea;
    }

    private void ActivateTeleportationArea(int areaId)
    {
        _teleportationAreas[areaId].enabled = true;
        OnNewVideo?.Invoke(areaId);
    }
}
