using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SceneLoader : MonoBehaviour
{

    public AudioMixer gameMixer;
    public AudioMixer menuMixer;
    public AudioSource pacmanTheme;

    public void Awake()
    {
        pacmanTheme.Play();
    }


    public void LoadLevel1()
    {
        SceneManager.LoadScene("easy_scene");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("game_scene");
    }

    public static void LoadMenu()
    {
        SceneManager.LoadScene("menu_scene");
    }
    public static void LoadSecret()
    {
        SceneManager.LoadScene("secret_scene");
    }

    public void SetVolume(float volume)
    {
        gameMixer.SetFloat("MyExposedParam", volume);
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void SetVolumeMenu(float volume)
    {
        menuMixer.SetFloat("MyExposedParam", volume);
        PlayerPrefs.SetFloat("menuVolume", volume);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
