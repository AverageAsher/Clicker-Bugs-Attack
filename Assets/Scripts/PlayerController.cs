using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public UpdateMoney updateMoney;

    public DollarScaler dollarScaler;

    public PauseManager pauseManager;

    public PlayUiSound playUiSound;

    private BugMovement bug1, bug2, bug3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Bug1") != null && bug1 == null)
        {
            bug1 = GameObject.FindWithTag("Bug1").GetComponent<BugMovement>();
        }

        if (GameObject.FindWithTag("Bug2") != null && bug2 == null)
        {
            bug2 = GameObject.FindWithTag("Bug2").GetComponent<BugMovement>();
        }

        if (GameObject.FindWithTag("Bug3") != null && bug3 == null)
        {
            bug3 = GameObject.FindWithTag("Bug3").GetComponent<BugMovement>();
        }
    }


    public void OnCollect(InputValue context) 
    {
        if (pauseManager.isPaused == false)
        {
            dollarScaler.StartScaling();
            updateMoney.AddMoney();
        }
        
    }

    public void OnPause(InputValue context)
    {
        pauseManager.TogglePause();
        playUiSound.PlaySound();

    }

    public void OnCrushBug1(InputValue context)
    {
        if (bug1 != null)
             bug1.ResetPosition();
    }

    public void OnCrushBug2(InputValue context)
    {
        if (bug2 != null)
        bug2.ResetPosition();
    }

    public void OnCrushBug3(InputValue context)
    {
        if (bug3 != null)
        bug3.ResetPosition();
    }
}
