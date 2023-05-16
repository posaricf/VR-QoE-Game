using TMPro;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;

public class StartGameScript : MonoBehaviour
{
    [SerializeField] private TeleportationArea _firstLevelArea;
    [SerializeField] private TeleportationArea _lastLevelArea;
    [SerializeField] private XRSocketInteractor _socket;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _startLocation;
    [SerializeField] private VideoPlayer _videoPlayer;

    private void Update()
    {
        StartGame();
    }

    private void StartGame()
    {
        if (_socket.hasSelection)
        {
            _firstLevelArea.enabled = true;
            _lastLevelArea.enabled = false;

            _player.transform.position = _startLocation.transform.position;

            _videoPlayer.Play();

            gameObject.SetActive(false);
        }
    }
}
