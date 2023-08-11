# nbcamp_mini

## git 클론하기
```
git clone https://github.com/kkh9700/nbcamp_mini.git ./
```
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

    void Update()
    {
        ...
        ...
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
<summary>경고 기능</summary>

    public void ClickCard()        // 카드를 클릭했을 때
    {
        ...
        anim.SetBool("isOpen", true);        // Animation의 Parameter인 isOpen을 true로 한다.
        ...
    }
        
</details>
<br>
