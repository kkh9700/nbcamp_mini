# nbcamp_mini

## git 클론하기
```
git clone https://github.com/kkh9700/nbcamp_mini.git ./
```

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
