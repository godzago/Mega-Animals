using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _GameOverScane;

    [SerializeField] Animator layoutAnim;

    [SerializeField] GameObject settings_Open;
    [SerializeField] GameObject settings_Close;
    [SerializeField] GameObject Sound_On;
    [SerializeField] GameObject Sound_Close;

    public static int level;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Sound" ) == false)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
    }
    private void Start()
    {
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            AudioListener.volume = 0.75f;
        }
        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            AudioListener.volume = 0;
        }
    }
    public void SettingsClose()
    {
        settings_Close.SetActive(false);
        settings_Open.SetActive(true); 
        layoutAnim.SetTrigger("Slider_out");

    }
    public void SettingsOpen()
    {
        settings_Open.SetActive(false);
        settings_Close.SetActive(true);
        layoutAnim.SetTrigger("Slider_in");

        if (PlayerPrefs.GetInt("Sound") ==1)
        {
            Sound_Close.SetActive(false);
            Sound_On.SetActive(true);
            AudioListener.volume = 0.75f;
        }
        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            Sound_On.SetActive(false);
            Sound_Close.SetActive(true);
            AudioListener.volume = 0;
        }
    }
    public void SoundOn()
    {
        Sound_On.SetActive(false);
        Sound_Close.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);
    }
    public void SoundClose()
    {
        Sound_Close.SetActive(false);
        Sound_On.SetActive(true);
        AudioListener.volume = 0.75f;
        PlayerPrefs.SetInt("Sound", 1);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);       
    }
    public void GameOver()
    {
        _GameOverScane.SetActive(true);
    }
}
