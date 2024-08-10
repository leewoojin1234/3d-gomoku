using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 offset;
    private float zCoordinate;
    private Vector3 initialPosition;

    private void OnMouseDown()
    {
        zCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        // 바둑알을 클릭할 때 Y축을 4만큼 상승
        initialPosition = transform.position;
        transform.position = new Vector3(initialPosition.x, initialPosition.y + 1, initialPosition.z);
        // 마우스 포지션과 오브젝트 간의 오프셋 계산
        offset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        // 마우스 포지션을 월드 좌표로 변환
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoordinate;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        // 드래그 시 오브젝트 위치 업데이트
        transform.position = GetMouseWorldPos() + offset;
    }

    private void OnMouseUp()
    {
        // 마우스 업 시 Y축을 원래 위치로 복원
        transform.position = new Vector3(transform.position.x, initialPosition.y, transform.position.z);
    }
}