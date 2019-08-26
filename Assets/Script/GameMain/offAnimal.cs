using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class offAnimal : MonoBehaviour
{
    // メンバ宣言
    public Sprite[] Animals;
    public Sprite[] Sprite;

    public bool missarrival;

    private int nSpriteNum;
    private SpriteChange SpriteChange;

    float time;
    int i;

    void Start()
    {
        // 初期化
        GetComponent<Image>().enabled = false;
        nSpriteNum = GetComponentInParent<SpriteChange>().nSpriteNum;

        missarrival = false;
        time = 0.0f;
        i = 0;

        // 動物を確定する
        switch (nSpriteNum)
        {
            case 0:
                GetComponent<Image>().sprite = Animals[0];
                break;
            case 1:
                GetComponent<Image>().sprite = Animals[1];
                break;
            case 2:
                GetComponent<Image>().sprite = Animals[2];
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // 間違えたフラグがたったら
        if(missarrival)
        {
            // タイム加算
            time++;

            if (time > 10.0f)
            {
                // スプライト総数が一緒になったら
                if (i == Sprite.Length)
                {
                    // 見えなくしておく
                    GetComponent<Image>().enabled = false;

                    // 動物を再確定する
                    switch (nSpriteNum)
                    {
                        case 0:
                            GetComponent<Image>().sprite = Animals[0];
                            break;
                        case 1:
                            GetComponent<Image>().sprite = Animals[1];
                            break;
                        case 2:
                            GetComponent<Image>().sprite = Animals[2];
                            break;
                    }

                    // フラグを下げる
                    missarrival = false;
                    i = 0;
                    time = 0.0f;
                }
                else
                {
                    i++;

                    // スプライト変更
                    GetComponent<Image>().sprite = Sprite[i];
                    GetComponent<Image>().enabled = true;
                    time = 0.0f;
                }
            }


        }
    }
}
