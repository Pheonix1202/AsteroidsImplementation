using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Asteroids;

public class AsteroidsGameObject : MonoBehaviour, IGameObject
{
    void IGameObject.OnDestroy(object sender, EventArgs e)
    {
        Destroy(gameObject);
    }

    void IGameObject.OnPositionChanged(object sender, PositionEventArgs e)
    {
        transform.localPosition = new Vector3(e.X, e.Y, -10f);
    }

    void IGameObject.OnRotationChanged(object sender, RotationEventArgs e)
    {
        float angle = Mathf.Atan2(e.Y, e.X) / Mathf.PI * 180f - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
