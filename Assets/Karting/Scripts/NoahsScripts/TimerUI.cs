using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerUI : MonoBehaviour
{
    private float timeLeft = 300f;
    private TextMeshProUGUI tmp;
    public EndingUI endUI;
    private bool timeout = false;
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0f)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            UpdateText();
            if(!timeout)
            {
                timeout = true;
                StartCoroutine(endUI.MagicMaybe());
            }
        }
        UpdateText();
        
    }

    private void UpdateText()
    {
        string hours = ((int)(timeLeft / 60f)).ToString().PadLeft(1, '0');
        string minutes = ((int)(timeLeft % 60f)).ToString().PadLeft(2, '0');
        tmp.text = "Time: 0" + hours + ":" + minutes;
    }
}
