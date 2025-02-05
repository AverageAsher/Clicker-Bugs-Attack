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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnCollect(InputValue context) 
    {
        dollarScaler.StartScaling();
        updateMoney.AddMoney();
    }

    public void OnPause(InputValue context)
    {
        pauseManager.TogglePause();
        playUiSound.PlaySound();

    }

    public void OnCrushBug1(InputValue context)
    {

    }

    public void OnCrushBug2(InputValue context)
    {

    }

    public void OnCrushBug3(InputValue context)
    {

    }
}
