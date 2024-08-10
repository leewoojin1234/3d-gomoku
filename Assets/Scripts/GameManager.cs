using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리 기능 사용
using UnityEngine.UI; // UI 요소 사용

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel; // 일시정지 패널
    public Button resumeButton;
    public Button resetButton; // 리셋 버튼 추가

    private bool isPaused = false;

    void Start()
    {
        // 버튼에 클릭 이벤트 추가
        resumeButton.onClick.AddListener(ResumeGame);
       
        resetButton.onClick.AddListener(ResetGame); // 리셋 버튼 이벤트 추가

        // 일시정지 패널을 비활성화
        pausePanel.SetActive(false);
    }

    void Update()
    {
        // 일시정지 토글을 위한 입력 감지 (예: Escape 키)
        if (Input.GetKeyUp(KeyCode.W))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        // 게임 일시정지
        Time.timeScale = 0; // 게임의 시간 흐름을 멈춤
        pausePanel.SetActive(true); // 일시정지 패널 활성화
        isPaused = true;
    }

    void ResumeGame()
    {
        // 게임 재개
        Time.timeScale = 1; // 게임의 시간 흐름을 다시 시작
        pausePanel.SetActive(false); // 일시정지 패널 비활성화
        isPaused = false;
    }

    void ResetGame()
    {
        // 현재 씬을 다시 로드하여 게임을 리셋
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    
}
