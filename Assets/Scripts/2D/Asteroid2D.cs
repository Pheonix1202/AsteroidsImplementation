using UnityEngine;
using System.Collections;
using Asteroids;
using System;

public class Asteroid2D : MonoBehaviour, IAsteroid
{
    void IGameObject.OnDestroy(object sender, EventArgs e)
    {
        Destroy(gameObject);
    }

    public void OnPositionChanged(object sender, PositionEventArgs e)
    {
        transform.localPosition = new Vector3(e.X, e.Y, -10f);
    }

    public void OnRotationChanged(object sender, RotationEventArgs e)
    {
        transform.rotation *= Quaternion.AngleAxis(e.RotationAngle, new Vector3(0f, 0f, 1f));
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
