using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCatcher : MonoBehaviour
{
    [SerializeField]
    private string wantedItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Collectible")
        {
            if(other.gameObject.GetComponent<CollectibleMechanics>().itemName == wantedItem)
            {
                other.gameObject.GetComponent<CollectibleMechanics>().SetSpawned(false);
                other.gameObject.SetActive(false);
                other.gameObject.GetComponentInParent<CollectableSpawner>().CaughtItem();
            }
        }
    }
}
