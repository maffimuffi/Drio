using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System.Collections;


public class VignettePulse : MonoBehaviour
{
    float updater = 0.1f;
    float IncreaseSpeed;
    float IncreaseSpeed2 = 1;
    float timer;
    float multiplier;
    public static bool restartValue;
    

    // Aika jona uuden scenen jälkeen menee restartValue takas falseks;
    float timeToRestartFalse;

    public bool finished;

    void Start()
    {
        var vignette = ScriptableObject.CreateInstance<Vignette>();
        vignette.enabled.Override(true);
        vignette.intensity.Override(0.1f);
        timer = 0;
        finished = false;
        restartValue = true;
        
    }

    void Update()
    {
        if (restartValue == true)
        {
            timeToRestartFalse += Time.deltaTime;
            var vignette = ScriptableObject.CreateInstance<Vignette>();
            vignette.enabled.Override(true);
            vignette.intensity.Override(0.1f);
            var volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 10f, vignette);
            volume.weight = 1;
            Debug.Log("yeS29");
            if (timeToRestartFalse > 5)
            {
                restartValue = false;
            }
        }
        //if (restartValue == false && LastBowl.lastBowlLit == false)
        //{
        //    var vignette = ScriptableObject.CreateInstance<Vignette>();
        //    vignette.enabled.Override(true);
        //    vignette.intensity.Override(0.1f);
        //    var volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 10f, vignette);
        //    volume.weight = 1;
        //}

        if (LastBowl.lastBowlLit == true)
        {
            Debug.Log("ei tänne");
            timer += Time.deltaTime;
            Debug.Log(finished);
            // 5.5 speed up // 8 really fast // 20 loppu
            if(timer <= 5.5f)
            {
                multiplier = 3.3f;
            }
            else if(timer > 5.5f && timer <= 8f)
            {
                multiplier = 0.7f;
            }
            else if(timer > 8f && timer < 8.5f)
            {
                multiplier = 0.01f;
            }
            else if(timer >= 8.5f)
            {
                finished = true;
            }

            IncreaseSpeed2 += Time.deltaTime / multiplier * IncreaseSpeed;
            IncreaseSpeed += Time.deltaTime / multiplier;
            updater += (Time.deltaTime / 2) * IncreaseSpeed * IncreaseSpeed2;
            var vignette = ScriptableObject.CreateInstance<Vignette>();
            vignette.enabled.Override(true);
            vignette.intensity.Override(updater);
            var volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 10f, vignette);
            volume.weight= 1;
        }
    }  
}
