using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Asteroids;

public class GameManager : MonoBehaviour {

    private Game game;
    private bool gameOver;
    private Camera camera2D, camera3D;
    private Canvas guiCanvas;
    private GUIManager gui;

    void Start()
    {
        game = Game.Instance;
        game.AddVisualizers(GetComponent<Visualizer2D>(), GetComponent<Visualizer3D>());

        camera2D = GameObject.Find("Camera2D").GetComponent<Camera>();
        camera3D = GameObject.Find("Camera3D").GetComponent<Camera>();
        guiCanvas = GameObject.Find("GUI").GetComponent<Canvas>();
        gui = GameObject.Find("GUI").GetComponent<GUIManager>();

        StartGame();
    }

    void Update()
    {
        if (!gameOver)
        {
            ListenForInput();
            game.OnFrame();
        } 
    }

    void OnApplicationQuit()
    {
        game.FinishGame();
    }

    internal void StartGame()
    {
        gameOver = false;
        gui.StartGame();
        game.GameOverEvent += OnGameOver;
        game.StartGame();
        gui.ShowHint("Нажмите Tab во время игры для \r\n переключения визуального представления");
    }

    void OnGameOver()
    {
        gameOver = true;
        gui.GameOver(game.Score);
    }

    void ListenForInput()
    {        
        if (Input.GetKey(KeyCode.W)) game.InputPublisher.ForwardPressed();
        if (Input.GetKey(KeyCode.A)) game.InputPublisher.ToLeftPressed();
        if (Input.GetKey(KeyCode.D)) game.InputPublisher.ToRightPressed();
        if (Input.GetMouseButton(0)) game.InputPublisher.FirePressed();
        if (Input.GetMouseButton(1)) game.InputPublisher.LaserPressed();

        if (Input.GetKeyDown(KeyCode.Tab)) SwitchDisplays();
    }

    void SwitchDisplays()
    {
        int temp = camera2D.targetDisplay;
        camera2D.targetDisplay = camera3D.targetDisplay;
        camera3D.targetDisplay = temp;
        if (guiCanvas.worldCamera == camera2D) guiCanvas.worldCamera = camera3D;
        else guiCanvas.worldCamera = camera2D;
    }
}
