using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GC_main : MonoBehaviour
{
    [SerializeField]
    SignManager SignManager;
    [SerializeField]
    GameObject GCTextObj;//ゲームクリア！のtextimageObj
    [SerializeField]
    GameObject GCBoardObj;
    [SerializeField]
    GameObject GClightObj;
    [SerializeField]
    GameObject Score_oneObj;
    [SerializeField]
    GameObject Score_tenObj;
    [SerializeField]
    GameObject Score_hundredObj;
    [SerializeField]
    GameObject pata_oneObj;
    [SerializeField]
    GameObject pata_tenObj;
    [SerializeField]
    GameObject pata_hundredObj;
    [SerializeField]
    GameObject star_0Obj;
    [SerializeField]
    GameObject star_1Obj;
    [SerializeField]
    GameObject star_2Obj;
    [SerializeField]
    GameObject pata_star_0Obj;
    [SerializeField]
    GameObject pata_star_1Obj;
    [SerializeField]
    GameObject pata_star_2Obj;

    [SerializeField]
    GameObject FadePataanim_Next;
    [SerializeField]
    GameObject FadePataanim_Retry;
    [SerializeField]
    GameObject FadePataanim_Title;

    [SerializeField]
    Vector3 GClightnextpos;
    [SerializeField]
    Vector3 GClightretrypos;
    [SerializeField]
    Vector3 GClighttitlepos;

    [SerializeField]
    Sprite[] ScoreSprites;
    [SerializeField]
    Sprite[] starSprites;


    int Scorenum;
    int Starnum;

    Vector3 initTextscal;
    Vector3 endTextscal;
    Vector3 initBoardpos;
    Vector3 endBoardpos;

    float timeStepText;
    float timeStepBoard;
    [SerializeField]
    float timeTextpop;
    [SerializeField]
    float timeBoardpop;
    //画面サイズ取得用
    //float Screenwidth;
    float Screenheight;
    //現在のScene取得(リトライ用)
    string nowSceneName;
    int Order;
    float scoretimer;
    float startimer;
    // enum型の定義
    [SerializeField]
    Fade Fade;

    public string NextSceneName;

    public bool bScenechange;//true=Scenechange中

    [SerializeField]
    BusnakeHead BusnakeHead;

    public float star3Time;
    public float star2Time;
    public int[] star = new int[17];
    int Stagestarnum;

    public enum lightpos
    {
        next,
        retry,
        title
    };
    lightpos lightposnow;
    // Start is called before the first frame update
    void Start()
    {
        initTextscal = new Vector3(0.2f, 0.2f, 0.2f);
        endTextscal = new Vector3(1.0f, 1.0f, 1.0f);
        timeStepText = 0.0f;
        lightposnow = lightpos.next;
        //Screenwidth = Screen.width;
        Screenheight = Screen.height;
        initBoardpos = new Vector3(0, ((-Screenheight) - (GCBoardObj.GetComponent<RectTransform>().sizeDelta.x / 2) - 25), 0);

        endBoardpos = new Vector3(0, 0, 0);
        timeStepBoard = 0.0f;

        GCTextObj.transform.localScale = initTextscal;
        GCTextObj.SetActive(false);
        GCBoardObj.transform.localPosition = initBoardpos;
        scoretimer = 0.0f;
        startimer = 0.0f;
        star_0Obj.GetComponent<Image>().sprite = starSprites[0];
        star_1Obj.GetComponent<Image>().sprite = starSprites[0];
        star_2Obj.GetComponent<Image>().sprite = starSprites[0];
        star_0Obj.SetActive(false);
        star_1Obj.SetActive(false);
        star_2Obj.SetActive(false);
        Score_oneObj.SetActive(false);
        Score_tenObj.SetActive(false);
        Score_hundredObj.SetActive(false);
        nowSceneName = SceneManager.GetActiveScene().name;


        FadePataanim_Next.SetActive(false);
        FadePataanim_Retry.SetActive(false);
        FadePataanim_Title.SetActive(false);

        bScenechange = false;
        Scorenum = 0;
        Stagestarnum = int.Parse(nowSceneName);

        star[Stagestarnum] = PlayerPrefs.GetInt(nowSceneName, 0);
    }

    // Update is called once per frame
    void Update()
    {
        switch (Order)
        {

            case 0:

                if (SignManager.goal)
                {
                    Order = 1;
                }

                Scorenum = BusnakeHead.nMoveCnt;
                if (Scorenum <= star3Time)
                {
                    Starnum = 3;
                }
                if (Scorenum > star3Time && Scorenum <= star2Time)
                {
                    Starnum = 2;
                }
                if (Scorenum > star2Time)
                {
                    Starnum = 1;
                }


                break;
            case 1://Text(ゲームクリア)のpop
                GCTextObj.SetActive(true);
                GCTextObj.transform.localScale = Vector3.Lerp(initTextscal, endTextscal, timeStepText);
                timeStepText += Time.deltaTime / timeTextpop;
                if (timeStepText >= 1)
                {
                    Order = 2;
                }

                if (star[Stagestarnum] < Starnum)
                {
                    star[Stagestarnum] = Starnum;
                    PlayerPrefs.SetInt(nowSceneName, star[Stagestarnum]);
                    PlayerPrefs.Save();
                }
                break;

            case 2://Boardのpop

                GCBoardObj.transform.localPosition = Vector3.Lerp(initBoardpos, endBoardpos, timeStepBoard);
                timeStepBoard += Time.deltaTime / timeBoardpop;
                if (timeStepBoard >= 1)
                {
                    Order = 3;
                }
                break;

            case 3://BoardのScore
                if (Scorenum <= 0)
                {
                    Scorenum = 0;
                }
                else if (Scorenum >= 999)
                {
                    Scorenum = 999;
                }
                scoretimer += Time.deltaTime;

                Score_oneObj.SetActive(true);
                Score_oneObj.GetComponent<Image>().sprite = ScoreSprites[Scorenum % 10];
                pata_oneObj.GetComponent<pataanim>().enabled = true;

                if (scoretimer >= 1.0f)
                {
                    Score_tenObj.SetActive(true);
                    Score_tenObj.GetComponent<Image>().sprite = ScoreSprites[(Scorenum % 100) / 10];
                    pata_tenObj.GetComponent<pataanim>().enabled = true;
                }
                if (scoretimer >= 2.0f)
                {
                    Score_hundredObj.SetActive(true);
                    Score_hundredObj.GetComponent<Image>().sprite = ScoreSprites[Scorenum / 100];
                    pata_hundredObj.GetComponent<pataanim>().enabled = true;
                    Order = 4;
                }
                break;

            case 4://BoardのStar
                startimer += Time.deltaTime;

                if (Starnum >= 1)
                {
                    star_0Obj.GetComponent<Image>().sprite = starSprites[1];
                }
                if (Starnum >= 2)
                {
                    star_1Obj.GetComponent<Image>().sprite = starSprites[1];
                }
                if (Starnum >= 3)
                {
                    star_2Obj.GetComponent<Image>().sprite = starSprites[1];
                }

                if (startimer >= 1.0f)
                {
                    star_0Obj.SetActive(true);
                    pata_star_0Obj.GetComponent<pataanim>().enabled = true;
                }
                if (startimer >= 2.0f)
                {
                    star_1Obj.SetActive(true);
                    pata_star_1Obj.GetComponent<pataanim>().enabled = true;
                }
                if (startimer >= 3.0f)
                {
                    star_2Obj.SetActive(true);
                    pata_star_2Obj.GetComponent<pataanim>().enabled = true;
                }

                break;
            default:
                break;
        }

        //Boardlight操作関係
        if (Order >= 3)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && lightposnow != lightpos.next && bScenechange == false)
            {
                lightposnow -= 1;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && lightposnow != lightpos.title && bScenechange == false)
            {
                lightposnow += 1;
            }

            if (lightposnow == lightpos.next)
            {
                GClightObj.transform.localPosition = GClightnextpos;
                if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space))
                {
                    FadePataanim_Next.SetActive(true);
                    Fade.SetFade();
                    bScenechange = true;
                }
                if (Fade.m_bChage)
                {
                    SceneManager.LoadScene(NextSceneName);
                }
            }
            else if (lightposnow == lightpos.retry)
            {
                GClightObj.transform.localPosition = GClightretrypos;
                if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space))
                {
                    FadePataanim_Retry.SetActive(true);
                    Fade.SetFade();
                    bScenechange = true;
                }
                if (Fade.m_bChage)
                {
                    SceneManager.LoadScene(nowSceneName);
                }
            }
            else if (lightposnow == lightpos.title)
            {
                GClightObj.transform.localPosition = GClighttitlepos;
                if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space))
                {
                    FadePataanim_Title.SetActive(true);
                    Fade.SetFade();
                    bScenechange = true;
                }
                if (Fade.m_bChage)
                {
                    SceneManager.LoadScene("Title");
                }
            }
        }
    }

}
