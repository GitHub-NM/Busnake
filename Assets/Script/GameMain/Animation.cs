using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation : MonoBehaviour
{
    public GameObject PlayerCurrentTex;
    public Sprite[] PlayerTexNumber;

    float time;
    int i;

    // Use this for initialization
    void Start()
    {
        time = 0.0f;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time++;

        if (time > 10.0f)
        {
            if (i == 0)
                i = 1;
            else
                i = 0;

            this.GetComponent<Image>().sprite = PlayerTexNumber[i];
            time = 0.0f;
        }

    }

}
