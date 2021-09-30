using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndingUI : MonoBehaviour
{
    public ScoreUI scoreUI;
    public TextMeshProUGUI description;
    public GameObject button1;
    public GameObject button2;
    [SerializeField]
    int deliveriesMissed = 0;
    [SerializeField]
    int deliveriesGot = 0;
    [SerializeField]
    int elevatorsTaken = 0;
    [SerializeField]
    int windowsBroken = 0;
    void Awake()
    {
        //Time.timeScale = 0f;
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
    public void FreePlay()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    public IEnumerator MagicMaybe()
    {
        Time.timeScale = 0f;
        gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);
        yield return new WaitForSecondsRealtime(.3f);
        description.text = "Successful Deliveries: " + deliveriesGot + " \n\n Missed Deliveries: \n\n Elevators 'Taken': \n\n Sky Dives: \n\n\n\n\n\n Final Score:";
        yield return new WaitForSecondsRealtime(.3f);
        description.text = "Successful Deliveries: " + deliveriesGot + " \n\n Missed Deliveries: " + deliveriesMissed + " \n\n Elevators 'Taken': \n\n Sky Dives: \n\n\n\n\n\n Final Score:";
        yield return new WaitForSecondsRealtime(.3f);
        description.text = "Successful Deliveries: " + deliveriesGot + " \n\n Missed Deliveries: " + deliveriesMissed + " \n\n Elevators 'Taken': " + elevatorsTaken + " \n\n Sky Dives: \n\n\n\n\n\n Final Score:";
        yield return new WaitForSecondsRealtime(.3f);
        description.text = "Successful Deliveries: " + deliveriesGot + " \n\n Missed Deliveries: " + deliveriesMissed + " \n\n Elevators 'Taken': " + elevatorsTaken + " \n\n Sky Dives: " + windowsBroken + " \n\n\n\n\n\n Final Score:";
        yield return new WaitForSecondsRealtime(.3f);
        description.text = "Successful Deliveries: " + deliveriesGot + " \n\n Missed Deliveries: " + deliveriesMissed + " \n\n Elevators 'Taken': " + elevatorsTaken + " \n\n Sky Dives: " + windowsBroken + " \n\n\n\n\n\n Final Score:" + scoreUI.getPoints();
        yield return new WaitForSecondsRealtime(.3f);
        button1.SetActive(true);
        button2.SetActive(true);
    }

    public void AddDM()
    {
        deliveriesMissed++;
    }

    public void AddDG()
    {
        deliveriesGot++;
    }

    public void AddET()
    {
        elevatorsTaken++;
    }

    public void AddWB()
    {
        windowsBroken++;
    }
}
