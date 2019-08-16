using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Mouseclick,EnterKey,SpacekeyでTitle→Selectにシーン遷移
        //PCの入力モードが半角になっていないとSpaceKeyが反応しない(かなしい)
        if (Input.GetKey(KeyCode.Return)|| Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("StageSelect");
        }
        
        //初回起動のみ続きからを表示しない
        //続きからを選んだ場合、セーブデータにアクセスしてデータをロードする処理を作る
       
    }
}
