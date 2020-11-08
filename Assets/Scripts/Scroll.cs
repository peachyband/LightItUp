using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public SceneChanger scnctr;
    private SpriteRenderer sprtctrl;
    public Sprite[] sprites = new Sprite[3];
    int i = 0;

    private void Start()
    {
        sprtctrl = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            sprtctrl.sprite = sprites[i];
            i++;
        }
        if (i == 3)
        {
           scnctr.ChangeScene("MainScene");
        }
    }
}
