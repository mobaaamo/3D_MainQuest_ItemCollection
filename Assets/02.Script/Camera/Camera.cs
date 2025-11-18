using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 3f, -5f);
    [SerializeField] private float smoothSpeed = 10.0f;

    private void LateUpdate()
    {
        CameraPosition();
    }

    void CameraPosition()
    {
        Vector3 desiredPosition = target.position + target.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target.position + Vector3.up * 2f); // 살짝 위를 보게 캐릭터의 회전을 조절
    }
}
