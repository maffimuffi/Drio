using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.UIElements;
using UnityEngine;
using UnityEngine.AI;
public class PlayerChanger : MonoBehaviour
{
    ///<see cref="1=Wind,2=Earth,3=Fire"/>
    public static int CharacterSelect;

    //ei piilotettu että nullreferenssit löytöö
    //public GameObject cam;
    //public GameObject EarthCamera;
    //public GameObject FireCamera;

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

    

    private int scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        scrollSpeed = 0;
        //Etsii kamerat, dragonit ja navmeshit scenestä
        PlayerFollowActive = true;
        //cam = GameObject.Find("MainCamera");
        //EarthCamera = GameObject.Find("EarthCam");
        //FireCamera = GameObject.Find("FireCam");

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
            transform.position = new Vector3(transform.position.x, 0.415f, transform.position.y);
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
        if (Input.GetKeyDown(KeyCode.Alpha1) && CharacterSelect != 1)
        {
            ChangePlayer(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && CharacterSelect != 2)
        {
            ChangePlayer(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && CharacterSelect != 3)
        {
            ChangePlayer(3);
        }

        //Scroll wheel
        if (Input.mouseScrollDelta.y > 0)
        {
            if (scrollSpeed == 0)
            {
                if (CharacterSelect == 1)
                {
                    ChangePlayer(2);
                }
                else if (CharacterSelect == 2)
                {
                    ChangePlayer(3);
                }
                else if (CharacterSelect == 3)
                {
                    ChangePlayer(1);
                }

                scrollSpeed++;
            }
            else
            {
                scrollSpeed = 0;
            }

        } else if (Input.mouseScrollDelta.y < 0)
        {
            if (scrollSpeed == 0)
            {
                
            if (CharacterSelect == 1)
                {
                    ChangePlayer(3);
                } else if (CharacterSelect == 2)
                {
                    ChangePlayer(1);
                } else if (CharacterSelect == 3)
                {
                    ChangePlayer(2);
                }
            
                scrollSpeed++;
            }
            else
            {
                scrollSpeed = 0;
            }
        }
    }
    
    
    ///<see cref="ChangePlayer vaihtaa pelaajaa. playerSelect 1=Wind,2=Earth,3=Fire"/>
    public void ChangePlayer(int playerSelect)
    {
        CharacterSelect = playerSelect;
        //Debug.Log(CharacterSelect);
        
        //player Movement
        CharacterMovement windMove = WindDragon.GetComponent<CharacterMovement>();
        windMove.setPlayerActive();
        windMove.ResetJump();
        
        CharacterMovement earthMove = EarthDragon.GetComponent<CharacterMovement>();
        earthMove.setPlayerActive();
        earthMove.ResetJump();
        
        CharacterMovement fireMove = FireDragon.GetComponent<CharacterMovement>();
        fireMove.setPlayerActive();
        fireMove.ResetJump();
        
        if (CharacterSelect == 1)
        {
            ActivePlayer = WindDragon;

        }
        else if (CharacterSelect == 2)
        {
            ActivePlayer = EarthDragon;
        }
        else if (CharacterSelect == 3)
        {
            ActivePlayer = FireDragon;
        }

        ActivePlayerRightNow = ActivePlayer;
        //SetCamera();
        SetNavMesh();
        //uiText.ExitSite();
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

        }
        else if (CharacterSelect == 2)
        {
            EarthNav.enabled = false;
            FireNav.enabled = true;
            WindNav.enabled = true;
            //EarthNav.isStopped = true;
            EarthDragon.GetComponent<NavMeshObstacle>().enabled = true;
        }
        else if (CharacterSelect == 3)
        {
            WindNav.enabled = true;
            FireNav.enabled = false;
            EarthNav.enabled = true;
            //FireNav.isStopped = true;
            FireDragon.GetComponent<NavMeshObstacle>().enabled = true;
        }
        
        
    }
    //Vaihtaa käytettävää kameraa
    //public void SetCamera()
    //{
    //    cam.SetActive(true);
    //}
}
