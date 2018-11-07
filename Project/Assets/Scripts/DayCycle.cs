using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour {

    public Light lightSource;
    public int currentHour;

    public List<Material> SkyboxList;

    private Quaternion startingSunCoordinates;
    private Quaternion startingMoonCoordinates;

    // Use this for initialization
    void Start () {
        RenderSettings.skybox = SkyboxList[0];
        startingSunCoordinates = Quaternion.Euler(37, 0, 25);
        startingMoonCoordinates = Quaternion.Euler(5, -50, 25);
    }

    public void SetNightTime()
    {
        lightSource.transform.rotation = startingMoonCoordinates;
        lightSource.GetComponent<Light>().intensity = 0.3f;
        RenderSettings.skybox = SkyboxList[1];
    }

    public void UpdateLightPosition()
    {
        if (currentHour < 13)
        {
            Quaternion currentRotation = lightSource.transform.rotation;
            if (currentHour < 8)
            { 
                lightSource.transform.Rotate(new Vector3(-0.038f, 0.12f, -0.071f));
            }
            else if(currentHour < 12)
            {
                lightSource.transform.Rotate(new Vector3(+0.224f, 0.24f, -0.071f));
            }
        }
    }

    public void UpdateLightSettings()
    {
        // TODO: Select color for the light and skybox
        switch (currentHour)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                break;
            case 12:
                break;
            default:
                break;
        }
    }
}
