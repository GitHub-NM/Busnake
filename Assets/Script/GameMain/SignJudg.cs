using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignJudg : MonoBehaviour
{
    // メンバ変数宣言
    private int nSignjudganimal;

    public bool arrival;

    public AudioSource[] AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        // 判定用の値を格納
        nSignjudganimal = gameObject.GetComponentInChildren<SpriteChange>().nSpriteNum;

        // 初期化
        arrival = false;

        AudioSource = gameObject.GetComponents<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // プレイヤーと当たったら
        if(collision.gameObject.tag == "Player")
        {
            // 中身がないとき
            if (collision.gameObject.GetComponent<BusnakeHead>().bStack.stack.Count == 0)
            {
                // 音再生
                AudioSource[1].Play();

                // バス停の近くのイメージを出す
                GetComponentInChildren<SpriteChange>().GetComponentInChildren<offAnimal>().missarrival = true;

                Debug.Log("中身がない"); return;
            }

            // スタックに入ってるのが一致したら
            if (nSignjudganimal == collision.gameObject.GetComponent<BusnakeHead>().bStack.stack.Peek().GetAnimals())
            {
                // 音再生
                AudioSource[0].Play();

                // スタックから抜く
                collision.gameObject.GetComponent<BusnakeHead>().bStack.stack.Peek().gameObject.GetComponent<Image>().enabled = false;
                collision.gameObject.GetComponent<BusnakeHead>().bStack.stack.Pop();

                // バス停の近くのイメージを出す
                GetComponentInChildren<SpriteChange>().GetComponentInChildren<offAnimal>().GetComponentInChildren<Image>().enabled = true;

                // 当たり判定を消す
                GetComponent<BoxCollider2D>().enabled = false;

                // フラグを立てる
                arrival = true;

                Debug.Log("当たった、そして中身を抜いた");
            }
            else if (collision.gameObject.GetComponent<BusnakeHead>().bStack.stack.Peek() == null)
            {
                // 音再生
                AudioSource[1].Play();

                // バス停の近くのイメージを出す
                GetComponentInChildren<SpriteChange>().GetComponentInChildren<offAnimal>().missarrival = true;

                Debug.Log("中身がないよ");
            }
            else
            {
                // 音再生
                AudioSource[1].Play();

                // バス停の近くのイメージを出す
                GetComponentInChildren<SpriteChange>().GetComponentInChildren<offAnimal>().missarrival = true;

                Debug.Log("違うやつが当たった");
            }
        }
    }
}
