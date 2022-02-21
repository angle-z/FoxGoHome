using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuControl : MonoBehaviour
{
    public AudioMixer mainMixer;
    public GameObject pausePanel;
  
    public void PlayBtn()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ExitBtn()
    {
        Application.Quit();
    }
    public void PauseBtn()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ReturnBtn()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void SetVolume(float value)
    {
        mainMixer.SetFloat("MainMixer",value);
        
       
    }
}
