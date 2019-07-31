using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusnakeMove : MonoBehaviour
{
    // メンバ変数宣言
    private Transform mytransform;
    public GameObject[] AnimalObj = new GameObject[10];
    public BusnakeStack bStack;
    private int nCnt;

    // Start関数
    void Start()
    {
        // 初期化
        nCnt = 0;
    }

    // Update関数
    void Update()
    {
        // ポジション宣言
        mytransform = GetComponent<Transform>();

        // キー入力待ち
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {//下
            mytransform.position = new Vector3(mytransform.position.x, mytransform.position.y - 1.0f, mytransform.position.z);
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {//上
            mytransform.position = new Vector3(mytransform.position.x, mytransform.position.y + 1.0f, mytransform.position.z);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {//左
            mytransform.position = new Vector3(mytransform.position.x - 1.0f, mytransform.position.y, mytransform.position.z);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {//右
            mytransform.position = new Vector3(mytransform.position.x + 1.0f, mytransform.position.y, mytransform.position.z);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 動物のタグが付いたものと判定をとる
        if (collision.gameObject.tag == "Animals")
        {
            // 当たったオブジェクトを変更をかける
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false; // 判定を消す
            collision.gameObject.GetComponent<Image>().enabled = false;

            // 子オブジェクトにする
            collision.gameObject.transform.parent = transform;

            // スタックする
            bStack.stack.Push(collision.gameObject.GetComponent<AnimalStack>());

            // オブジェクトを格納する
            AnimalObj[nCnt] = collision.gameObject;
            nCnt++;
        }
    }

}