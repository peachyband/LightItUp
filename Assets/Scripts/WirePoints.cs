using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePoints : MonoBehaviour
{
    public Point[] points = new Point[3];
    
    void Start()
    {
        points[0].SetBeing(true);
    }


    void Update()
    {
        if (points[0].GetChecked()) points[1].SetBeing(true);
        if (points[1].GetChecked()) points[2].SetBeing(true);
    }
}
