using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockManager : MonoBehaviour {

    public DayCycle dayCycleManager;

    public int hourDuration;
    public int currentHour;

    private float second;
    private float hour;

	// Use this for initialization
	void Start () {
        dayCycleManager = dayCycleManager.GetComponent<DayCycle>();
        second = 1f;
        hour = (float)hourDuration;
	}

    private void SendSecondTick()
    {
        second = 1f;
        dayCycleManager.UpdateLightPosition();
    }

    private void SendHourTick()
    {
        currentHour++;
        hour = (float) hourDuration;

        Debug.Log("New Hour: " + currentHour.ToString());
        
        // DayCycle Update;
        if(currentHour == 8)
        {
            dayCycleManager.SetNightTime();
        }
        dayCycleManager.currentHour = currentHour;
        dayCycleManager.UpdateLightPosition();
        dayCycleManager.UpdateLightSettings();
    }

	// Update is called once per frame
	void Update () {
        float elapsedTime = Time.deltaTime;
        second -= elapsedTime;
        hour -= elapsedTime;

        if(second <= 0)
        {
            SendSecondTick();
        }

        if(hour <= 0)
        {
            SendHourTick();
        }
    }
}
