using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리 기능 사용
using UnityEngine.UI; // UI 요소 사용

public class MainMenu : MonoBehaviour
{
    public GameObject startUI; // 시작 UI 패널
    public GameObject rulesPanel; // 규칙 패널
    public Button startButton;
    public Button quitButton;
    public Button rulesButton;
    public Button backButton; // 규칙 패널의 뒤로 가기 버튼

    void Start()
    {
        // 버튼에 클릭 이벤트 추가
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
        rulesButton.onClick.AddListener(ShowRules);
        backButton.onClick.AddListener(BackToStart);

        // 규칙 패널을 비활성화
        rulesPanel.SetActive(false);
    }

    void StartGame()
    {
        // 게임을 시작할 로직을 여기에 추가
        // 예를 들어, 게임 씬을 로드하거나 게임의 시작 상태를 설정합니다.
        startUI.SetActive(false);
        Debug.Log("Start Game");
        // 예: SceneManager.LoadScene("GameScene"); // 실제 게임 씬으로 전환
    }

    void QuitGame()
    {
        // 애플리케이션 종료
        UnityEditor.EditorApplication.isPlaying = false;
    }

    void ShowRules()
    {
        // 규칙 패널 활성화
        rulesPanel.SetActive(true);
        // 다른 버튼들을 비활성화할 수 있습니다
        startButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        rulesButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true); // 뒤로 가기 버튼을 활성화
    }

    void BackToStart()
    {
        // 규칙 패널 비활성화하고 시작 버튼을 다시 활성화
        rulesPanel.SetActive(false);
        startButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        rulesButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(false); // 뒤로 가기 버튼을 비활성화
    }
}