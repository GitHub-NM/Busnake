using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignJudg : MonoBehaviour
{
    // メンバ変数宣言
    private int nSignjudganimal;

    // Start is called before the first frame update
    void Start()
    {
        // 判定用の値を格納
        nSignjudganimal = gameObject.GetComponentInChildren<SpriteChange>().nSpriteNum;
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
            if (collision.gameObject.GetComponent<BusnakeMoveAnim>().bStack.stack.Count == 0)
            {
                Debug.Log("中身がない"); return;
            }

            // スタックに入ってるのが一致したら
            if (nSignjudganimal == collision.gameObject.GetComponent<BusnakeMoveAnim>().bStack.stack.Peek().GetAnimals())
            {
                collision.gameObject.GetComponent<BusnakeMoveAnim>().bStack.stack.Pop();
                collision.gameObject.GetComponent<BusnakeMoveAnim>().AnimalObj.[collision.gameObject.GetComponent<BusnakeMoveAnim>().nCnt] = null;
                Debug.Log("当たった、そして中身を抜いた");
            }
            else if (collision.gameObject.GetComponent<BusnakeMoveAnim>().bStack.stack.Peek() == null)
            {
                Debug.Log("中身がないよ");
            }
            else
            {
                Debug.Log("違うやつが当たった");
            }
        }
    }
}
