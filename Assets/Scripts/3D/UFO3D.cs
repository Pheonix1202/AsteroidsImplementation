using UnityEngine;
using Asteroids;

public class UFO3D : UFO2D, IUFO
{
    void Update()
    {        
        transform.rotation *= Quaternion.AngleAxis(5f, new Vector3(0f, 0f, 1f));
    }
}
