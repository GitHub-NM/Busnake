using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusnakeMoveAnim : MonoBehaviour
{
    // メンバ変数定義
    // public
    public  bool  bTrigger;
    public float  lerpValueplus;
    public StateDirection stateDirection;
    public StateDirection oldstateDirection;
    public BusnakeStack bStack;
    public GameObject[] bodys;
    // private
    public Vector3 recttransform;
    private float lerpValue;
    private float ImageSize;

    // クォータニオンの準備
    private Vector3 q1;
    private Vector3 q2;
    
    // 列挙宣言
    public enum StateDirection
    {// 顔の向きの列挙構造体
        STATE_RIGHT = 0,
        STATE_LEFT,
        STATE_UP,
        STATE_DOWN,
    };

    // Start is called before the first frame update
    void Start()
    {
        //初期化
        bTrigger = false;
        lerpValue = 0.0f;
        lerpValueplus = 0.05f;
        stateDirection = StateDirection.STATE_RIGHT;
        oldstateDirection = stateDirection;
        ImageSize = 32.0f;

        // ポジション宣言
        recttransform = GetComponent<RectTransform>().localPosition;

    }

    // Update is called once per frame
    void Update()
    {

        // キー入力待ち
        if (!bTrigger && Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {//下
            q1 = new Vector3(recttransform.x, recttransform.y, recttransform.z);
            q2 = new Vector3(recttransform.x, recttransform.y - ImageSize, recttransform.z);

            // 顔の向きを変える
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);

            // 向きを格納
            oldstateDirection = stateDirection; // 過去の向きを保存
            stateDirection = StateDirection.STATE_DOWN;

            // トリガーON
            bTrigger = true;
        }
        else if (!bTrigger && Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {//上
            q1 = new Vector3(recttransform.x, recttransform.y, recttransform.z);
            q2 = new Vector3(recttransform.x, recttransform.y + ImageSize, recttransform.z);

            // 顔の向きを変える
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);

            // 向きを格納
            oldstateDirection = stateDirection; // 過去の向きを保存
            stateDirection = StateDirection.STATE_UP;

            // トリガーON
            bTrigger = true;
        }

        if (!bTrigger && Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {//左
            q1 = new Vector3(recttransform.x, recttransform.y, recttransform.z);
            q2 = new Vector3(recttransform.x - ImageSize, recttransform.y, recttransform.z);

            // 顔の向きを変える
            transform.rotation = Quaternion.Euler(0f, -180f, 0f);

            // 向きを格納
            oldstateDirection = stateDirection; // 過去の向きを保存
            stateDirection = StateDirection.STATE_LEFT;

            // トリガーON
            bTrigger = true;
        }
        else if (!bTrigger && Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {//右
            q1 = new Vector3(recttransform.x, recttransform.y, recttransform.z);
            q2 = new Vector3(recttransform.x + ImageSize, recttransform.y, recttransform.z);

            // 顔の向きを変える
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            // 向きを格納
            oldstateDirection = stateDirection; // 過去の向きを保存
            stateDirection = StateDirection.STATE_RIGHT;

            // トリガーON
            bTrigger = true;

        }

        // トリガーがONになったら
        if (bTrigger)
        {
            // 線形補間
            recttransform = Vector3.Lerp(q1, q2, lerpValue);
            GetComponent<RectTransform>().localPosition = recttransform;

            // 値を足す
            lerpValue += lerpValueplus;

            // 値が1.0f以上になったらやめる
            if (lerpValue >= 1.0f)
            {
                // 正規化
                lerpValue = 1.0f;
                
                // 線形補間
                recttransform = Vector3.Lerp(q1, q2, lerpValue);
                GetComponent<RectTransform>().localPosition = recttransform;

                // 初期化
                bTrigger = false;
                lerpValue = 0.0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 動物のタグが付いたものと判定をとる
        if (collision.gameObject.tag == "Animals")
        {
            // 当たったオブジェクトを変更をかける
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false; // 判定を消す
            collision.gameObject.GetComponent<Image>().sprite = collision.gameObject.GetComponent<AnimalStack>().sprite[1];

            // ポジションを移動させる          
            collision.gameObject.transform.localPosition = bodys[bStack.stack.Count].transform.localPosition;
            
            // 子オブジェクトにする
            collision.gameObject.transform.parent = bodys[bStack.stack.Count].transform;

            // スタックする
            bStack.stack.Push(collision.gameObject.GetComponent<AnimalStack>());
        }
    }

    // 向き取得関数
    public StateDirection GetDirection()
    {
        return stateDirection;
    }

    // 過去向き取得関数
    public StateDirection GetOldDirection()
    {
        return oldstateDirection;
    }

}
