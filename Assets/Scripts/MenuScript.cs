using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    //public Slider volumeSlider;
    //public AudioMixer mixer;

    public void SetVolume()
    {
        //mixer.SetFloat("volume", volumeSlider.value);
    }

    public void LoadLevel()
    {
        int random = Random.Range(2, 5);
        SceneManager.LoadScene(random);
    }

    public void LoadTutorial(int integer)
    {
        SceneManager.LoadScene(integer);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
