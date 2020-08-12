using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SceneLoader : MonoBehaviour {

public AudioMixer audioMixer;

    public void LoadGame() {
        SceneManager.LoadScene("game_scene");
    }

    public void SetVolume(float volume) {
        audioMixer.SetFloat("MyExposedParam", volume);
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quit");
    }
}
