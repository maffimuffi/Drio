using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressEnter : MonoBehaviour
{
    public string nextLevel;
    float timer;
    public AudioSource music;
    public AudioSource transision;
    public bool change;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            music.Stop();
            transision.Play();
            change = true;



            
        }


        if(change == true)
        {


            timer += Time.deltaTime;

            if (timer > 1)
            {
                SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
            }

        }


    }
}
