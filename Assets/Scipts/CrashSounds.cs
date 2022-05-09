using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashSounds : MonoBehaviour
{
    public AudioSource CrashSource;
    public AudioClip CrashClip;
    public GameObject Car;
    
        
    // Start is called before the first frame update
    void Start()
    {
        CrashSource = gameObject.AddComponent <AudioSource>();
        CrashSource.clip = CrashClip;
        CrashSource.loop = false;
        //CrashSource.volume = 1.0f;
        CrashSource.Stop();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }


    void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider.gameObject.CompareTag("Hittable"))
        //{
        //    CrashSource.PlayOneShot(CrashClip);
        //    Debug.Log("CrashDetected" + gameObject.name);
        //}
        if (collision.relativeVelocity.magnitude > 10)
        {
            Debug.Log("CrashDetected" + gameObject.name);
            CrashSource.PlayOneShot(CrashClip);
            CrashSource.volume = 0.5f;
            CrashSource.pitch = 1f;
        }
        else if (collision.relativeVelocity.magnitude > 3)
        {
            CrashSource.volume = 0.3f;
            CrashSource.PlayOneShot(CrashClip);
            Debug.Log("Small Crash");
            CrashSource.pitch = 2.4f;
        }
    }
}
