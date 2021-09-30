using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    int score = 0;
    private TextMeshProUGUI tmp;
    string baseZeros = "0000000000000000000";
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        //AddPoints(3000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(int newpoints)
    {
        score += Mathf.Abs(newpoints);
        int scoredigits = score.ToString().Length;

        //Debug.Log(baseZeros.Length + " versus " + score.ToString().Length + " versus " + score.ToString().PadLeft(19 - scoredigits, '0').Length);
        tmp.text = "Score: ".PadRight(26 - scoredigits, '0') + score.ToString();
        //Debug.Log(tmp.text.Length);
    }

    public int getPoints()
    {
        return score;
    }

}
