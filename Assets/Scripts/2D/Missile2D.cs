using UnityEngine;
using System.Collections;
using Asteroids;
using System;

public class Missile2D : MonoBehaviour, IMissile
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
        float angle = Mathf.Atan2(e.Y, e.X) / Mathf.PI * 180f + 90f;
        transform.rotation *= Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f));
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
