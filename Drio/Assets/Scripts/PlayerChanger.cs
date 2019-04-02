using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements;
using UnityEngine;
using UnityEngine.AI;
public class PlayerChanger : MonoBehaviour
{
    ///<see cref="1=Wind,2=Earth,3=Fire"/>
    public static int CharacterSelect;

    //ei piilotettu että nullreferenssit löytöö
    public GameObject WindCamera;
    public GameObject EarthCamera;
    public GameObject FireCamera;

    public GameObject WindDragon;
    public GameObject EarthDragon;
    public GameObject FireDragon;

    //NavMeshes
    public NavMeshAgent WindNav;
    public NavMeshAgent EarthNav;
    public NavMeshAgent FireNav;

    public static bool PlayerFollowActive;
    public GameObject ActivePlayerRightNow;
    public static GameObject ActivePlayer;

    // Start is called before the first frame update
    void Start()
    {
        
        //Etsii kamerat, dragonit ja navmeshit scenestä
        PlayerFollowActive = true;
        WindCamera = GameObject.Find("WindCam");
        EarthCamera = GameObject.Find("EarthCam");
        FireCamera = GameObject.Find("FireCam");

        WindDragon = GameObject.Find("WindDragon");
        EarthDragon = GameObject.Find("EarthDragon");
        FireDragon = GameObject.Find("FireDragon");
        
        FireNav = FireDragon.GetComponent<NavMeshAgent>();
        EarthNav = EarthDragon.GetComponent<NavMeshAgent>();
        WindNav = WindDragon.GetComponent<NavMeshAgent>();
        ChangePlayer(1);
    
    }

    // Update is called once per frame
    void Update()
    {
        
        //Player follow change
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerFollowActive = !PlayerFollowActive;
            
            //Debuggausta ainoastaan navmeshin vaihtoon
            foreach (Vector3 asd in WindNav.path.corners)
            {
                Debug.DrawLine(asd,Vector3.up,Color.blue,10f);
            }
            foreach (Vector3 asd in FireNav.path.corners)
            {
                Debug.DrawLine(asd,Vector3.up,Color.red,10f);
            }
            foreach (Vector3 asd in EarthNav.path.corners)
            {
                Debug.DrawLine(asd,Vector3.up,Color.green,10f);
            }
            
            
            
            
         }
        //Pelaajan vaihto
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
        Debug.Log(CharacterSelect);
       
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

        ActivePlayerRightNow = ActivePlayer;
        SetCamera();
        SetNavMesh();
    }
//Laittaa pelaajan navmeshin "Stand by" tilaan
    public void SetNavMesh()
    {
        if (CharacterSelect == 1)
        {
            EarthNav.enabled = true;
            FireNav.enabled = true;
            WindNav.enabled = false;
//            WindNav.isStopped = true;
            WindDragon.GetComponent<NavMeshObstacle>().enabled = true;

        } else if (CharacterSelect == 2)
        {
            EarthNav.enabled = false;
            FireNav.enabled = true;
            WindNav.enabled = true;
            //EarthNav.isStopped = true;
            EarthDragon.GetComponent<NavMeshObstacle>().enabled = true;
        } else if (CharacterSelect == 3)
        {
            WindNav.enabled = true;
            FireNav.enabled = false;
            EarthNav.enabled = true;
            //FireNav.isStopped = true;
            FireDragon.GetComponent<NavMeshObstacle>().enabled = true;
        }
        
        
    }
    //Vaihtaa käytettävää kameraa
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
            WindCamera.SetActive(false);
            FireCamera.SetActive(true);
        }
        else
        {
            Debug.Log("ei mitään");
            CharacterSelect = 1;
            EarthCamera.SetActive(false);
            FireCamera.SetActive(false);
            WindCamera.SetActive(true);
        }
    }
}
