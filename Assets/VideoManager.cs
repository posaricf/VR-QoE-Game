using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField] private List<VideoPlayer> _videoPlayers;

    private void OnEnable()
    {
        TeleportationAreaManager.OnNewVideo += ChangeVideo;
    }

    private void OnDisable()
    {
        TeleportationAreaManager.OnNewVideo -= ChangeVideo;
    }

    private void ChangeVideo(int roomId)
    {
        _videoPlayers[roomId].Stop();
        if (roomId != _videoPlayers.Count - 1)
        {
            _videoPlayers[roomId + 1].Play();
        }
    }
}
