using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    [SerializeField]
    GameObject light_Stage0;
    [SerializeField]
    GameObject light_Stage1;
    [SerializeField]
    GameObject light_Stage2;
    [SerializeField]
    GameObject light_Stage3;
    [SerializeField]
    GameObject light_Title;
    [SerializeField]
    GameObject Board_Stage0;
    [SerializeField]
    GameObject Board_Stage1;
    [SerializeField]
    GameObject Board_Stage2;
    [SerializeField]
    GameObject Board_Stage3;
    [SerializeField]
    GameObject Board_Title;
    [SerializeField]
    GameObject Arrowright;
    [SerializeField]
    GameObject Arrowleft;
    [SerializeField]
    Sprite lightonimage;
    [SerializeField]
    Sprite lightoffimage;
    [SerializeField]
    Sprite Boardonimage;
    [SerializeField]
    Sprite Boardoffimage;
    [SerializeField]
    Text Stage_1text;
    [SerializeField]
    Text Stage_2text;
    [SerializeField]
    Text Stage_3text;
    [SerializeField]
    Text Stage_4text;
    public int lightposnow;//0~3→stage1~4 4=タイトルに戻る
    float scale;
    bool bscale;
    public int Worldnow;
    public int Stagenow;

    [SerializeField]
    Fade Fade;

    public bool bScenechange;//true=Scenechange中


    public int[] star = new int[17];

    [SerializeField]
    GameObject[] star_Stage = new GameObject[12];


    [SerializeField]
    Sprite staronimage;
    [SerializeField]
    Sprite staroffimage;

    // Start is called before the first frame update
    void Start()
    {
        lightposnow = 0;
        Worldnow = 1;
        Stagenow = 1;
        Arrowleft.SetActive(false);
        bScenechange = false;

        //セーブデータをロード
        for (int i = 1; i <= 16; i++)
        {
            star[i] = PlayerPrefs.GetInt(i.ToString(), 0);
        }


    }

    // Update is called once per frame
    void Update()
    {
        //Mouseclick,EnterKey,SpacekeyでStageSelect→Gamemainにシーン遷移
        //PCの入力モードが半角になっていないとSpaceKeyが反応しない
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space))
        {
            Fade.SetFade();

            bScenechange = true;
        }

        //ロードした星データを反映
        //Worldnow1
        if (Worldnow == 1)
        {
            if (star[1] == 0)
            {
                star_Stage[0].GetComponent<Image>().sprite = staroffimage;
                star_Stage[1].GetComponent<Image>().sprite = staroffimage;
                star_Stage[2].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[1] == 1)
            {
                star_Stage[0].GetComponent<Image>().sprite = staronimage;
                star_Stage[1].GetComponent<Image>().sprite = staroffimage;
                star_Stage[2].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[1] == 2)
            {
                star_Stage[0].GetComponent<Image>().sprite = staronimage;
                star_Stage[1].GetComponent<Image>().sprite = staronimage;
                star_Stage[2].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[1] == 3)
            {
                star_Stage[0].GetComponent<Image>().sprite = staronimage;
                star_Stage[1].GetComponent<Image>().sprite = staronimage;
                star_Stage[2].GetComponent<Image>().sprite = staronimage;
            }

            if (star[2] == 0)
            {
                star_Stage[3].GetComponent<Image>().sprite = staroffimage;
                star_Stage[4].GetComponent<Image>().sprite = staroffimage;
                star_Stage[5].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[2] == 1)
            {
                star_Stage[3].GetComponent<Image>().sprite = staronimage;
                star_Stage[4].GetComponent<Image>().sprite = staroffimage;
                star_Stage[5].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[2] == 2)
            {
                star_Stage[3].GetComponent<Image>().sprite = staronimage;
                star_Stage[4].GetComponent<Image>().sprite = staronimage;
                star_Stage[5].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[2] == 3)
            {
                star_Stage[3].GetComponent<Image>().sprite = staronimage;
                star_Stage[4].GetComponent<Image>().sprite = staronimage;
                star_Stage[5].GetComponent<Image>().sprite = staronimage;
            }

            if (star[3] == 0)
            {
                star_Stage[6].GetComponent<Image>().sprite = staroffimage;
                star_Stage[7].GetComponent<Image>().sprite = staroffimage;
                star_Stage[8].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[3] == 1)
            {
                star_Stage[6].GetComponent<Image>().sprite = staronimage;
                star_Stage[7].GetComponent<Image>().sprite = staroffimage;
                star_Stage[8].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[3] == 2)
            {
                star_Stage[6].GetComponent<Image>().sprite = staronimage;
                star_Stage[7].GetComponent<Image>().sprite = staronimage;
                star_Stage[8].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[3] == 3)
            {
                star_Stage[6].GetComponent<Image>().sprite = staronimage;
                star_Stage[7].GetComponent<Image>().sprite = staronimage;
                star_Stage[8].GetComponent<Image>().sprite = staronimage;
            }

            if (star[4] == 0)
            {
                star_Stage[9].GetComponent<Image>().sprite = staroffimage;
                star_Stage[10].GetComponent<Image>().sprite = staroffimage;
                star_Stage[11].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[4] == 1)
            {
                star_Stage[9].GetComponent<Image>().sprite = staronimage;
                star_Stage[10].GetComponent<Image>().sprite = staroffimage;
                star_Stage[11].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[4] == 2)
            {
                star_Stage[9].GetComponent<Image>().sprite = staronimage;
                star_Stage[10].GetComponent<Image>().sprite = staronimage;
                star_Stage[11].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[4] == 3)
            {
                star_Stage[9].GetComponent<Image>().sprite = staronimage;
                star_Stage[10].GetComponent<Image>().sprite = staronimage;
                star_Stage[11].GetComponent<Image>().sprite = staronimage;
            }
        }

        //Worldnow2
        else if (Worldnow == 2)
        {
            if (star[5] == 0)
            {
                star_Stage[0].GetComponent<Image>().sprite = staroffimage;
                star_Stage[1].GetComponent<Image>().sprite = staroffimage;
                star_Stage[2].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[5] == 1)
            {
                star_Stage[0].GetComponent<Image>().sprite = staronimage;
                star_Stage[1].GetComponent<Image>().sprite = staroffimage;
                star_Stage[2].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[5] == 2)
            {
                star_Stage[0].GetComponent<Image>().sprite = staronimage;
                star_Stage[1].GetComponent<Image>().sprite = staronimage;
                star_Stage[2].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[5] == 3)
            {
                star_Stage[0].GetComponent<Image>().sprite = staronimage;
                star_Stage[1].GetComponent<Image>().sprite = staronimage;
                star_Stage[2].GetComponent<Image>().sprite = staronimage;
            }

            if (star[6] == 0)
            {
                star_Stage[3].GetComponent<Image>().sprite = staroffimage;
                star_Stage[4].GetComponent<Image>().sprite = staroffimage;
                star_Stage[5].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[6] == 1)
            {
                star_Stage[3].GetComponent<Image>().sprite = staronimage;
                star_Stage[4].GetComponent<Image>().sprite = staroffimage;
                star_Stage[5].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[6] == 2)
            {
                star_Stage[3].GetComponent<Image>().sprite = staronimage;
                star_Stage[4].GetComponent<Image>().sprite = staronimage;
                star_Stage[5].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[6] == 3)
            {
                star_Stage[3].GetComponent<Image>().sprite = staronimage;
                star_Stage[4].GetComponent<Image>().sprite = staronimage;
                star_Stage[5].GetComponent<Image>().sprite = staronimage;
            }

            if (star[7] == 0)
            {
                star_Stage[6].GetComponent<Image>().sprite = staroffimage;
                star_Stage[7].GetComponent<Image>().sprite = staroffimage;
                star_Stage[8].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[7] == 1)
            {
                star_Stage[6].GetComponent<Image>().sprite = staronimage;
                star_Stage[7].GetComponent<Image>().sprite = staroffimage;
                star_Stage[8].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[7] == 2)
            {
                star_Stage[6].GetComponent<Image>().sprite = staronimage;
                star_Stage[7].GetComponent<Image>().sprite = staronimage;
                star_Stage[8].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[7] == 3)
            {
                star_Stage[6].GetComponent<Image>().sprite = staronimage;
                star_Stage[7].GetComponent<Image>().sprite = staronimage;
                star_Stage[8].GetComponent<Image>().sprite = staronimage;
            }

            if (star[8] == 0)
            {
                star_Stage[9].GetComponent<Image>().sprite = staroffimage;
                star_Stage[10].GetComponent<Image>().sprite = staroffimage;
                star_Stage[11].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[8] == 1)
            {
                star_Stage[9].GetComponent<Image>().sprite = staronimage;
                star_Stage[10].GetComponent<Image>().sprite = staroffimage;
                star_Stage[11].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[8] == 2)
            {
                star_Stage[9].GetComponent<Image>().sprite = staronimage;
                star_Stage[10].GetComponent<Image>().sprite = staronimage;
                star_Stage[11].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[8] == 3)
            {
                star_Stage[9].GetComponent<Image>().sprite = staronimage;
                star_Stage[10].GetComponent<Image>().sprite = staronimage;
                star_Stage[11].GetComponent<Image>().sprite = staronimage;
            }
        }
        //Worldnow3
        else if (Worldnow == 3)
        {
            if (star[9] == 0)
            {
                star_Stage[0].GetComponent<Image>().sprite = staroffimage;
                star_Stage[1].GetComponent<Image>().sprite = staroffimage;
                star_Stage[2].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[9] == 1)
            {
                star_Stage[0].GetComponent<Image>().sprite = staronimage;
                star_Stage[1].GetComponent<Image>().sprite = staroffimage;
                star_Stage[2].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[9] == 2)
            {
                star_Stage[0].GetComponent<Image>().sprite = staronimage;
                star_Stage[1].GetComponent<Image>().sprite = staronimage;
                star_Stage[2].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[9] == 3)
            {
                star_Stage[0].GetComponent<Image>().sprite = staronimage;
                star_Stage[1].GetComponent<Image>().sprite = staronimage;
                star_Stage[2].GetComponent<Image>().sprite = staronimage;
            }

            if (star[10] == 0)
            {
                star_Stage[3].GetComponent<Image>().sprite = staroffimage;
                star_Stage[4].GetComponent<Image>().sprite = staroffimage;
                star_Stage[5].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[10] == 1)
            {
                star_Stage[3].GetComponent<Image>().sprite = staronimage;
                star_Stage[4].GetComponent<Image>().sprite = staroffimage;
                star_Stage[5].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[10] == 2)
            {
                star_Stage[3].GetComponent<Image>().sprite = staronimage;
                star_Stage[4].GetComponent<Image>().sprite = staronimage;
                star_Stage[5].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[10] == 3)
            {
                star_Stage[3].GetComponent<Image>().sprite = staronimage;
                star_Stage[4].GetComponent<Image>().sprite = staronimage;
                star_Stage[5].GetComponent<Image>().sprite = staronimage;
            }

            if (star[11] == 0)
            {
                star_Stage[6].GetComponent<Image>().sprite = staroffimage;
                star_Stage[7].GetComponent<Image>().sprite = staroffimage;
                star_Stage[8].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[11] == 1)
            {
                star_Stage[6].GetComponent<Image>().sprite = staronimage;
                star_Stage[7].GetComponent<Image>().sprite = staroffimage;
                star_Stage[8].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[11] == 2)
            {
                star_Stage[6].GetComponent<Image>().sprite = staronimage;
                star_Stage[7].GetComponent<Image>().sprite = staronimage;
                star_Stage[8].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[11] == 3)
            {
                star_Stage[6].GetComponent<Image>().sprite = staronimage;
                star_Stage[7].GetComponent<Image>().sprite = staronimage;
                star_Stage[8].GetComponent<Image>().sprite = staronimage;
            }

            if (star[12] == 0)
            {
                star_Stage[9].GetComponent<Image>().sprite = staroffimage;
                star_Stage[10].GetComponent<Image>().sprite = staroffimage;
                star_Stage[11].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[12] == 1)
            {
                star_Stage[9].GetComponent<Image>().sprite = staronimage;
                star_Stage[10].GetComponent<Image>().sprite = staroffimage;
                star_Stage[11].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[12] == 2)
            {
                star_Stage[9].GetComponent<Image>().sprite = staronimage;
                star_Stage[10].GetComponent<Image>().sprite = staronimage;
                star_Stage[11].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[12] == 3)
            {
                star_Stage[9].GetComponent<Image>().sprite = staronimage;
                star_Stage[10].GetComponent<Image>().sprite = staronimage;
                star_Stage[11].GetComponent<Image>().sprite = staronimage;
            }
        }
        //Worldnow4
        else if (Worldnow == 4)
        {
            if (star[13] == 0)
            {
                star_Stage[0].GetComponent<Image>().sprite = staroffimage;
                star_Stage[1].GetComponent<Image>().sprite = staroffimage;
                star_Stage[2].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[13] == 1)
            {
                star_Stage[0].GetComponent<Image>().sprite = staronimage;
                star_Stage[1].GetComponent<Image>().sprite = staroffimage;
                star_Stage[2].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[13] == 2)
            {
                star_Stage[0].GetComponent<Image>().sprite = staronimage;
                star_Stage[1].GetComponent<Image>().sprite = staronimage;
                star_Stage[2].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[13] == 3)
            {
                star_Stage[0].GetComponent<Image>().sprite = staronimage;
                star_Stage[1].GetComponent<Image>().sprite = staronimage;
                star_Stage[2].GetComponent<Image>().sprite = staronimage;
            }

            if (star[14] == 0)
            {
                star_Stage[3].GetComponent<Image>().sprite = staroffimage;
                star_Stage[4].GetComponent<Image>().sprite = staroffimage;
                star_Stage[5].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[14] == 1)
            {
                star_Stage[3].GetComponent<Image>().sprite = staronimage;
                star_Stage[4].GetComponent<Image>().sprite = staroffimage;
                star_Stage[5].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[14] == 2)
            {
                star_Stage[3].GetComponent<Image>().sprite = staronimage;
                star_Stage[4].GetComponent<Image>().sprite = staronimage;
                star_Stage[5].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[14] == 3)
            {
                star_Stage[3].GetComponent<Image>().sprite = staronimage;
                star_Stage[4].GetComponent<Image>().sprite = staronimage;
                star_Stage[5].GetComponent<Image>().sprite = staronimage;
            }

            if (star[15] == 0)
            {
                star_Stage[6].GetComponent<Image>().sprite = staroffimage;
                star_Stage[7].GetComponent<Image>().sprite = staroffimage;
                star_Stage[8].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[15] == 1)
            {
                star_Stage[6].GetComponent<Image>().sprite = staronimage;
                star_Stage[7].GetComponent<Image>().sprite = staroffimage;
                star_Stage[8].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[15] == 2)
            {
                star_Stage[6].GetComponent<Image>().sprite = staronimage;
                star_Stage[7].GetComponent<Image>().sprite = staronimage;
                star_Stage[8].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[15] == 3)
            {
                star_Stage[6].GetComponent<Image>().sprite = staronimage;
                star_Stage[7].GetComponent<Image>().sprite = staronimage;
                star_Stage[8].GetComponent<Image>().sprite = staronimage;
            }

            if (star[16] == 0)
            {
                star_Stage[9].GetComponent<Image>().sprite = staroffimage;
                star_Stage[10].GetComponent<Image>().sprite = staroffimage;
                star_Stage[11].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[16] == 1)
            {
                star_Stage[9].GetComponent<Image>().sprite = staronimage;
                star_Stage[10].GetComponent<Image>().sprite = staroffimage;
                star_Stage[11].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[16] == 2)
            {
                star_Stage[9].GetComponent<Image>().sprite = staronimage;
                star_Stage[10].GetComponent<Image>().sprite = staronimage;
                star_Stage[11].GetComponent<Image>().sprite = staroffimage;
            }
            else if (star[16] == 3)
            {
                star_Stage[9].GetComponent<Image>().sprite = staronimage;
                star_Stage[10].GetComponent<Image>().sprite = staronimage;
                star_Stage[11].GetComponent<Image>().sprite = staronimage;
            }
        }

        //シーンchange
        if (Fade.m_bChage)
        {
            if (Worldnow == 1)
            {
                if (Stagenow == 1)
                    SceneManager.LoadScene("1");
                if (Stagenow == 2)
                    SceneManager.LoadScene("2");
                if (Stagenow == 3)
                    SceneManager.LoadScene("3");
                if (Stagenow == 4)
                    SceneManager.LoadScene("4");
            }

            if (Worldnow == 2)
            {
                if (Stagenow == 1)
                    SceneManager.LoadScene("5");
                if (Stagenow == 2)
                    SceneManager.LoadScene("6");
                if (Stagenow == 3)
                    SceneManager.LoadScene("7");
                if (Stagenow == 4)
                    SceneManager.LoadScene("8");
            }

            if (Worldnow == 3)
            {
                if (Stagenow == 1)
                    SceneManager.LoadScene("9");
                if (Stagenow == 2)
                    SceneManager.LoadScene("10");
                if (Stagenow == 3)
                    SceneManager.LoadScene("11");
                if (Stagenow == 4)
                    SceneManager.LoadScene("12");
            }

            if (Worldnow == 4)
            {
                if (Stagenow == 1)
                    SceneManager.LoadScene("13");
                if (Stagenow == 2)
                    SceneManager.LoadScene("14");
                if (Stagenow == 3)
                    SceneManager.LoadScene("15");
                if (Stagenow == 4)
                    SceneManager.LoadScene("16");
            }

        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && lightposnow != 0 && bScenechange == false)
        {
            lightposnow -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && lightposnow != 4 && bScenechange == false)
        {
            lightposnow += 1;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && Worldnow != 1 && bScenechange == false)
        {
            Worldnow -= 1;
            if (Worldnow == 1)
            {
                Arrowleft.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && Worldnow != 4 && bScenechange == false)
        {
            Worldnow += 1;
            Arrowleft.SetActive(true);
        }
        //Stagetext関係
        Stage_1text.text = Worldnow.ToString() + " ー 1";
        Stage_2text.text = Worldnow.ToString() + " ー 2";
        Stage_3text.text = Worldnow.ToString() + " ー 3";
        Stage_4text.text = Worldnow.ToString() + " ー 4";

        switch (lightposnow)
        {
            case 0:
                light_Stage0.GetComponent<Image>().sprite = lightonimage;
                light_Stage1.GetComponent<Image>().sprite = lightoffimage;

                Board_Stage0.GetComponent<Image>().sprite = Boardonimage;
                Board_Stage1.GetComponent<Image>().sprite = Boardoffimage;
                Stagenow = 1;
                break;
            case 1:
                light_Stage1.GetComponent<Image>().sprite = lightonimage;
                light_Stage0.GetComponent<Image>().sprite = lightoffimage;
                light_Stage2.GetComponent<Image>().sprite = lightoffimage;

                Board_Stage1.GetComponent<Image>().sprite = Boardonimage;
                Board_Stage0.GetComponent<Image>().sprite = Boardoffimage;
                Board_Stage2.GetComponent<Image>().sprite = Boardoffimage;
                Stagenow = 2;
                break;
            case 2:
                light_Stage2.GetComponent<Image>().sprite = lightonimage;
                light_Stage1.GetComponent<Image>().sprite = lightoffimage;
                light_Stage3.GetComponent<Image>().sprite = lightoffimage;

                Board_Stage2.GetComponent<Image>().sprite = Boardonimage;
                Board_Stage1.GetComponent<Image>().sprite = Boardoffimage;
                Board_Stage3.GetComponent<Image>().sprite = Boardoffimage;
                Stagenow = 3;
                break;
            case 3:
                light_Stage3.GetComponent<Image>().sprite = lightonimage;
                light_Stage2.GetComponent<Image>().sprite = lightoffimage;
                light_Title.GetComponent<Image>().sprite = lightoffimage;

                Board_Stage3.GetComponent<Image>().sprite = Boardonimage;
                Board_Stage2.GetComponent<Image>().sprite = Boardoffimage;
                Board_Title.GetComponent<Image>().sprite = Boardoffimage;
                Stagenow = 4;
                break;
            case 4:
                light_Title.GetComponent<Image>().sprite = lightonimage;
                light_Stage3.GetComponent<Image>().sprite = lightoffimage;

                Board_Title.GetComponent<Image>().sprite = Boardonimage;
                Board_Stage3.GetComponent<Image>().sprite = Boardoffimage;

                if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space))
                {
                    Fade.SetFade();

                    bScenechange = true;
                }
                if (Fade.m_bChage)
                {
                    SceneManager.LoadScene("Title");

                }
                Stagenow = 0;
                break;
        }

        if (scale <= 0.0f)
        {
            bscale = true;
        }
        if (scale >= 0.2f)
        {
            bscale = false;
        }
        if (bscale == true)
        {
            scale += 0.003f;
        }
        else if (bscale == false)
        {
            scale -= 0.003f;
        }

        Arrowright.transform.localScale = new Vector3(0.7f + scale, 0.7f + scale, 1);
        Arrowleft.transform.localScale = new Vector3(0.7f + scale, 0.7f + scale, 1);
    }
}
