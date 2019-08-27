using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Fade : MonoBehaviour
{
    public float alfa;
    public float speed = 0.01f;  //透明化の速さ
    float red, green, blue;
    public FADE fade;                    
    public bool m_bChage = false;		// フェード状態

    public enum FADE{
        FADE_NONE=0,
        FADE_IN,
        FADE_OUT,
    };

    // Start is called before the first frame update
    void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        fade = FADE.FADE_IN;
    }

    // Update is called once per frame
    void Update()
    {
        if (fade != FADE.FADE_NONE)
        {// フェード処理中
            if (FADE.FADE_OUT == fade)
            {
                // フェードアウト処理
                alfa += speed; // α値を加算して画面を消していく

                if (alfa >= 1.0f)
                {
                    // フェードアウト終了
                    alfa = 1.0f;
                    m_bChage = true;
                }

                // テクスチャ更新
                GetComponent<Image>().color = new Color(red, green, blue, alfa);
            }
            else if (FADE.FADE_IN == fade)
            {
                // フェードイン処理
                alfa -= speed; // α値を加算して画面を浮き上がらせていく

                if (alfa <= 0.0f)
                {
                    // フェード処理終了
                    alfa = 0.0f;
                    fade = FADE.FADE_NONE;
                    m_bChage = false;   // 終わり
                }
            }
            // テクスチャ更新
            GetComponent<Image>().color = new Color(red, green, blue, alfa);

        }

    }

    // フェード開始
    public void SetFade()
    {
       fade = FADE.FADE_OUT;
    }
}
