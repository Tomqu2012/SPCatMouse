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
	public AudioSource a1;
	public AudioSource a2;
	public AudioSource a3;
    public bool catMode = false;

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
		if (Manager.levelCompleted > 2) {
        	Time.timeScale = 1f;
        	SceneManager.LoadScene("Lab");
		}
    }
    
    public void playMouseDark() {
		if (Manager.levelCompleted > 3) {
        	Time.timeScale = 1f;
        	SceneManager.LoadScene("Dark");
		}
        
    }

    public void playMouseGraveyard()
    {
		if (Manager.levelCompleted > 1) {
			Time.timeScale = 1f;
        	SceneManager.LoadScene("Graveyard");
		}
    }

	public void playMouseBedroom() {
		if (Manager.levelCompleted > 0) {
        	Time.timeScale = 1f;
        	SceneManager.LoadScene("Bedroom");
		}
        
    }

    public void playCatFrog() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("CatFrog");
    }
    
    public void playCatLab() {
		if (Manager.levelCompleted > 0) {
        	Time.timeScale = 1f;
        	SceneManager.LoadScene("CatLab");
		}
    }
    
    public void playCatDark() {
		if (Manager.levelCompleted > 3) {
        	Time.timeScale = 1f;
        	SceneManager.LoadScene("CatDark");
		}
    }

    public void playCatGraveyard()
    {	
		if (Manager.levelCompleted > 1) {
        	Time.timeScale = 1f;
        	SceneManager.LoadScene("CatGraveyard");
		}
    }

	public void playCatBedroom() {
		if (Manager.levelCompleted > 0) {
        	Time.timeScale = 1f;
        	SceneManager.LoadScene("CatBedroom");
		}
        
    }

	public void cat() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("CatLevels");
    }

	public void mouse() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Levels");
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

	public void Achievements()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Achievements");
    }

    public void Pause()
    {
		a1.Pause();
		a2.Pause();
		a3.Pause();
        if (catMode)
        {
            options.SetActive(true);
            CountDown.SetActive(false);
            Time.timeScale = 0f;
            return;
        }
        else if (player.GetComponent<health>().alive)
        {
            options.SetActive(true);
            CountDown.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    public void Resume()
    {
		a1.Play(0);
		a2.Play(0);
		a3.Play(0);
        options.SetActive(false);
        if (center.GetComponent<countdown>().isActive())
        {
            CountDown.SetActive(true);
        }
        Time.timeScale = 1f;
    }
}
