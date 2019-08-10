using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Mouseclick,EnterKey,SpacekeyでStageSelect→Gamemainにシーン遷移
        //PCの入力モードが半角になっていないとSpaceKeyが反応しない(かなしい)
        if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Gamemain");
        }
    }
}
