using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroUI : MonoBehaviour
{
    public GameObject main;
    public GameObject controls;
    public GameObject ingameUI;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        ingameUI.SetActive(true);
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
    public void Controls()
    {
        main.SetActive(false);
        controls.SetActive(true);
    }
    public void Back()
    {
        main.SetActive(true);
        controls.SetActive(false);
    }
}

