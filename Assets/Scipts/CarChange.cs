using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarChange : MonoBehaviour
{
    public GameObject Car1;
    public GameObject Car2;

    private void OnTriggerEnter(Collider other)
    {
        Car1.SetActive(false);
        Car2.SetActive(true);
    }
}
