using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleItemDeco : MonoBehaviour
{
    public GameObject[] ItemDecos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableItemDecos(string itemName)
    {
        for(int i = 0; i < ItemDecos.Length; i++)
        {
            if(ItemDecos[i].name == itemName)
            {
                ItemDecos[i].SetActive(true);
            }
            else
            {
                ItemDecos[i].SetActive(false);
            }
        }
    }
}
