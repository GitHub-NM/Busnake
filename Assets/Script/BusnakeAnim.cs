using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusnakeAnim : MonoBehaviour
{
    // メンバ変数定義
    public GameObject gameObjects;
    private RectTransform recttransform;
    public BusnakeMoveAnim BusnakeMoveAnim;
    private float lerpValue;
    private bool bTrigger;

    // クォータニオンの準備
    private Vector3 q1;
    private Vector3 q2;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        bTrigger = false;
        lerpValue = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // ポジション宣言
        recttransform = GetComponent<RectTransform>();

        // 頭が移動したら
        if (BusnakeMoveAnim.bTrigger)
        {
            if (!bTrigger)
            {
                q1 = new Vector3(recttransform.position.x, recttransform.position.y, recttransform.position.z);
                q2 = new Vector3(gameObjects.GetComponent<RectTransform>().position.x, gameObjects.GetComponent<RectTransform>().position.y, gameObjects.GetComponent<RectTransform>().position.z);
                lerpValue += 0.05f;
                bTrigger = true;
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
