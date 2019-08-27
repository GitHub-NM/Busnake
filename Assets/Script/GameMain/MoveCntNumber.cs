using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCntNumber : MonoBehaviour
{
    // メンバ変数宣言
    public BusnakeHead busnakeHead;
    public int nCnt;
    public num StateNum;
    public Sprite[] Sprite;
    public enum num{
        STATE_ONE,
        STATE_TEN,
        STATE_HUNDRED,
    };

    // Start is called before the first frame update
    void Start()
    {
        // 初期化宣言
        nCnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (StateNum)
        {
            case num.STATE_ONE:
                // １の位
                nCnt = busnakeHead.nMoveCnt % 10;
                break;
            case num.STATE_TEN:
                // 10の位
                nCnt = (busnakeHead.nMoveCnt % 100) / 10;
                break;

            case num.STATE_HUNDRED:
                // 100の位
                nCnt = busnakeHead.nMoveCnt / 100;
                break;
        }

        // スプライト変更
        GetComponent<Image>().sprite = Sprite[nCnt];
    }
}
