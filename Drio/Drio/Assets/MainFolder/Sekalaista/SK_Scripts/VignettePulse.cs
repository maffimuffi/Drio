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

    public bool finished;

    void Start()
    {
        var vignette = ScriptableObject.CreateInstance<Vignette>();
        vignette.enabled.Override(true);
        vignette.intensity.Override(1f);
        timer = 0;
        finished = false;
        
    }

    void Update()
    {
        if (LastBowl.lastBowlLit == true)
        {
            timer += Time.deltaTime;
            Debug.Log(finished);
            // 5.5 speed up // 8 really fast // 20 loppu
            if(timer <= 5.5f)
            {
                multiplier = 4f;
            }
            else if(timer > 5.5f && timer <= 8f)
            {
                multiplier = 1f;
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
