using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsEasterEgg : MonoBehaviour
{
    public GameObject BESTDUDE;
    public EndingUI endUI;
    [SerializeField]
    GameObject Player;
    [SerializeField]
    Rigidbody PlayerRB;
    [SerializeField]
    Vector3 currentFreezePosition;
    [SerializeField]
    bool triggeredEvent = false;
    // Start is called before the first frame update
    void Start()
    {
        endUI = GameObject.FindGameObjectWithTag("EndUI").GetComponent<EndingUI>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (triggeredEvent)
        {
            //Player.transform.position = currentFreezePosition;
            PlayerRB.isKinematic = true;
            PlayerRB.position = new Vector3(1.6f, 20.2f, 10f);
            PlayerRB.isKinematic = false;

            triggeredEvent = false;
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !triggeredEvent)
        {
            Player = other.gameObject;
            currentFreezePosition = other.gameObject.transform.position;
            StartCoroutine(DoWindowsEvent());
        }
    }

    private IEnumerator DoWindowsEvent()
    {
        PlayerRB.isKinematic = true;
        BESTDUDE.transform.position = currentFreezePosition + new Vector3(0f,.8f, 0f);
        yield return new WaitForSeconds(1f);
        PlayerRB.position = new Vector3(1.6f, 20.2f, 10f);
        BESTDUDE.transform.position = new Vector3(1.6f, 21.6f, 10f);
        endUI.AddWB();
        yield return new WaitForSeconds(1f);
        BESTDUDE.transform.localPosition = new Vector3(0f, 0.3575706f, -0.03383827f);
        PlayerRB.isKinematic = false;
    }
}
