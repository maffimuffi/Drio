using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System.Collections;


public class VignettePulse : MonoBehaviour
{
    float updater = 0.1f;
    float IncreaseSpeed;
    float IncreaseSpeed2 = 1;
    void Start()
    {
        var vignette = ScriptableObject.CreateInstance<Vignette>();
        vignette.enabled.Override(true);
        vignette.intensity.Override(1f);

        
    }

     void Update()
        {
            if (LastBowl.lastBowlLit == true)
            {
            IncreaseSpeed2 += Time.deltaTime / 5 * IncreaseSpeed;
            IncreaseSpeed += Time.deltaTime / 5;
            updater += (Time.deltaTime / 2) * IncreaseSpeed * IncreaseSpeed2;
            var vignette = ScriptableObject.CreateInstance<Vignette>();
            vignette.enabled.Override(true);
            vignette.intensity.Override(updater);
            var volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 10f, vignette);
            volume.weight= 1;
            }
        }
        
        

        
    }
