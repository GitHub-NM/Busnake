using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour
{
    public int nSpriteNum;
    public Sprite[] Sprite;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        switch(nSpriteNum)
        {
            case 0:
                GetComponent<Image>().sprite = Sprite[0];
                break;
            case 1:
                GetComponent<Image>().sprite = Sprite[1];
                break;
            case 2:
                GetComponent<Image>().sprite = Sprite[2];
                break;
        }
    }
}
