using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리 기능 사용
using UnityEngine.UI; // UI 요소 사용

public class MainMenu : MonoBehaviour
{
    public AudioSource fallingStones;
    public GameObject startUI; // 시작 UI 패널
    public GameObject rulesPanel; // 규칙 패널
    public Button startBtn; // 시작 버튼
    public Button quitBtn; // 나가는 버튼
    public Button rulesBtn; // 규칙 패널을 보는 버튼
    public Button backBtn; // 규칙 패널의 뒤로 가기 버튼

    void Start()
    {
        Time.timeScale = 0; // 시작화면에는 시간 멈춤 
        // 버튼에 클릭 이벤트 추가
        startBtn.onClick.AddListener(StartGame);
        quitBtn.onClick.AddListener(QuitGame);
        rulesBtn.onClick.AddListener(ShowRules);
        backBtn.onClick.AddListener(BackToStart);

        // 규칙 패널 비활성화
        rulesPanel.SetActive(false);
    }

    void StartGame() // START버튼을 누를시
    {
        Time.timeScale = 1; // 시작시 시간 흐름
        startUI.SetActive(false); // 시작 패널 비활성화
        fallingStones.Play();
        Debug.Log("Start Game");
    }

    void QuitGame() // QUIT버튼을 누를시
    {
        UnityEditor.EditorApplication.isPlaying = false; // 유니티 에디터상에서 종료
        Debug.Log("Quit Game");
    }

    void ShowRules()
    {
        // 규칙 패널 활성화
        rulesPanel.SetActive(true);
        // 다른 버튼들도 비활성화
        startBtn.gameObject.SetActive(false);
        quitBtn.gameObject.SetActive(false);
        rulesBtn.gameObject.SetActive(false);
        backBtn.gameObject.SetActive(true); // 뒤로 가기 버튼은 활성화
    }

    void BackToStart()
    {
        // 규칙 패널 비활성화하고 시작 버튼을 다시 활성화
        rulesPanel.SetActive(false);
        startBtn.gameObject.SetActive(true);
        quitBtn.gameObject.SetActive(true);
        rulesBtn.gameObject.SetActive(true);
        backBtn.gameObject.SetActive(false); // 뒤로 가기 버튼은 비활성화
    }
}