using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDetector : MonoBehaviour
{
    public EndingUI endUI;

    void Start()
    {
        endUI = GameObject.FindGameObjectWithTag("EndUI").GetComponent<EndingUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            endUI.AddET();
        }
    }
}
