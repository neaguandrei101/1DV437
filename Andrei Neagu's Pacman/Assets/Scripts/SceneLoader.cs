using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SceneLoader : MonoBehaviour {

public AudioMixer gameMixer;
public AudioMixer menuMixer;
public AudioSource pacmanTheme;

    public void Awake() {
        pacmanTheme.Play();
    }

    public void LoadGame() {
        SceneManager.LoadScene("game_scene");
    }

    public void SetVolume(float volume) {
        gameMixer.SetFloat("MyExposedParam", volume);
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void SetVolumeMenu(float volume) {
        menuMixer.SetFloat("MyExposedParam", volume);
        PlayerPrefs.SetFloat("menuVolume", volume);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
