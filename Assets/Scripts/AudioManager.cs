using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Button muteBtn; // 음소거 버튼
    public AudioSource Click; // 클릭 소리 지정
    public AudioSource Stone; // 돌 소리 지정

    private void Start()
    {
        muteBtn.onClick.AddListener(ToggleAudio); // 음소거 버튼 온클릭 설정
    }

    void ToggleAudio() // 음소거 토글 함수
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0; // 한 번 누르면 오디오 리스너의 소리를 0으로 바꾸고 한 번 더 누르면 1로 바뀜 
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 좌클릭를 눌렀을때 
        {
            Click.Play(); // 클릭소리 재생
        }

        if (Input.GetMouseButtonUp(0)) // 좌클릭을 땠을때
        {
            Stone.Play(); // 돌 소리 재생
        }
    }
}
