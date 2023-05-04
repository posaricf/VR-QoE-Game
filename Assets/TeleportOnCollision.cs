using UnityEngine;

public class TeleportOnCollision : MonoBehaviour
{
    public Collider colliderToWatch;
    public GameObject objectToWatch;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == colliderToWatch && collision.gameObject == objectToWatch)
        {
            Debug.Log(objectToWatch.name + " collided with " + colliderToWatch.name);
        }
    }
}

