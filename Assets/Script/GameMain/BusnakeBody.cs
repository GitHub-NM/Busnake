using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusnakeBody : MonoBehaviour
{
    // メンバ変数定義
    public BusnakeBody childgameObject;
    public GameObject parentgameObject;
    public BusnakeHead BusnakeHead;
    public Sprite[] PlayerTexNumber;
    public Vector3 SavePos;
    public float lerpValueplus;
    public int Direction;
    public int OldDirection;

    private Vector3 recttransform;
    private float lerpValue;
    private bool bTrigger;
    private bool bTriggerleap;

    // クォータニオンの準備
    private Vector3 q1;
    private Vector3 q2;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        SavePos = GetComponent<RectTransform>().localPosition;
        bTrigger = false;
        bTriggerleap = false;
        lerpValue = 0.0f;
        lerpValueplus = 1.0f;
        childgameObject.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // ポジション宣言
        recttransform = GetComponent<RectTransform>().localPosition;

        // 頭が移動したら
        if (!bTriggerleap && BusnakeHead.bTrigger)
        {
            bTriggerleap = true;
        }

        // 補完が終わるまで継続
        if (bTriggerleap)
        {
            // 値が1.0f以上になったらやめる
            if (lerpValue >= 1.0f)
            {
                // 正規化
                lerpValue = 1.0f;
                recttransform = Vector3.Lerp(q1, q2, lerpValue);
                GetComponent<RectTransform>().localPosition = recttransform;

                SavePos = GetComponent<RectTransform>().localPosition;

                lerpValue = 0.0f;
                bTriggerleap = false;
            }

            if (!bTrigger)
            {
                bTrigger = true;

                // 体の先頭を分ける
                if (parentgameObject.name == "Busnake_head")
                {// 頭の向き取得
                    q1 = new Vector3(recttransform.x, recttransform.y, recttransform.z);
                    q2 = new Vector3(parentgameObject.GetComponent<BusnakeHead>().recttransform.x, parentgameObject.GetComponent<BusnakeHead>().recttransform.y, parentgameObject.GetComponent<BusnakeHead>().recttransform.z);

                    OldDirection = Direction;
                    Direction = (int)parentgameObject.GetComponent<BusnakeHead>().GetOldDirection();

                }
                else
                {// 親のオブジェクトの向きを取得
                    q1 = new Vector3(recttransform.x, recttransform.y, recttransform.z);
                    q2 = new Vector3(parentgameObject.GetComponent<BusnakeBody>().SavePos.x, parentgameObject.GetComponent<BusnakeBody>().SavePos.y, parentgameObject.GetComponent<BusnakeBody>().SavePos.z);

                    SavePos = GetComponent<RectTransform>().localPosition;

                    OldDirection = Direction;
                    Direction = parentgameObject.GetComponent<BusnakeBody>().OldDirection;

                }


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
                                if (2 == (int)parentgameObject.GetComponent<BusnakeHead>().GetDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                                }
                                else if (3 == (int)parentgameObject.GetComponent<BusnakeHead>().GetDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                                }
                                else
                                {
                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                            }
                            else
                            {
                                if (2 == (int)parentgameObject.GetComponent<BusnakeBody>().Direction)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                                }
                                else if (3 == (int)parentgameObject.GetComponent<BusnakeBody>().Direction)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -90f);
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
                                if (2 == (int)parentgameObject.GetComponent<BusnakeHead>().GetDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                                }
                                else if (3 == (int)parentgameObject.GetComponent<BusnakeHead>().GetDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -90f);
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
                                if (2 == (int)parentgameObject.GetComponent<BusnakeBody>().Direction)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                                }
                                else if (3 == (int)parentgameObject.GetComponent<BusnakeBody>().Direction)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -90f);
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
                                if (2 == (int)parentgameObject.GetComponent<BusnakeHead>().GetDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                }
                                else if (3 == (int)parentgameObject.GetComponent<BusnakeHead>().GetDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                                else
                                {
                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                            }
                            else
                            {
                                if (2 == (int)parentgameObject.GetComponent<BusnakeBody>().Direction)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                }
                                else if (3 == (int)parentgameObject.GetComponent<BusnakeBody>().Direction)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
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
                                if (2 == (int)parentgameObject.GetComponent<BusnakeHead>().GetDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                }
                                else if (3 == (int)parentgameObject.GetComponent<BusnakeHead>().GetDirection())
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
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                            }
                            else
                            {
                                if (2 == (int)parentgameObject.GetComponent<BusnakeBody>().Direction)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                }
                                else if (3 == (int)parentgameObject.GetComponent<BusnakeBody>().Direction)
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
                                if (0 == (int)parentgameObject.GetComponent<BusnakeHead>().GetDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                                else if (1 == (int)parentgameObject.GetComponent<BusnakeHead>().GetDirection())
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
                                if (0 == (int)parentgameObject.GetComponent<BusnakeBody>().Direction)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                                else if (1 == (int)parentgameObject.GetComponent<BusnakeBody>().Direction)
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
                        }
                        else
                        {
                            // 体の先頭を分ける
                            if (parentgameObject.name == "Busnake_head")
                            {// 頭の向き取得
                                if (0 == (int)parentgameObject.GetComponent<BusnakeHead>().GetDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                                else if (1 == (int)parentgameObject.GetComponent<BusnakeHead>().GetDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -90f);
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
                                if (0 == (int)parentgameObject.GetComponent<BusnakeBody>().Direction)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                }
                                else if (1 == (int)parentgameObject.GetComponent<BusnakeBody>().Direction)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -90f);
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
                                if (0 == (int)parentgameObject.GetComponent<BusnakeHead>().GetDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                }
                                else if (1 == (int)parentgameObject.GetComponent<BusnakeHead>().GetDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -180f);
                                }
                                else
                                {
                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                }
                            }
                            else
                            {
                                if (0 == (int)parentgameObject.GetComponent<BusnakeBody>().Direction)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                }
                                else if (1 == (int)parentgameObject.GetComponent<BusnakeBody>().Direction)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -180f);
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
                                if (0 == (int)parentgameObject.GetComponent<BusnakeHead>().GetDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                }
                                else if (1 == (int)parentgameObject.GetComponent<BusnakeHead>().GetDirection())
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -180f);
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
                                if (0 == (int)parentgameObject.GetComponent<BusnakeBody>().Direction)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                                }
                                else if (1 == (int)parentgameObject.GetComponent<BusnakeBody>().Direction)
                                {
                                    // 変更をかける
                                    GetComponent<Image>().sprite = PlayerTexNumber[2];

                                    // 向きを変える
                                    transform.rotation = Quaternion.Euler(0f, 0f, -180f);
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
                }

            }

            // 値を足す
            lerpValue += lerpValueplus;

            // 線形補間
            recttransform = Vector3.Lerp(q1, q2, lerpValue);
            GetComponent<RectTransform>().localPosition = recttransform;
        }
        else
        {
            bTrigger = false;
            lerpValue = 0.0f;
        }

    }
}
