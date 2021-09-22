using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleMechanics : MonoBehaviour
{
    private bool canCollect = true;
    private bool thrown = false;
    public string itemName;
    //private float maxlerptime = 3f;
    //private float throwstart;
    //private Vector3 thrownorigin;
    //private Vector3 throwntarget;
    //private Vector3 throwncenter;
    private Rigidbody rb;
    [SerializeField]
    private bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (thrown)
        //{
            //transform.position = Vector3.Slerp(thrownorigin - throwncenter, throwntarget - throwncenter, (Time.time - throwstart) / maxlerptime);
        //}
    }

    public void PickUp()
    {
        canCollect = false;
        gameObject.SetActive(false);
    }

    public void Throw(Vector3 origin, Quaternion startingangle, float upForce, float forwardForce)
    {
        //thrownorigin = origin;
        //throwntarget = target;
        //throwncenter = (origin + target) / 2f;
        transform.position = origin;
        transform.rotation = startingangle;
        
        //throwstart = Time.time;
        thrown = true;
        rb.AddForce(0f, upForce, 0f, ForceMode.Impulse);
        rb.AddForce(transform.forward * forwardForce, ForceMode.Impulse);
        StartCoroutine(CollectCooldown());
    }

    private IEnumerator CollectCooldown()
    {
        yield return new WaitForSeconds(3f);
        thrown = false;
        canCollect = true;
    }

    public bool CanCollect()
    {
        return canCollect;
    }

    public bool Spawned()
    {
        return spawned;
    }

    public void SetSpawned(bool newVal)
    {
        spawned = newVal;
    }
}
