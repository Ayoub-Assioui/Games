using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuEvents : MonoBehaviour
{

    public Slider volumeSlider;
    public AudioMixer mixer;
    private float value;

    public GameObject canvas;

    private void Start()
    {
        Time.timeScale = 1;
         mixer.GetFloat("volume", out value);
         volumeSlider.value = value;
        AudioManager.instance.Play("MainMenu");

    }
   
        
    
    public void SetVolume()
    {
         mixer.SetFloat("volume", volumeSlider.value);

    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
        canvas.SetActive(false);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
        canvas.SetActive(true);
    }
    public void GoToLevels()
    {
        SceneManager.LoadScene("Selection");
        canvas.SetActive(false);
    }

    
}