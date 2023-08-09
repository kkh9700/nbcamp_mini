using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class card : MonoBehaviour
{
    public Animator anim;
    public AudioClip flip;
    public AudioSource audioSource;

    public GameObject text;

    public int type;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickCard()
    {
        GetComponent<Button>().interactable = false;
        audioSource.PlayOneShot(flip);
        anim.SetBool("isOpen", true);
        Invoke("OpenCard", 0.2f);
    }

    public void OpenCard()
    {

        transform.Find("front").gameObject.SetActive(true);
        transform.Find("back").gameObject.SetActive(false);
        if (gameManager.I.firstCard == null)
        {
            gameManager.I.firstCard = gameObject;
        }
        else
        {
            gameManager.I.secondCard = gameObject;
            gameManager.I.isMatched();
        }
    }

    public void destroyCard()
    {
        Invoke("destroyCardInvoke", .5f);
    }

    void destroyCardInvoke()
    {
        GameObject newText = Instantiate(text);
        newText.transform.parent = GameObject.Find("Canvas").transform;

        float x = this.transform.position.x;
        float y = this.transform.position.y;

        newText.transform.SetAsFirstSibling();
        newText.transform.position = new Vector3(x, y, 0);
        newText.transform.localScale = new Vector3(1f, 1f, 1f);

        Text t = newText.GetComponent<Text>();
        t.text = type == 0 ? "±Ë∞Ê»Ø" : "±ËπŒ≈¬";

        Destroy(gameObject);
    }

    public void closeCard()
    {
        Invoke("closeCardInvoke", 0.5f);
    }

    void closeCardInvoke()
    {
        GetComponent<Button>().interactable = true;
        anim.SetBool("isOpen", false);
        transform.Find("back").gameObject.SetActive(true);
        transform.Find("front").gameObject.SetActive(false);
    }
}
