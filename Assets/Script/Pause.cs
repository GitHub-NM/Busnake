using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField]
    GameObject lightObj;

    
    [SerializeField]
    GameObject FadePataanim_Retry;
    [SerializeField]
    GameObject FadePataanim_Title;

    [SerializeField]
    Vector3 lightBackpos;
    [SerializeField]
    Vector3 lightretrypos;
    [SerializeField]
    Vector3 lighttitlepos;

    [SerializeField]
    float timeBoardpop;

    //現在のScene取得(リトライ用)
    string nowSceneName;

    Vector3 initBoardpos;
    Vector3 endBoardpos;
    float Screenheight;

    public float timeStepBoard;
    public bool bpop;

    public int Order;
    enum lightpos
    {
        Back,
        retry,
        title
    };
    lightpos lightposnow;

    // Start is called before the first frame update
    void Start()
    {
        lightObj.transform.localPosition = lightBackpos;
        //現在のScene名取得(リトライ用)
        nowSceneName = SceneManager.GetActiveScene().name;

        Screenheight = Screen.height;
        initBoardpos = new Vector3(0, -370, 0);
        this.transform.localPosition = initBoardpos;
        endBoardpos = new Vector3(0, 0, 0);
        timeStepBoard = 0.0f;

        bpop = false;
        
        FadePataanim_Retry.SetActive(false);
        FadePataanim_Title.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (Order)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Order = 1;
                    timeStepBoard = 0;
                    bpop = false;
                }
                break;

            case 1:
                //pop
                this.transform.localPosition = Vector3.Lerp(initBoardpos, endBoardpos, timeStepBoard);
                timeStepBoard += Time.deltaTime / timeBoardpop;
                if (timeStepBoard >= 1)
                {
                    Order = 2;
                    timeStepBoard = 1;
                }
                break;

            case 2:
                //操作関係
                if (Input.GetKeyDown(KeyCode.UpArrow) && lightposnow != lightpos.Back)
                {
                    lightposnow -= 1;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) && lightposnow != lightpos.title)
                {
                    lightposnow += 1;
                }

                if (lightposnow == lightpos.Back)
                {
                    lightObj.transform.localPosition = lightBackpos;
                    if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space))
                    {
                        
                        bpop = true;
                    }
                }
                else if (lightposnow == lightpos.retry)
                {
                    lightObj.transform.localPosition = lightretrypos;
                    if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space))
                    {
                        FadePataanim_Retry.SetActive(true);
                        SceneManager.LoadScene(nowSceneName);
                    }
                }
                else if (lightposnow == lightpos.title)
                {
                    lightObj.transform.localPosition = lighttitlepos;
                    if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space))
                    {
                        FadePataanim_Title.SetActive(true);
                        SceneManager.LoadScene("Title");
                    }
                }
                if (Input.GetKeyDown(KeyCode.P))
                {
                    bpop = true;


                }

                if (bpop == true)
                {
                    endBoardpos = new Vector3(0, 0, 0);
                    this.transform.localPosition = Vector3.Lerp(initBoardpos, endBoardpos, timeStepBoard);
                    timeStepBoard -= Time.deltaTime / timeBoardpop;
                    if (timeStepBoard <= 0)
                    {

                        Order = 0;
                    }
                }
                break;
        }


    }
}
