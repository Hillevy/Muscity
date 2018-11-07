using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class PostProcessingManager : MonoBehaviour {

    public PostProcessingProfile ppProfile;
    [Range(1, 12)] private int currentTime;

    private float seuil = 0.001f;
    private float tBloom = 0.0f;
    private float tMotionBlur = 0.0f;
    private float tDepthOfField = 0.0f;
    private float tChromaticAbberation = 0.0f;
    private float tColorGrading = 0.0f;
    private float tVignette = 0.0f;
    private float tFog = 0.0f;

    // Use this for initialization
    void Start () {
        ppProfile.bloom.enabled = false;
        ppProfile.motionBlur.enabled = false;
        ppProfile.depthOfField.enabled = false;
        ppProfile.chromaticAberration.enabled = false;
        ppProfile.colorGrading.enabled = false;
        ppProfile.vignette.enabled = false;
        RenderSettings.fog = !enabled;
        RenderSettings.fogMode = FogMode.Exponential;
    }

    #region Update
    // Update is called once per frame
    void Update () {
        switch (currentTime)
        {
            case 0:
                UpdateTime();
                break;
            case 1:
                changeBloom();
                UpdateTime();
                break;
            case 2:
                addMotionBlur();
                UpdateTime();
                break;
            case 3:
                changeDepthOfField();
                UpdateTime();
                break;
            case 4: //End of afternoon
                UpdateTime();
                break;
            case 5:
                changeChromaticAbberation();
                UpdateTime();
                break;
            case 6:
                changeColorGrading();
                UpdateTime();
                break;
            case 7: //Night
                UpdateTime();
                break;
            case 8:
                addFog();
                UpdateTime();
                break;
            case 9:
                changeVignette();
                UpdateTime();
                break;
            case 10:
                changeVignette();
                UpdateTime();
                break;
            case 11:
                UpdateTime();
                break;
            case 12: // ?
                UpdateTime();
                break;
            default:
                break;
        }
    }
    #endregion

    void UpdateTime()
    {
        if (Time.time > 60 * (currentTime+1))
        {
            currentTime += 1;
        }
    }

    #region Bloom
    void changeBloom()
    {
        if (!ppProfile.bloom.enabled)
        {
            ppProfile.bloom.enabled = true;
        }

        //Copy current bloom settings from the profile into a temporary variable
        BloomModel.Settings bloomSettings = ppProfile.bloom.settings;

        if(tBloom < 1)
        {
            tBloom += seuil;

            //Change the parameters
            bloomSettings.bloom.intensity = Mathf.Lerp(1, 1.5f, tBloom);
            bloomSettings.bloom.threshold = Mathf.Lerp(1.1f, 0.8f, tBloom);
            bloomSettings.bloom.softKnee = Mathf.Lerp(0.5f, 0.7f, tBloom);
            bloomSettings.bloom.radius = Mathf.Lerp(4, 5f, tBloom);
        }

        //Set the bloom settings in the actual profile to the temp settings with the changed values
        ppProfile.bloom.settings = bloomSettings;
    }
    #endregion

    #region MotionBlur
    void addMotionBlur()
    {
        if (!ppProfile.motionBlur.enabled)
        {
            ppProfile.motionBlur.enabled = true;
        }
        MotionBlurModel.Settings mbSettings = ppProfile.motionBlur.settings;

        if (tMotionBlur < 1)
        {
            tMotionBlur += seuil;

            //Change the parameters
            mbSettings.shutterAngle = Mathf.Lerp(0, 100, tMotionBlur);
            mbSettings.frameBlending = Mathf.Lerp(0f, 50f, tMotionBlur);
        }

        //Set the motion blur settings in the actual profile to the temp settings with the changed values
        ppProfile.motionBlur.settings = mbSettings;
    }
    #endregion

    #region Depth Of Field
    void changeDepthOfField()
    {
        if (!ppProfile.depthOfField.enabled)
        {
            ppProfile.depthOfField.enabled = true;
        }
        //Copy current bloom settings from the profile into a temporary variable
        DepthOfFieldModel.Settings depthOfFieldSettings = ppProfile.depthOfField.settings;

        if (tDepthOfField < 1)
        {
            tDepthOfField += seuil;

            //Change the parameters
            depthOfFieldSettings.aperture = Mathf.Lerp(1f, 0.4f, tDepthOfField);
            depthOfFieldSettings.focalLength = Mathf.Lerp(40, 45, tDepthOfField);
        }

        //Set the bloom settings in the actual profile to the temp settings with the changed values
        ppProfile.depthOfField.settings = depthOfFieldSettings;
    }
    #endregion

    #region Chromatic Abberation
    void changeChromaticAbberation()
    {
        if (!ppProfile.chromaticAberration.enabled)
        {
            ppProfile.chromaticAberration.enabled = true;
        }
        //Copy current bloom settings from the profile into a temporary variable
        ChromaticAberrationModel.Settings chromaticAbberationSettings = ppProfile.chromaticAberration.settings;

        if (tChromaticAbberation < 1)
        {
            tChromaticAbberation += seuil;

            //Change the parameters
            chromaticAbberationSettings.intensity = Mathf.Lerp(0.1f, 1f, tChromaticAbberation);
        }

        //Set the bloom settings in the actual profile to the temp settings with the changed values
        ppProfile.chromaticAberration.settings = chromaticAbberationSettings;
    }
    #endregion

    #region Color Grading
    void changeColorGrading()
    {
        if (!ppProfile.colorGrading.enabled)
        {
            ppProfile.colorGrading.enabled = true;
        }
        //Copy current bloom settings from the profile into a temporary variable
        ColorGradingModel.Settings colorGradingSettings = ppProfile.colorGrading.settings;

        if (tColorGrading < 1)
        {
            tColorGrading += seuil;

            //Change the parameters
            colorGradingSettings.basic.tint = Mathf.Lerp(0, -50, tColorGrading);
            //colorGradingSettings.basic.hueShift = Mathf.Lerp(0, 90, tColorGrading);
        }

        //Set the bloom settings in the actual profile to the temp settings with the changed values
        ppProfile.colorGrading.settings = colorGradingSettings;
    }
    #endregion

    #region Vignette
    void changeVignette()
    {
        if (!ppProfile.vignette.enabled)
        {
            ppProfile.vignette.enabled = true;
        }
        //Copy current bloom settings from the profile into a temporary variable
        VignetteModel.Settings vignetteSettings = ppProfile.vignette.settings;

        if (tVignette < 1)
        {
            tVignette += seuil/2;

            //Change the parameters
            vignetteSettings.intensity = Mathf.Lerp(0, 0.45f, tVignette);
            vignetteSettings.smoothness = Mathf.Lerp(0.2f, 1f, tVignette);
        }

        //Set the bloom settings in the actual profile to the temp settings with the changed values
        ppProfile.vignette.settings = vignetteSettings;
    }
    #endregion

    #region Fog
    void addFog()
    {
        if (RenderSettings.fog != enabled)
        {
            RenderSettings.fog = enabled;
        }
        if (tFog < 1)
        {   
            RenderSettings.fogDensity = Mathf.Lerp(0.0f, 0.05f, tFog);
            tFog += seuil;
        }
        
    }
    #endregion
}
