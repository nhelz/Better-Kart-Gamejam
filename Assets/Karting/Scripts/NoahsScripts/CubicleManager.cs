using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubicleManager : MonoBehaviour
{
    public ScoreUI scoreManager;
    public EndingUI endUI;
    public ItemCatcher hitbox;
    public RequestMechanics requestUI;
    public GameObject worker;

    public string[] PossibleTasks;

    private Vector3 workerOrigin;
    private bool hasTask = false;
    private float taskTime;
    private float taskDuration = 25f;
    private float timeBetweenTasks = 15f;

    // Start is called before the first frame update
    void Start()
    {
        workerOrigin = worker.transform.position;
        StartCoroutine(DelayedStart());
        endUI = GameObject.FindGameObjectWithTag("EndUI").GetComponent<EndingUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTask)
        {
            taskTime -= Time.deltaTime;
            if(taskTime <= 0f)
            {
                hasTask = false;
                hitbox.NewItemToCatch("none");
                endUI.AddDM();
                StartCoroutine(TaskCooldown());
            }
        }
        else
        {
            taskTime = taskDuration;
        }
        requestUI.UpdateTimeText(((int)taskTime).ToString());
    }

    public IEnumerator TaskCooldown()
    {
        yield return new WaitForSeconds(timeBetweenTasks);
        SetNewTask();
        
    }

    private void SetNewTask()
    {
        int taskNum = Random.Range(0, PossibleTasks.Length);
        hitbox.NewItemToCatch(PossibleTasks[taskNum]);
        hasTask = true;
    }

    public IEnumerator CatchItem(Vector3 catchPos)
    {
        worker.transform.position = catchPos;
        int pointsearned = 2000 * (int)taskTime;
        endUI.AddDG();
        scoreManager.AddPoints(pointsearned);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(.5f);
        worker.transform.position = workerOrigin;
        hasTask = false;
    }

    private IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(Random.Range(0f, 20f));
        SetNewTask();
        taskTime = taskDuration;
    }
}
