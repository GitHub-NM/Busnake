using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pataanim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localEulerAngles.x>=-180)
        transform.Rotate(new Vector3(-5, 0, 0));
        else if(transform.localEulerAngles.x >= 0)
        {
            transform.Rotate(new Vector3(0, 0, 0));
        }
        
    }
}
