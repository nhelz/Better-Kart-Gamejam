using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public ItemUI StackUI;
    [SerializeField]
    private Vector3 origin;
    [SerializeField]
    private Vector3 target;
    private Rigidbody rb;
    [SerializeField]
    private int collecteditems = 0;
    [SerializeField]
    private GameObject[] DecoStackItems;
    [SerializeField]
    private GameObject[] RealStackItems;

    private bool throwCooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0f, 0.5f, 0f);
        transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
        if (Input.GetKeyDown(KeyCode.Space) && !throwCooldown)
        {
            throwCooldown = true;
            RemoveFromStack();
            StartCoroutine(Cooldown());
        }
        origin = transform.position;
        target = transform.position + Vector3.forward * 3;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collided with: " + other.gameObject);
        if (other.gameObject.tag == "Collectible" && !IsStackFull() && other.gameObject.GetComponent<CollectibleMechanics>().CanCollect())
        {
            //Debug.Log("Got Collectible!");
            other.gameObject.GetComponent<CollectibleMechanics>().PickUp();
            AddToStack(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Ended Collision with: " + other.gameObject);
    }

    private void AddToStack(GameObject item)
    {
        if(collecteditems < DecoStackItems.Length)
        {
            
            DecoStackItems[collecteditems].SetActive(true);
            DecoStackItems[collecteditems].GetComponent<ToggleItemDeco>().EnableItemDecos(item.GetComponent<CollectibleMechanics>().itemName);
            StackUI.AddItem(item.GetComponent<CollectibleMechanics>().itemName);
            RealStackItems[collecteditems] = item;
            collecteditems++;
        }
    }

    private bool IsStackFull()
    {
        if (collecteditems == DecoStackItems.Length)
        {
            return true;
        }
        else
            return false;
    }

    private void RemoveFromStack()
    {
        if(collecteditems > 0)
        {
            GetComponent<AudioSource>().Play();
            collecteditems--;
            StackUI.RemoveItem();
            DecoStackItems[collecteditems].SetActive(false);
            RealStackItems[collecteditems].SetActive(true);
            RealStackItems[collecteditems].GetComponent<CollectibleMechanics>().Throw(transform.position, transform.rotation, 10f, 5f);
            RealStackItems[collecteditems] = null;
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(.2f);
        throwCooldown = false;
    }

}
