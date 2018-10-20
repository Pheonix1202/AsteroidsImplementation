using UnityEngine;
using Asteroids;

class Visualizer3D : Visualizer2D, IVisualizer, IAsteroidsFactory
{
    protected override void Start ()
    {
        Parent = GameObject.Find("Game3D").transform;
	}

    public override void OnScoreChanged(object sender, ScoreEventArgs e) { }
}
