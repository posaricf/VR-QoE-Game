using System.Collections.Generic;
using UnityEngine;

public class PositionReset : MonoBehaviour
{
    [SerializeField] private List<GameObject> _papers;

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject paper in _papers)
        {
            if (paper.transform.position.y < -1f)
            {
                paper.transform.position = new Vector3(paper.transform.position.x, 0f, paper.transform.position.z);
            }
        }
    }
}
