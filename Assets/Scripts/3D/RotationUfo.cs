using UnityEngine;

public class RotationUFO : MonoBehaviour
{
    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(5f, new Vector3(0f, 0f, 1f));
    }
}
