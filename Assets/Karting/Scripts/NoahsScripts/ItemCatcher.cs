using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCatcher : MonoBehaviour
{
    public RequestMechanics RequestUI;
    public CubicleManager cm;
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
                StartCoroutine(cm.CatchItem(other.gameObject.transform.position));
                other.gameObject.GetComponent<CollectibleMechanics>().SetSpawned(false);
                other.gameObject.SetActive(false);
                other.gameObject.GetComponentInParent<CollectableSpawner>().CaughtItem();
                wantedItem = "none";
                RequestUI.CompleteRequest();
                StartCoroutine(cm.TaskCooldown());
            }
        }
    }

    public void NewItemToCatch(string newItem)
    {
        wantedItem = newItem;
        if(wantedItem == "none")
        {
            RequestUI.CompleteRequest();
        }
        else
        {
            RequestUI.DisplayRequest(wantedItem);
        }
        
    }
}
