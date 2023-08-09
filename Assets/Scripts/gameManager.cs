using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class gameManager : MonoBehaviour
{
    public Text timeTxt;
    public Text matchTxt;
    public Text endTime;
    public Text endMatch;
    public Text totalScore;

    public GameObject successImage;
    public GameObject failImage;
    public GameObject card;
    public GameObject firstCard;
    public GameObject secondCard;
    public GameObject timer;

    public Animator anim;

    public AudioSource audioSource;
    public AudioClip match;
    public AudioClip win;

    public static gameManager I;


    float timelimit;
    float time;
    int tryMatch;
    int cards;

    void Awake()
    {
        I = this;
    }

    void Start()
    {
        init();
        cards = 8;

        int[] images = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

        images = images.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        for (int i = 0; i < 16; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("Cards").transform;

            float x = (i / 4) * 1.4f - 2.1f;
            float y = (i % 4) * 1.4f - 3.0f;
            newCard.transform.position = new Vector3(x, y, 0);

            string imageName = "Image" + images[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(imageName);

            newCard.GetComponent<card>().type = images[i] < 4 ? 0 : 1 ;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        timeTxt.text = time.ToString("N2");

        if (gameManager.I.firstCard != null && gameManager.I.secondCard == null)
        {
            LimitTime();
        }

            if (time <= 0)
        {
            failImage.SetActive(true);
            endGame();
        }
        else if(time <= 20)
        {
            anim.SetBool("isWarning", true);
        }
    }

    void init()
    {
        Time.timeScale = 1.0f;
        time = 60f;
        timelimit = 5f;
        tryMatch = 0;
        anim.SetBool("isWarning", false);
    }


    public void isMatched()
    {
        tryMatch++;
        matchTxt.text = tryMatch.ToString();

        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            audioSource.PlayOneShot(match);

            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();

            cards--;
            if (cards == 0)
            {
                successGame();
                endGame();
            }
        }
        else
        {
            time -= 3f;
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
        }

        timerefill();
        firstCard = null;
        secondCard = null;
    }

    void endGame()
    {
        Time.timeScale = 0.0f;
    }

    void successGame()
    {
        successImage.SetActive(true);
        endTime.text = string.Concat("시간: ", timeTxt.text);
        endMatch.text = string.Concat("횟수: ", matchTxt.text);
        int score = 100 - ((int)time) - tryMatch;

        audioSource.PlayOneShot(win);

        totalScore.text = string.Concat("점수: ", score.ToString());
    }

    void LimitTime()
    {
        timer.SetActive(true);
        Text t = timer.GetComponent<Text>();
        t.text = timelimit.ToString("N2");
        timelimit -= Time.deltaTime;
        
        if (timelimit <= 0)
        {
            gameManager.I.firstCard.GetComponent<card>().closeCard();
            firstCard.GetComponent<card>().closeCard();
            firstCard = null;
            time += 3f;
            timerefill();
        }
        
    }

    void timerefill()
    {
        timer.SetActive(false);
        timelimit = 5f;
    }

}
