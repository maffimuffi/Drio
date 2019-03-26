using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerChanger : MonoBehaviour
{
    ///<see cref="1=Wind,2=Earth,3=Fire"/>
    public static int CharacterSelect;

    public GameObject WindCamera;
    public GameObject EarthCamera;
    public GameObject FireCamera;

    public GameObject WindDragon;
    public GameObject EarthDragon;
    public GameObject FireDragon;

    public NavMeshAgent WindNav;
    public NavMeshAgent EarthNav;
    public NavMeshAgent FireNav;

    public static GameObject ActivePlayer;

    // Start is called before the first frame update
    void Start()
    {
        FireNav = FireDragon.GetComponent<NavMeshAgent>();
        EarthNav = EarthDragon.GetComponent<NavMeshAgent>();
        WindNav = WindDragon.GetComponent<NavMeshAgent>();
     SetCamera();
        ChangePlayer(1);
SetNavMesh();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangePlayer(1);
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangePlayer(2);
        }else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangePlayer(3);
        }
    }
    ///<see cref="ChangePlayer vaihtaa pelaajaa. playerSelect 1=Wind,2=Earth,3=Fire"/>
    public void ChangePlayer(int playerSelect)
    {
        CharacterSelect = playerSelect;
       
        //player Movement
        WindDragon.GetComponent<CharacterMovement>().setPlayerActive();
        EarthDragon.GetComponent<CharacterMovement>().setPlayerActive();
        FireDragon.GetComponent<CharacterMovement>().setPlayerActive();
        if (CharacterSelect == 1)
        {
            ActivePlayer = WindDragon;

        } else if (CharacterSelect == 2)
        {
            ActivePlayer = EarthDragon;
        } else if (CharacterSelect == 3)
        {
            ActivePlayer = FireDragon;
        }
        SetCamera();
        SetNavMesh();
    }

    public void SetNavMesh()
    {
        if (CharacterSelect == 1)
        {
            WindNav.updateRotation = false;
            WindNav.updatePosition = false;
            WindNav.isStopped = true;
            WindDragon.GetComponent<NavMeshObstacle>().enabled = true;

        } else if (CharacterSelect == 2)
        {
            EarthNav.updateRotation = false;
            EarthNav.updatePosition = false;
            EarthNav.isStopped = true;
            EarthDragon.GetComponent<NavMeshObstacle>().enabled = true;
        } else if (CharacterSelect == 3)
        {
            FireNav.updateRotation = false;
            FireNav.updatePosition = false;
            FireNav.isStopped = true;
            FireDragon.GetComponent<NavMeshObstacle>().enabled = true;
        }
        
        
    }
    
    public void SetCamera()
    {
        if (CharacterSelect == 1)
        {
            EarthCamera.SetActive(false);
            FireCamera.SetActive(false);
            WindCamera.SetActive(true);
            
        } else if (CharacterSelect == 2)
        {
            EarthCamera.SetActive(true);
            FireCamera.SetActive(false);
            WindCamera.SetActive(false);
        } else if (CharacterSelect == 3)
        {
            EarthCamera.SetActive(false);
            FireCamera.SetActive(true);
            WindCamera.SetActive(false);
        }
        else
        {
            CharacterSelect = 1;
            EarthCamera.SetActive(false);
            FireCamera.SetActive(false);
            WindCamera.SetActive(true);
        }
    }
}
