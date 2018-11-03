using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Asteroids;
using UnityEngine;
using UnityEngine.UI;

class Visualizer2D : MonoBehaviour, IVisualizer, IAsteroidsFactory
{
    public GameObject player, missile, laser, ufo, asteroidSmall, asteroidMedium, asteroidBig;

    protected Transform Parent { get; set; }
    protected GUIManager gui;

    protected virtual void Start()
    {
        gui = GameObject.Find("GUI").GetComponent<GUIManager>();
        Parent = GameObject.Find("Game2D").transform;
    }

    IAsteroidsFactory IVisualizer.Factory
    {
        get { return this; }
    }

    public virtual IGameObject CreateAsteroid(AsteroidSize size)
    {
        GameObject next = null;
        switch (size)
        {
            case AsteroidSize.Big:
                next = Instantiate(asteroidBig);
                break;
            case AsteroidSize.Medium:
                next = Instantiate(asteroidMedium);
                break;
            case AsteroidSize.Small:
                next = Instantiate(asteroidSmall);
                break;
        }
        next.transform.SetParent(Parent);
        return next.GetComponent<IGameObject>();
    }

    public IGameObject CreateLaser()
    {
        GameObject next = Instantiate(laser);
        next.transform.SetParent(Parent);
        return next.GetComponent<IGameObject>();
    }

    public IGameObject CreateMissile()
    {
        GameObject next = Instantiate(missile);
        next.transform.SetParent(Parent);
        return next.GetComponent<IGameObject>();
    }

    public IGameObject CreatePlayer()
    {
        GameObject next = Instantiate(player);
        next.transform.SetParent(Parent);
        return next.GetComponent<IGameObject>();
    }

    public virtual IGameObject CreateUFO()
    {
        GameObject next = Instantiate(ufo);
        next.transform.SetParent(Parent);
        return next.GetComponent<IGameObject>();
    }

    public virtual void OnScoreChanged(object sender, ScoreEventArgs e)
    {
        gui.UpdateScore(e.Score);
    }

    public virtual void OnLaserCountChanged(object sender, LaserEventArgs e)
    {
        gui.OnLaserChargesCountChanged(e.Charges);
    }
}
