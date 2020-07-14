﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public enum GameState
    {
        PLAY, PACMAN_DYING, PACMAN_DEAD, GAME_OVER, GAME_WON
    };
    public GameState gameState = GameState.PLAY;

    public GameObject pacman;
    public AnimationClip pacmanDeathAnimation;
    public List<GameObject> ghosts;
    public List<GameObject> pills;
    public Image gameOverScreen;
    public Image gameWonScreen;
    private static GameManager instance;
    private float respawnTime = 0;//when pacman should respawn from the PACMAN_DYING state

	// Use this for initialization
	void Start ()
    {
        gameOverScreen.enabled = false;
        gameWonScreen.enabled = false;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        switch (gameState)
        {
            case GameState.PLAY:
                bool foundNotEaten = false;
                foreach(GameObject pill in pills)
                {
                    if (pill.activeSelf)
                    {
                        foundNotEaten = true;
                        break;
                    }
                }
                if (!foundNotEaten)
                {
                    gameState = GameState.GAME_WON;
                }
                break;
            case GameState.PACMAN_DYING:
                if (Time.time > respawnTime)
                {
                    gameState = GameState.PACMAN_DEAD;
                    respawnTime = Time.time + 1;
                    pacman.SetActive(false);
                }
                break;
            case GameState.PACMAN_DEAD:
                if (Time.time > respawnTime)
                {
                    gameState = GameState.PLAY;
                    pacman.SetActive(true);
                    pacman.transform.position = Vector2.zero;
                    PlayerController pc = pacman.GetComponent<PlayerController>();
                    pc.setLivesLeft(pc.lives - 1);
                    if (pc.lives >= 0)
                    {
                        pc.setAlive(true);
                    }
                    else
                    {
                        gameState = GameState.GAME_OVER;
                    }
                    foreach (GameObject ghost in instance.ghosts)
                    {
                        ghost.GetComponent<GhostController>().reset();
                    }
                }
                break;
            case GameState.GAME_OVER:
                gameOverScreen.enabled = true;
                gameWonScreen.enabled = false;
                if (Input.anyKeyDown)
                {
                    resetGame();
                    gameState = GameState.PLAY;
                    gameOverScreen.enabled = false;
                }
                break;
            case GameState.GAME_WON:
                gameOverScreen.enabled = false;
                gameWonScreen.enabled = true;
                if (Input.anyKeyDown)
                {
                    resetGame();
                    gameState = GameState.PLAY;
                    gameWonScreen.enabled = false;
                }
                break;
        } 
	}

    public static void pacmanKilled()
    {
        instance.gameState = GameState.PACMAN_DYING;
        instance.pacman.GetComponent<PlayerController>().setAlive(false);
        instance.respawnTime = Time.time + instance.pacmanDeathAnimation.length;
        foreach (GameObject ghost in instance.ghosts)
        {
            ghost.GetComponent<GhostController>().freeze(true);
        }
    }

    public static void resetGame()
    {
        PlayerController pc = instance.pacman.GetComponent<PlayerController>();
        pc.setLivesLeft(2);
        pc.setAlive(true);
        instance.pacman.transform.position = Vector2.zero;
        foreach (GameObject ghost in instance.ghosts)
        {
            ghost.GetComponent<GhostController>().reset();
        }
        foreach (GameObject pill in instance.pills)
        {
            pill.SetActive(true);
        }
    }
}
