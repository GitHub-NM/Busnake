using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pataanim : MonoBehaviour
{

    float angle = 1;
    int pataanim_movenum = 0;
    float pataanim_speed = 5.0f;

    public bool patamugen;

    public AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = gameObject.GetComponent<AudioSource>();

        if (patamugen==true)
        {
            pataanim_movenum = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(angle, 0, 0.0f);
        switch (pataanim_movenum)
        {
            case 0:
                if (angle < 180 && angle >= 0)
                {
                    angle += 5f;
                }
                else
                {
                    AudioSource.Play();

                    angle = -180f;
                    pataanim_movenum = 1;
                }
                    break;
            case 1:
                if (angle < 0 && angle >= -180)
                {
                    angle += 5f;
                }
                else
                {
                    AudioSource.Play();

                    angle = 0f;
                }
                break;

            case 2:
                angle += 5f;
                break;

        }

        
    }
}
