

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    private bool paused;

    public GameObject pauseMenu;
    public float menuCounter;

    public VignettePulse trigger;

    // Start is called before the first frame update
    void Awake()
    {
        BirdTrigger.triggered = 0;
        OpenDoorAni.trigger2 = 0;
        LastBowl.lastBowlLit = false;
        trigger.finished = false;

        paused = false;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Continue();
            }
            else
            {
                OnPause();
            }
        }

        if(trigger.finished == true)
        {
            menuCounter = 1;
            ExitToMenu();
        }
    }

    // Pausing the game and enabling pause menu
    public void OnPause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    // Continue the game
    public void Continue()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }

    public void Restart()
    {
        VignettePulse.restartValue = true;
        LastBowl.lastBowlLit = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitToMenu()
    {
        VignettePulse.restartValue = true;
        LastBowl.lastBowlLit = false;
        SceneManager.LoadScene("MainMenu");
    }
}
