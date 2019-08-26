using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignManager : MonoBehaviour
{
    // メンバ宣言
    public SignJudg[] signJudgs;
    private bool goal;

    void Start()
    {
        // 初期化
        goal = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 変数宣言
        int nCnt = 0;

        for (int i = 0; i < signJudgs.Length; i++)
        {
            // バス停に動物がいるか調べる
            if(signJudgs[i].arrival == true)
            {
                // いたらカウント
                nCnt++;
            }
            else
            {
                return;
            }
            
            // カウントが配列数と一緒だったらフラグを立てる
            if(signJudgs.Length == nCnt)
            {
                Debug.Log("終わり");
                goal = true;
            }
        }
    }
}
