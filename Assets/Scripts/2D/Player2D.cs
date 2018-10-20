using UnityEngine;
using Asteroids;
using System;

public class Player2D : MonoBehaviour, IPlayer
{
    private GUIManager gui;

    public virtual void OnLaserChargeCountChanged(object sender, LaserEventArgs e)
    {
        if (gui == null) gui = GameObject.Find("GUI").GetComponent<GUIManager>();
        gui.OnLaserChargesCountChanged(e.Charges);
    }

    public void OnPositionChanged(object sender, PositionEventArgs e)
    {
        transform.localPosition = new Vector3(e.X, e.Y, -10f);
    }

    public virtual void OnRotationChanged(object sender, RotationEventArgs e)
    {
        transform.rotation *= Quaternion.AngleAxis(e.RotationAngle, new Vector3(0f,0f,1f)); 
    }

    void IGameObject.OnDestroy(object sender, EventArgs e)
    {
        Destroy(gameObject);
    }

}
