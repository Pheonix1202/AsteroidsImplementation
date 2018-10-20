using UnityEngine;
using Asteroids;

public class Asteroid3D : Asteroid2D, IAsteroid
{
    private Vector3 randomRotation;

    void Start()
    {
        randomRotation = new Vector3(Random.value, Random.value, Random.value);
    }

    void Update()
    {
        transform.localRotation *= Quaternion.Euler(randomRotation);
    }
}
