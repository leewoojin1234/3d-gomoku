using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class DragObject : MonoBehaviour
{
    private Vector3 offset; // 마우스와 오브젝트 사이의 거리 저장
    private float zCoordinate; // 마우스 포지션과 오브젝트의 월드 좌표 간의 깊이 저장
    private Vector3 initialPosition; // 오브젝트의 초기 위치 저장

    private void OnMouseDown() // 마우스로 오브젝트를 클릭했을때
    {
        zCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        // 바둑알을 클릭할 때 Y축 1만큼 상승
        initialPosition = transform.position;
        transform.position = new Vector3(initialPosition.x, initialPosition.y + 1, initialPosition.z);
        // 마우스 포지션과 오브젝트 간의 오프셋 계산
        offset = gameObject.transform.position - GetMouseWorldPos();
        Debug.Log("들어올림");
    }

    private Vector3 GetMouseWorldPos() // 마우스 포지션을 월드 좌표로 변환
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoordinate;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag() // 마우스 드래그
    {
        // 드래그 시 오브젝트 위치 업데이트
        transform.position = GetMouseWorldPos() + offset;
    }

    private void OnMouseUp() // 마우스 버튼 땠을때
    {
        // 마우스 업 시 Y축을 원래 위치로 복원
        Debug.Log("놓음");
        transform.position = new Vector3(transform.position.x, initialPosition.y, transform.position.z);
    }
}