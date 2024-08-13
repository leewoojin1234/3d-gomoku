using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel; // 일시정지 패널
    public Button resumeBtn; // 재개 버튼
    public Button resetBtn; // 리셋 버튼
    private bool isPaused = false; // 정지 유무

    void Start()
    {
        // 버튼에 클릭 이벤트 추가
        resumeBtn.onClick.AddListener(ResumeGame);
        resetBtn.onClick.AddListener(ResetGame);

        // 일시정지 패널을 비활성화
        pausePanel.SetActive(false);
    }

    void Update()
    {
        // ESC 키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("pause");
            if (isPaused)
            {
                ResumeGame(); // 게임 재개
            }
            else
            {
                PauseGame(); // 게임 일시정지
            }
        }
    }

    void PauseGame() // 게임 일시정지
    {
        Time.timeScale = 0; // 게임의 시간 흐름을 멈춤
        pausePanel.SetActive(true); // 일시정지 패널 활성화
        isPaused = true; // 게임 정지 || 참
        Debug.Log("Pause Game");
    }
    
    void ResumeGame() // 게임 재개
    {
        Time.timeScale = 1; // 게임의 시간 흐름을 다시 시작
        pausePanel.SetActive(false); // 일시정지 패널 비활성화
        isPaused = false; // 게임 정지 || 거짓
    }
    void ResetGame() // 현재 씬을 다시 로드하여 게임을 리셋
    {
        // 현재 활성화된 씬을 다시 로드하여 게임을 초기화
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}