using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Stats : MonoBehaviour
{

    public Vector3 spawnPosition;
    public GameObject activePlayer;

    private bool damageTaken;
    private float time;

    // Start is called before the first frame update
    void Awake()
    {
        time = 1f;
        spawnPosition = Checkpoint.GetActiveCheckPointPosition();
        damageTaken = false;
        activePlayer = GameObject.Find(PlayerChanger.ActivePlayer.name);
    }

    // Update is called once per frame
    void Update()
    {
        spawnPosition = Checkpoint.GetActiveCheckPointPosition();

        if(damageTaken)
        {
            if(activePlayer.name == "WindDragon" || activePlayer.name == "EarthDragon" || activePlayer.name == "FireDragon")
            {
                Die();
            }
        }
    }

    public void TakeDamage()
    {
        Debug.Log("Took damage");
        damageTaken = true;
    }

    void Die()
    {
        Debug.Log("Ded");
        StartCoroutine(Wait(time));
        activePlayer.transform.position = spawnPosition;
        damageTaken = false;
    }

    IEnumerator Wait(float count)
    {
        yield return new WaitForSeconds(count); //Count is the amount of time in seconds that you want to wait.
                                                //And here goes your method of resetting the game...
        yield return null;
    }
}
