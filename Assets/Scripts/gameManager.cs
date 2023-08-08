using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class gameManager : MonoBehaviour
{
    public Text timeTxt;
    public GameObject endTxt;
    public Text limittxt; //메인씬에 캔버스 안에 있는 리미트텍스트 입니다.
    float timelimit = 5f;

    public GameObject card;
    public GameObject firstCard;
    public GameObject secondCard;

    public AudioSource audioSource;
    public AudioClip match;

    public static gameManager I;

    float time = 0f;
    int cards;

    void Awake()
    {
        I = this;
    }

    void Start()
    {
        Time.timeScale = 1.0f;
        cards = 8;

        int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

        rtans = rtans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        for (int i = 0; i < 16; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("Cards").transform;

            float x = (i / 4) * 1.4f - 2.1f;
            float y = (i % 4) * 1.4f - 3.0f;
            newCard.transform.position = new Vector3(x, y, 0);

            string rtanName = "rtan" + rtans[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        timeTxt.text = time.ToString("N2");

        if(time >= 30)
        {
            endGame();
        }
        LimitTime();
    }


    public void isMatched()
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            audioSource.PlayOneShot(match);

            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();
            timerefill();
            cards--;
            if (cards == 0)
            {
                endGame();
            }
        }
        else
        {
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
            timerefill();
            time += 3f;
        }

        firstCard = null;
        secondCard = null;
    }

    void endGame()
    {
        endTxt.SetActive(true);
        Time.timeScale = 0.0f;
    }
   
    void LimitTime() // 업데이트 함수에 넣으면 정상 작동 할겁니다.
    {
        if (gameManager.I.firstCard != null && gameManager.I.secondCard == null)
        {
            limittxt.gameObject.SetActive(true);
            limittxt.text = timelimit.ToString("N2");
            timelimit -= Time.deltaTime;
            if (timelimit <= 0)
            {
                gameManager.I.firstCard.GetComponent<card>().closeCard();
                firstCard.GetComponent<card>().closeCard();
                firstCard = null;
                time += 3f; //이거는 isMatch함수의 else 부분에도 넣어주시면 감사하겠습니다.
                timerefill();
            }
        }
    }
    void timerefill()
    {
        limittxt.gameObject.SetActive(false);
        timelimit = 5f;
    }
}
