using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ColorChange : MonoBehaviour
{
    private GameObject volume;

    private ColorAdjustments colorAdjustments;
    private FilmGrain filmGrain;

    // Start is called before the first frame update
    void Start()
    {
        volume = GameObject.Find("Global Volume");
        contrast = volume.GetComponent<ColorAdjustments>().contrast;
        filmGrain = volume.GetComponent<FilmGrain>();

        colorAdjustments.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
