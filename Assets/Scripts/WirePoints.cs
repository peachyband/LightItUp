using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePoints : MonoBehaviour
{
    public Point[] points = new Point[3];
    public GameObject roomlight;
    public Room doorctrl;
    public PlayerMovement player;

    void Start()
    {
        doorctrl = gameObject.GetComponent<Room>();
        player = gameObject.GetComponent<PlayerMovement>();
        points[0].SetBeing(true);
    }


    void Update()
    {
        if (points[0].GetChecked()) points[1].SetBeing(true);
        if (points[1].GetChecked()) points[2].SetBeing(true);
        if (points[0].GetChecked() && points[1].GetChecked() && points[2].GetChecked())
        {
            roomlight.SetActive(true);
        }
    }
}
