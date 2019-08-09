using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusnakeAnim : MonoBehaviour
{
    // メンバ変数定義
    public GameObject parentgameObject;
    private RectTransform recttransform;
    public BusnakeMoveAnim BusnakeMoveAnim;
    public Sprite[] PlayerTexNumber;
    private float lerpValue;
    public float lerpValueplus;
    private bool bTrigger;
    public int Direction;
    public int OldDirection;

    // クォータニオンの準備
    private Vector3 q1;
    private Vector3 q2;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.name);

        // 初期化
        parentgameObject = transform.parent.gameObject;
        if(parentgameObject.name == "BusnakeObject")
        {
            parentgameObject = GameObject.Find("Busnake_head");
        }
        bTrigger = false;
        lerpValue = 0.0f;
        lerpValueplus = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        // 回転を子オブジェクトで固定
        //gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        //gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z);

        // ポジション宣言
        recttransform = GetComponent<RectTransform>();

        // 頭が移動したら
        if (BusnakeMoveAnim.bTrigger)
        {
            if (!bTrigger)
            {
                q1 = new Vector3(recttransform.position.x, recttransform.position.y, recttransform.position.z);
                q2 = new Vector3(parentgameObject.GetComponent<RectTransform>().position.x, parentgameObject.GetComponent<RectTransform>().position.y, parentgameObject.GetComponent<RectTransform>().position.z);
                lerpValue += lerpValueplus;
                bTrigger = true;

                // 体の先頭を分ける
                if (parentgameObject.name == "Busnake_head")
                {// 頭の向き取得
                    OldDirection = Direction;
                    Direction = (int)parentgameObject.GetComponent<BusnakeMoveAnim>().GetOldDirection();
                }
                else
                {// 親のオブジェクトの向きを取得
                    OldDirection = Direction;
                    Direction = parentgameObject.GetComponent<BusnakeAnim>().OldDirection;
                }

                // DIrectionの中身をちゃんと入れる（多分ちゃんと入ってない）


                switch (Direction)
                {
                    // 右
                    case 0:
                        // 画像がStraightだったら
                        if (GetComponent<Image>().sprite.name == PlayerTexNumber[1].name)
                        {
                            // 体の先頭を分ける
                            if (parentgameObject.name == "Busnake_head")
                            {// 頭の向き取得
                                if (2 == (int)parentgameObject.GetComponent<BusnakeMoveAnim>().GetOldDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                                else if (3 == (int)parentgameObject.GetComponent<BusnakeMoveAnim>().GetOldDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                }
                                else
                                {
                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                            }
                            else
                            {
                                if (2 == (int)parentgameObject.GetComponent<BusnakeAnim>().OldDirection)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                                else if (3 == (int)parentgameObject.GetComponent<BusnakeAnim>().OldDirection)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                }
                                else
                                {
                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                            }
                        }
                        else
                        {
                            // 体の先頭を分ける
                            if (parentgameObject.name == "Busnake_head")
                            {// 頭の向き取得
                                if (2 == (int)parentgameObject.GetComponent<BusnakeMoveAnim>().GetOldDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                                else if (3 == (int)parentgameObject.GetComponent<BusnakeMoveAnim>().GetOldDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                }
                                else
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[1];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                            }
                            else
                            {
                                if (2 == (int)parentgameObject.GetComponent<BusnakeAnim>().OldDirection)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                                else if (3 == (int)parentgameObject.GetComponent<BusnakeAnim>().OldDirection)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                }
                                else
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[1];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                            }
                        }

                        break;

                    // 左
                    case 1:
                        // 画像がStraightだったら
                        if (GetComponent<Image>().sprite.name == PlayerTexNumber[1].name)
                        {
                            // 体の先頭を分ける
                            if (parentgameObject.name == "Busnake_head")
                            {// 頭の向き取得
                                if (2 == (int)parentgameObject.GetComponent<BusnakeMoveAnim>().GetOldDirection())
                                {                                    
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                                 }
                                else if (3 == (int)parentgameObject.GetComponent<BusnakeMoveAnim>().GetOldDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                                }
                                else
                                {
                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                            }
                            else
                            {
                                if (2 == (int)parentgameObject.GetComponent<BusnakeAnim>().OldDirection)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                                }
                                else if (3 == (int)parentgameObject.GetComponent<BusnakeAnim>().OldDirection)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                                }
                                else
                                {
                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }

                            }
                        }
                        else
                        {
                            // 体の先頭を分ける
                            if (parentgameObject.name == "Busnake_head")
                            {// 頭の向き取得
                                if (2 == (int)parentgameObject.GetComponent<BusnakeMoveAnim>().GetOldDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                                }
                                else if (3 == (int)parentgameObject.GetComponent<BusnakeMoveAnim>().GetOldDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                                }
                                else
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[1];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                            }
                            else
                            {
                                if (2 == (int)parentgameObject.GetComponent<BusnakeAnim>().OldDirection)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                                }
                                else if (3 == (int)parentgameObject.GetComponent<BusnakeAnim>().OldDirection)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                                }
                                else
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[1];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                            }
                        }
                        break;
                    // 上
                    case 2:
                        // 画像がStraightだったら
                        if (GetComponent<Image>().sprite.name == PlayerTexNumber[1].name)
                        {
                            // 体の先頭を分ける
                            if (parentgameObject.name == "Busnake_head")
                            {// 頭の向き取得
                                if (0 == (int)parentgameObject.GetComponent<BusnakeMoveAnim>().GetDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];
                                   
                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                                else if (1 == (int)parentgameObject.GetComponent<BusnakeMoveAnim>().GetDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                                }
                                else
                                {
                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                }
                            }
                            else
                            {
                                if (2 == (int)parentgameObject.GetComponent<BusnakeAnim>().OldDirection)
                                {
                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                }
                                else if (0 == (int)parentgameObject.GetComponent<BusnakeAnim>().OldDirection)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                                }
                                else if (1 == (int)parentgameObject.GetComponent<BusnakeAnim>().OldDirection)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                }
                                else
                                {
                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                }

                            }
                        }
                        else
                        {
                            // 体の先頭を分ける
                            if (parentgameObject.name == "Busnake_head")
                            {// 頭の向き取得
                                if (0 == (int)parentgameObject.GetComponent<BusnakeMoveAnim>().GetOldDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                                }
                                else if (1 == (int)parentgameObject.GetComponent<BusnakeMoveAnim>().GetOldDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                }
                                else
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[1];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                }
                            }
                            else
                            {
                                if (0 == (int)parentgameObject.GetComponent<BusnakeAnim>().OldDirection)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                                }
                                else if (1 == (int)parentgameObject.GetComponent<BusnakeAnim>().OldDirection)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                }
                                else
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[1];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                }

                            }
                        }
                        break;
                    // 下
                    case 3:
                        // 画像がStraightだったら
                        if (GetComponent<Image>().sprite.name == PlayerTexNumber[1].name)
                        {
                            // 体の先頭を分ける
                            if (parentgameObject.name == "Busnake_head")
                            {// 頭の向き取得
                                if (3 == (int)parentgameObject.GetComponent<BusnakeMoveAnim>().GetOldDirection())
                                {
                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                                }
                                else if (0 == (int)parentgameObject.GetComponent<BusnakeMoveAnim>().GetOldDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                                }
                                else if (1 == (int)parentgameObject.GetComponent<BusnakeMoveAnim>().GetOldDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                                else
                                {
                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                                }
                            }
                            else
                            {
                                if (3 == (int)parentgameObject.GetComponent<BusnakeAnim>().OldDirection)
                                {
                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                                }
                                else if (0 == (int)parentgameObject.GetComponent<BusnakeAnim>().OldDirection)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                                }
                                else if (1 == (int)parentgameObject.GetComponent<BusnakeAnim>().OldDirection)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                                else
                                {
                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                                }

                            }
                        }
                        else
                        {
                            // 体の先頭を分ける
                            if (parentgameObject.name == "Busnake_head")
                            {// 頭の向き取得
                                if (0 == (int)parentgameObject.GetComponent<BusnakeMoveAnim>().GetOldDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                                }
                                else if (1 == (int)parentgameObject.GetComponent<BusnakeMoveAnim>().GetOldDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                                else
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[1];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                                }
                            }
                            else
                            {
                                if (0 == (int)parentgameObject.GetComponent<BusnakeAnim>().OldDirection)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                                }
                                else if (1 == (int)parentgameObject.GetComponent<BusnakeAnim>().OldDirection)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                                else
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[1];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                                }

                            }
                        }
                        break;
                }

            }

            // 値を足す
            lerpValue += 0.05f;

            // 線形補間
            recttransform.position = Vector3.Lerp(q1, q2, lerpValue);

        }
        else
        {
            bTrigger = false;
            lerpValue = 0.0f;
        }

    }
}
