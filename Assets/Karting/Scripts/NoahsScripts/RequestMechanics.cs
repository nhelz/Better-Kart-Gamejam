using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RequestMechanics : MonoBehaviour
{
    RectTransform rt;
    public GameObject RequestBox;
    public GameObject Pizza;
    public GameObject Paper;
    public GameObject Folder;
    public GameObject timeText;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPoint = Camera.main.transform.position;

        // project camera position onto xz plane
        targetPoint.y = rt.position.y;

        // Vector3.up is a normal of the xz plane
        rt.LookAt(targetPoint, Vector3.up);
    }

    public void DisplayRequest(string requestedItem)
    {
        RequestBox.SetActive(true);
        if(requestedItem == "FolderCollectable")
        {
            Folder.SetActive(true);
        }
        else if(requestedItem == "PaperCollectable")
        {
            Paper.SetActive(true);
        }
        else if (requestedItem == "PizzaCollectable")
        {
            Pizza.SetActive(true);
        }
    }

    public void CompleteRequest()
    {
        Folder.SetActive(false);
        Paper.SetActive(false);
        Pizza.SetActive(false);
        RequestBox.SetActive(false);
    }

    public void UpdateTimeText(string newTime)
    {
        timeText.GetComponent<TextMeshProUGUI>().text = newTime;
    }
}
