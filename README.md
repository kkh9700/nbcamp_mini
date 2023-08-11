# nbcamp_mini

## git 클론하기
```
git clone https://github.com/kkh9700/nbcamp_mini.git ./
```
<br>

## 시연 영상 (클릭시 이동)
[![Video Label](http://img.youtube.com/vi/MJSjqc2qEqU/0.jpg)](https://youtu.be/MJSjqc2qEqU)
<br>
<br>

## 필수 기능 (매칭 성공 시, 팀원의 이름 표시 / 실패 시 실패 표시)
![필수기능 성공](https://github.com/kkh9700/nbcamp_mini/assets/77197725/0f935102-e492-4741-ae84-d0335459d3fa)
<details>
<summary>팀원 이름 표시</summary>

        void destroyCardInvoke()        // 카드 삭제시
        {
            GameObject newText = Instantiate(text);        // 게임 오브젝트 newText 생성
            newText.transform.parent = GameObject.Find("Canvas").transform;        // newText의 부모를 Canvas로 설정 

            float x = this.transform.position.x;        // x에 카드의 position의 x를 저장
            float y = this.transform.position.y;        // y에 카드의 position의 y를 저장

            newText.transform.SetAsFirstSibling();        // newText를 첫번째로 설정
            newText.transform.position = new Vector3(x, y, 0);        // newText의 position을 x,y,0으로 설정
            newText.transform.localScale = new Vector3(1f, 1f, 1f);        // newText의 scale을 1,1,1로 설정

            Text t = newText.GetComponent<Text>();        // newText의 Text 컴포넌트를 가져옴
            t.text = type == 0 ? "김경환" : "김민태";        // Text의 값을 멤버의 이름으로 설정

            Destroy(gameObject);        // 게임 오브젝트 카드를 삭제
        }

</details>
<br>

## 타이머 시간이 촉박 할 때 게이머에게 경고하는 기능(김경환)
![경고기능](https://github.com/kkh9700/nbcamp_mini/assets/77197725/9379ec7a-efa0-4303-8884-e23c2d91ffe6)
![경고_애니메이션](https://github.com/kkh9700/nbcamp_mini/assets/77197725/ac62a0c9-47ed-4c31-8572-d0466fa38f70)
<details>
<summary>경고 기능</summary>

    void Update()        // 프레임마다 호출되는 함수
    {
        ...
        else if(time <= 20)        // 시간이 20초 이하일 때
        {
            anim.SetBool("isWarning", true);        // Animation의 Parameter인 isWarning을 true로 한다.
        }
    }

</details>
<br>

## 카드 뒤집기에서 실제로 카드가 뒤집어지는 모습 연출 (김경환)
![카드_뒤집기](https://github.com/kkh9700/nbcamp_mini/assets/77197725/78377aed-3919-43fe-a63c-53382e5b2191)
<br></br>
![카드_뒤집기_open_애니메이션](https://github.com/kkh9700/nbcamp_mini/assets/77197725/18f7770b-7374-418a-9ee3-fcea8f12b8b5)
![카드_뒤집기_close_애니메이션](https://github.com/kkh9700/nbcamp_mini/assets/77197725/13a68f79-76e8-4829-8f60-8b260c12e0d2)

<details>
<summary>카드 뒤집는 애니메이션</summary>

    public void ClickCard()        // 카드를 클릭했을 때
    {
        ...
        anim.SetBool("isOpen", true);        // Animation의 Parameter인 isOpen을 true로 한다.
        ...
    }

    void closeCardInvoke()        // 카드를 close하는 Invoke method
    {
        ...
        anim.SetBool("isOpen", false);        // Animation의 Parameter인 isOpen을 false로 한다.
    }

    
        
</details>
<br>

## 결과에 점수 표시 → 남은 시간, 매칭 시도한 횟수 등을 점수로 환산 (김경환)
![종합점수](https://github.com/kkh9700/nbcamp_mini/assets/77197725/7d4bde7e-6a00-484c-b209-2f783e09b951)

<details>
<summary>종합점수</summary>


    void Update()        // 프레임마다 호출되는 함수
    {
        time -= Time.deltaTime;        // 시간을 감소시킨다
        ...
    }
        
    public void isMatched()        // 카드가 맞았는지 확인
    {
        tryMatch++;        // 매칭횟수 증가
        ...
    }
    
    void successGame()        // 카드 맞추기를 성공했을 때
    {
        ...
        int score = 100 + ((int)time) - tryMatch;        // 종합점수 계산식 : 100 + 남은시간 - 매칭횟수
        totalScore.text = string.Concat("점수: ", score.ToString());        // 종합점수를 표시
        ...
    }
    
        
</details>
<br>

## firstCard 고르고 5초 간 카운트 다운 - 안 고르면 다시 닫기 (김민태)
![5초_제한](https://github.com/kkh9700/nbcamp_mini/assets/77197725/38fcf0b0-f58f-4562-8392-84daa520cc18)
<details>
<summary>종합점수</summary>

    void Update()        // 프레임마다 호출되는 함수
    {
        ...
        if (gameManager.I.firstCard != null && gameManager.I.secondCard == null)        // 첫번째 카드만 열렸을 때
        {
            LimitTime();        // 시간제한 함수 실행
        }
        ...
    }

    void LimitTime()        // 시간제한 함수
    {
        timer.SetActive(true);        // timer가 보이게 하기
        Text t = timer.GetComponent<Text>();        // timer의 Text 컴포넌트 가져오기 
        t.text = timelimit.ToString("N2");        // Text 컴포넌트의 값에 timelimit를 넣기
        timelimit -= Time.deltaTime;        // timelimit 감소
        
        if (timelimit <= 0)        // timelimit가 0이하일 떄
        {
            firstCard.GetComponent<card>().closeCard();        // 첫번째 카드 닫기
            firstCard = null;        // 첫번째 카드를 초기화
            ...
            timerefill();        // 시간을 리필하는 함수 실행
        }
    }

    void timerefill()        // 시간 리필 함수
    {
        timer.SetActive(false);        // 타이머가 보이지 않게 하기
        timelimit = 5f;        // timelimit를 5로 초기화
    }

</details>
<br>

## 실패할 때 마다 시간 감소 효과 (김민태)
![실패시_시간_감소](https://github.com/kkh9700/nbcamp_mini/assets/77197725/1e987610-3b2d-4d75-a73f-2a7ed2b5f84f)
<details>
<summary>실패시 시간 감소</summary>

    public void isMatched()        // 카드가 맞았는지 확인
    {
        ...

        if (firstCardImage == secondCardImage)        // 카드 맞추기에 성공
        {
           ...
        }
        else        // 카드 맞추기에 실패
        {
            time -= 3f;        // 시간 3초 감소
            ...
        }
        ...
    }
    
    void LimitTime()        // 시간제한 함수
    {
        ...
        
        if (timelimit <= 0)        // 시간 제한을 넘었을 때
        {
            ...
            time += 3f;        // 시간 3초 감소
            ...
        }
        
    }

</details>
<br>

## 클릭할 때(카드 뒤집을 때), 시작할 때, 진행 중일 때 성공, 실패 소리 넣어보기 (김민태)
<details>
<summary>시작할 때 소리</summary>

    public class audioManager : MonoBehaviour        // audioManager 스크립트
    {
        public AudioSource audioSource;        // audioSource 컴포넌트
        public AudioClip bgmusic;        // bgm 음악

        void Start()
        {
            audioSource.clip = bgmusic;        // audioSource의 clip을 bgmusic으로 설정
            audioSource.Play();        // 음악 재생
        }
    }

</details>
<details>
<summary>클릭할 때(카드 뒤집을 때)</summary>

    public class card : MonoBehaviour        // card 스크립트
    {
        public AudioSource audioSource;        // audioSource 컴포넌트
        public AudioClip flip;        // 뒤집을 때 나는 음악
        ...
        
        public void ClickCard()        // 카드가 클릭됬을 때
        {
            audioSource.PlayOneShot(flip);        // filp 재생
        }
    }

</details>

<details>
<summary>카드 맞추기 성공</summary>

    public class gameManager : MonoBehaviour        // gameManager 스크립트
    {
        public AudioSource audioSource;        // audioSource 컴포넌트
        public AudioClip match;        // 카드 맞추기 성공했을 때 나는 음악
        ...

        public void isMatched()        // 카드가 맞았는지 확인
        {
            ...

            if (firstCardImage == secondCardImage)        // 카드가 맞았을 때
            {
                audioSource.PlayOneShot(match);        // match 재생
                ...
            }
            else
            {
                ...
            }

            ...
    }

</details>

<details>
<summary>게임 클리어</summary>

    public class gameManager : MonoBehaviour        // gameManager 스크립트
    {
        public AudioSource audioSource;        // audioSource 컴포넌트
        public AudioClip win;        // 승리했을 때 나는 음악
        ...

        void successGame()        // 승리했을 때
        {
            ...
            audioSource.PlayOneShot(win);        // win 재생
            ...
        }
    }

</details>
<br>
