using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableFloat : MonoBehaviour
{
    public GameObject parentObject;
    public float rotationSpeed;
    
    public float maxPos;
    public float minPos;
    public float timeInterval;

    private Rigidbody rb;

    private Vector3 newPosition;
    private Vector3 newRotation;
    [SerializeField]
    private Vector3 originPosition;
    private float timeVal = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        originPosition = parentObject.transform.position;
        timeVal = Mathf.PingPong(Time.time, timeInterval);
        newPosition = Vector3.Lerp(new Vector3(originPosition.x, originPosition.y + minPos, originPosition.z), new Vector3(originPosition.x, originPosition.y + maxPos, originPosition.z), timeVal);
        transform.position = newPosition;
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

}
