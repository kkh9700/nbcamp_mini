# nbcamp_mini

## git 클론하기
```
git clone https://github.com/kkh9700/nbcamp_mini.git ./
```

## 필수 기능 (매칭 성공 시, 팀원의 이름 표시 / 실패 시 실패 표시)
![필수기능 성공](https://github.com/kkh9700/nbcamp_mini/assets/77197725/0f935102-e492-4741-ae84-d0335459d3fa)
<details>
<summary>팀원 이름 표시</summary>

        ```
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
            t.text = type == 0 ? "김경환" : "김민태";

            Destroy(gameObject);
        }
        ```

</details>
