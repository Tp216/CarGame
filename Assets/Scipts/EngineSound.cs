using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour
{
    public AudioSource EngineSource;
    public float MinPitch = 1f;
    private float PitchFromCar;
    // Start is called before the first frame update
    void Start()
    {
        EngineSource = GetComponent<AudioSource>();
        EngineSource.pitch = MinPitch;   
    }

    // Update is called once per frame
    void Update()
    {
        PitchFromCar = (CarController.cc.CurrentCarSpeed);
        if(PitchFromCar < MinPitch)
        {
            EngineSource.pitch = MinPitch;
        }
        else
        {
            EngineSource.pitch = PitchFromCar;
        }
    }
}
