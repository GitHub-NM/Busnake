using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusnakeHead : MonoBehaviour
{
    // メンバ変数定義
    // public
    public bool bTrigger;
    public float lerpValueplus;
    public StateDirection stateDirection;
    public StateDirection oldstateDirection;
    public BusnakeStack bStack;
    public BusnakeBody child;
    public GameObject[] bodys;
    public int nMoveCnt;
    public SignManager signManager;
    public Pause pause;
    public Startlogo startlogo;

    public AudioSource[] AudioSource;

    // private
    public Vector3 recttransform;
    private float lerpValue;
    private float ImageSize;
    private float time;
    public bool   bInterbal;

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
        lerpValueplus = 1.0f;
        stateDirection = StateDirection.STATE_RIGHT;
        oldstateDirection = stateDirection;
        ImageSize = 32.0f;
        nMoveCnt = 0;
        child.enabled = true;
        bInterbal = false;

        AudioSource = gameObject.GetComponents<AudioSource>();

        // ポジション宣言
        recttransform = GetComponent<RectTransform>().localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        // トリガーがONになったら
        if (bTrigger)
        {
            // カンスト処理
            if (nMoveCnt >= 999)
            {
                nMoveCnt = 999;
            }

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

            return;
        }
        else if (bTrigger || signManager.goal || !pause.bpop || startlogo.bStart) return;

        // キー入力待ち
        if (!bInterbal && !bTrigger && Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {//下
            if (recttransform.y <= -200) return;
            // 走行距離プラス
            nMoveCnt++;

            q1 = new Vector3(recttransform.x, recttransform.y, recttransform.z);
            q2 = new Vector3(recttransform.x, recttransform.y - ImageSize, recttransform.z);

            // 顔の向きを変える
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);

            // 向きを格納
            oldstateDirection = stateDirection; // 過去の向きを保存
            stateDirection = StateDirection.STATE_DOWN;

            // トリガーON
            bTrigger = true;

            bInterbal = true;
            return;
        }
        else if (!bInterbal && !bTrigger && Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {//上
            if (recttransform.y >= 200) return;

            // 走行距離プラス
            nMoveCnt++;

            q1 = new Vector3(recttransform.x, recttransform.y, recttransform.z);
            q2 = new Vector3(recttransform.x, recttransform.y + ImageSize, recttransform.z);

            // 顔の向きを変える
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);

            // 向きを格納
            oldstateDirection = stateDirection; // 過去の向きを保存
            stateDirection = StateDirection.STATE_UP;

            // トリガーON
            bTrigger = true;

            bInterbal = true;

            return;
        }

        if (!bInterbal && !bTrigger && Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {//左
            if (recttransform.x <= -380) return;
            
            // 走行距離プラス
            nMoveCnt++;

            q1 = new Vector3(recttransform.x, recttransform.y, recttransform.z);
            q2 = new Vector3(recttransform.x - ImageSize, recttransform.y, recttransform.z);

            // 顔の向きを変える
            transform.rotation = Quaternion.Euler(0f, -180f, 0f);

            // 向きを格納
            oldstateDirection = stateDirection; // 過去の向きを保存
            stateDirection = StateDirection.STATE_LEFT;

            // トリガーON
            bTrigger = true;

            bInterbal = true;

            return;
        }
        else if (!bInterbal && !bTrigger && Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {//右

            if (recttransform.x >= 380) return;

            // 走行距離プラス
            nMoveCnt++;

            q1 = new Vector3(recttransform.x, recttransform.y, recttransform.z);
            q2 = new Vector3(recttransform.x + ImageSize, recttransform.y, recttransform.z);

            // 顔の向きを変える
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            // 向きを格納
            oldstateDirection = stateDirection; // 過去の向きを保存
            stateDirection = StateDirection.STATE_RIGHT;

            // トリガーON
            bTrigger = true;

            bInterbal = true;

            return;
        }

        // 一回入力したらインターバルを置く
        if (bInterbal)
        {
            bInterbal = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 動物のタグが付いたものと判定をとる
        if (collision.gameObject.tag == "Animals")
        {
            // 音を再生する
            AudioSource[0].Play();

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
