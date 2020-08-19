using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SceneLoader : MonoBehaviour {

public AudioMixer audioMixer;
public AudioSource pacmanTheme;

    public void Awake() {
        pacmanTheme.Play();
    }

    public void LoadGame() {
        SceneManager.LoadScene("game_scene");
        p
    }

    public void SetVolume(float volume) {
        audioMixer.SetFloat("MyExposedParam", volume);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
