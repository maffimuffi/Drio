using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public string nextLevel;
    public AudioSource end;
    float timer;
    bool ending;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(ending == true)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                Debug.Log("Loppu");
                SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
            }
        }


    }


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            
                end.Play();



            ending = true;

            
            
        }

    }
}
