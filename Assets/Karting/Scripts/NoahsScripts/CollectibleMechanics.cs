using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleMechanics : MonoBehaviour
{
    private bool canCollect = true;
    private bool thrown = false;
    //private float maxlerptime = 3f;
    //private float throwstart;
    //private Vector3 thrownorigin;
    //private Vector3 throwntarget;
    //private Vector3 throwncenter;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
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

    public void Throw(Vector3 origin, Vector3 target, Quaternion startingangle)
    {
        //thrownorigin = origin;
        //throwntarget = target;
        //throwncenter = (origin + target) / 2f;
        transform.position = origin;
        transform.rotation = startingangle;
        
        //throwstart = Time.time;
        thrown = true;
        rb.AddForce(0f, 10f, 0f, ForceMode.Impulse);
        rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
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
}
