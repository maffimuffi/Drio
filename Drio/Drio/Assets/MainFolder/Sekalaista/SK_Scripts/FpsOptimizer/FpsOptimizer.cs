using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsOptimizer : MonoBehaviour
{
    public GameObject Scene2Objects;
    public GameObject SecondGateObjects;



    // Start is called before the first frame update
    void Start()
    {
        Scene2Objects.SetActive(false);
        SecondGateObjects.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Scene2Objects.SetActive(true);
            SecondGateObjects.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Scene2Objects.SetActive(false);
            SecondGateObjects.SetActive(false);
        }
    }
}
