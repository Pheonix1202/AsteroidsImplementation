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

    public IAsteroid CreateAsteroid(AsteroidSize size)
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
        return next.GetComponent<IAsteroid>();
    }

    public ILaser CreateLaser()
    {
        GameObject next = Instantiate(laser);
        next.transform.SetParent(Parent);
        return next.GetComponent<ILaser>();
    }

    public IMissile CreateMissile()
    {
        GameObject next = Instantiate(missile);
        next.transform.SetParent(Parent);
        return next.GetComponent<IMissile>();
    }

    public IPlayer CreatePlayer()
    {
        GameObject next = Instantiate(player);
        next.transform.SetParent(Parent);
        return next.GetComponent<IPlayer>();
    }

    public IUFO CreateUFO()
    {
        GameObject next = Instantiate(ufo);
        next.transform.SetParent(Parent);
        return next.GetComponent<IUFO>();
    }

    public virtual void OnScoreChanged(object sender, ScoreEventArgs e)
    {
        gui.UpdateScore(e.Score);
    }
}
