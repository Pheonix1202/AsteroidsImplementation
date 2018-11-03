using UnityEngine;
using Asteroids;

class Visualizer3D : Visualizer2D, IVisualizer, IAsteroidsFactory
{
    protected override void Start ()
    {
        Parent = GameObject.Find("Game3D").transform;
	}

    public override IGameObject CreateAsteroid(AsteroidSize size)
    {
        var asteroid = base.CreateAsteroid(size) as MonoBehaviour;
        asteroid.gameObject.AddComponent<RandomRotation>();
        return asteroid as IGameObject;
    }

    public override IGameObject CreateUFO()
    {
       var ufo = base.CreateUFO() as MonoBehaviour;
       ufo.gameObject.AddComponent<RotationUFO>();
       return ufo as IGameObject;
    }

    public override void OnScoreChanged(object sender, ScoreEventArgs e) { }
    public override void OnLaserCountChanged(object sender, LaserEventArgs e) { }

}
