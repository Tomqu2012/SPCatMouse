using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    public GameObject player;
    public GameObject options;
    public GameObject CountDown;
    public GameObject center;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void playMouseFrog() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Frog");
    }
    
    public void playMouseLab() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lab");
    }
    
    public void playMouseDark() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Dark");
    }

    public void playCat()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Cat");
    }

    public void Back() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    public void Reload() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title");
    }

    public void Graveyard()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Graveyard");
        }
    
    public void Map()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Levels");
    }

    public void Shop()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Shop");
    }

    public void Pause()
    {
        if (player.GetComponent<health>().alive)
        {
            options.SetActive(true);
            CountDown.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    public void Resume()
    {
        options.SetActive(false);
        if (center.GetComponent<countdown>().isActive())
        {
            CountDown.SetActive(true);
        }
        Time.timeScale = 1f;
    }
}
