using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    FragmentManager fragmentManager;
    int fragmentTotal;

    void Start()
    {
        fragmentManager = GameObject.FindGameObjectWithTag("Fragment").GetComponent<FragmentManager>();

        fragmentTotal = fragmentManager.fragmentCount;
    }
    

}

