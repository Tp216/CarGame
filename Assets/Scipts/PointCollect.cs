//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;

//public class PointCollect : MonoBehaviour
//{
//    public int CollectedPoints;
//    public TextMeshProUGUI Points;

//    public GameObject CarChanger;

//    private void Start()
//    {
//        CollectedPoints = 0;
//        SetPointText();
//    }

//    void SetPointText()
//    {
//        Points.text = "Points: " + CollectedPoints.ToString();
//    }
//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.tag == "Points")
//        {
//            if( other.tag =="Player")
//            { other.gameObject.SetActive(false);
//            CollectedPoints = CollectedPoints + 1;
//            other.gameObject.SetActive(false);
//            SetPointText();
//                if (CollectedPoints >= 5)
//                {
//                    CarChanger.SetActive(true);
//                }
//            }
//        }
//    }
//}
