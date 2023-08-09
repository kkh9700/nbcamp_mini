using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//이거는 이제 게임매니저로 옮기게되면 주석처리 지워주시면 감사하겠습니다.
public class limittime : MonoBehaviour
{
    /*public Text limittxt; //메인씬에 캔버스 안에 있는 리미트텍스트 입니다.
    float timelimit = 5f;
    void LimitTime() // 업데이트 함수에 넣으면 정상 작동 할겁니다.
    {
        if (gameManager.I.firstCard != null && gameManager.I.secondCard == null)
        {
            limittxt.gameObject.SetActive(true);
            timelimit -= Time.deltaTime;
            if (timelimit <= 0)
            {
                gameManager.I.firstCard.GetComponent<card>().closeCard();
                firstCard.GetComponent<card>().closeCard();
                firstCard = null;
                ** time -= 3f; ** //이거는 isMatch함수의 else 부분에도 넣어주시면 감사하겠습니다.

            }
        }   
    }
    void timerefill()
    {
        limittxt.gameObject.SetActive(false);
        timelimit = 5f;
    }*/
}
