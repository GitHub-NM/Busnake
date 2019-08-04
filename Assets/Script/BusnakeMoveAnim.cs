using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusnakeMoveAnim : MonoBehaviour
{
    // メンバ変数定義
    private RectTransform recttransform;
    public  bool  bTrigger;
    private float lerpValue;

    // クォータニオンの準備
    private Vector3 q1;
    private Vector3 q2;
    
    // Start is called before the first frame update
    void Start()
    {
        //初期化
        bTrigger = false;
        lerpValue = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // ポジション宣言
        recttransform = GetComponent<RectTransform>();

        // キー入力待ち
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) && !bTrigger)
        {//下
            q1 = new Vector3(recttransform.position.x, recttransform.position.y, recttransform.position.z);
            q2 = new Vector3(recttransform.position.x, recttransform.position.y - recttransform.rect.height, recttransform.position.z);

            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            
            // トリガーON
            bTrigger = true;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && !bTrigger)
        {//上
            q1 = new Vector3(recttransform.position.x, recttransform.position.y, recttransform.position.z);
            q2 = new Vector3(recttransform.position.x, recttransform.position.y + recttransform.rect.height, recttransform.position.z);

            transform.rotation = Quaternion.Euler(0f, 0f, 90f);

            // トリガーON
            bTrigger = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) && !bTrigger)
        {//左
            q1 = new Vector3(recttransform.position.x, recttransform.position.y, recttransform.position.z);
            q2 = new Vector3(recttransform.position.x - recttransform.rect.width, recttransform.position.y, recttransform.position.z);

            transform.rotation = Quaternion.Euler(0f, -180f, 0f);

            // トリガーON
            bTrigger = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) && !bTrigger)
        {//右
            q1 = new Vector3(recttransform.position.x, recttransform.position.y, recttransform.position.z);
            q2 = new Vector3(recttransform.position.x + recttransform.rect.width, recttransform.position.y, recttransform.position.z);

            transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            // トリガーON
            bTrigger = true;
        }

        // トリガーがONになったら
        if (bTrigger)
        {
            // 線形補間
            recttransform.position = Vector3.Lerp(q1, q2, lerpValue);

            // 値を足す
            lerpValue += 0.05f;

            // 値が1.0f以上になったらやめる
            if (lerpValue >= 1.0f)
            {
                // 初期化
                bTrigger = false;
                lerpValue = 0.0f;
            }
        }
    }
}
