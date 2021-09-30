using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowEffect : MonoBehaviour
{
    public GameObject fullGlass;
    public GameObject BrokenGlass;
    public GameObject GlassShards;
    private bool Activated = false;
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
        if(other.gameObject.tag != "Untagged" && !Activated)
        {
            Activated = true;
            Break();
        }
    }

    private void Break()
    {
        fullGlass.SetActive(false);
        BrokenGlass.SetActive(true);
        GlassShards.SetActive(true);
        GetComponent<AudioSource>().Play();
    }

    private void PropelShards()
    {
        Rigidbody[] shardrb = GlassShards.GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < shardrb.Length; i++)
        {
            shardrb[i].AddForceAtPosition(Vector3.forward * 10f, GlassShards.transform.position, ForceMode.Impulse);
        }
    }
}
