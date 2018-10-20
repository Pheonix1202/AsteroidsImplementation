using UnityEngine;
using System.Collections;
using Asteroids;
using System;

public class UFO2D : MonoBehaviour, IUFO
{
    void IGameObject.OnDestroy(object sender, EventArgs e)
    {
        Destroy(gameObject);
    }

    public void OnPositionChanged(object sender, PositionEventArgs e)
    {
        transform.localPosition = new Vector3(e.X, e.Y, -10f);
        
    }

}
