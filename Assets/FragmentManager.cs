using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FragmentManager : MonoBehaviour

{
    public int fragmentCount;
    public Text FragmentText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FragmentText.text = "Fragments Collected : " + fragmentCount.ToString();
    }
}
