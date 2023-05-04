using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StartGameScript : MonoBehaviour
{
    [SerializeField] private TeleportationArea _firstLevelArea;
    [SerializeField] private TeleportationArea _lastLevelArea;
    [SerializeField] private XRSocketInteractor _socket;
    [SerializeField] private TextMeshProUGUI _firstBlackboardText;
    [SerializeField] private TextMeshProUGUI _secondBlackboardText;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _startLocation;

    private void Update()
    {
        StartGame();
    }

    private void StartGame()
    {
        if (_socket.hasSelection)
        {
            _firstBlackboardText.text = "";
            _secondBlackboardText.text = "";
            _firstLevelArea.enabled = true;
            _lastLevelArea.enabled = false;

            _player.transform.position = _startLocation.transform.position;

            gameObject.SetActive(false);
        }
    }
}
