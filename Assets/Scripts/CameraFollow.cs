using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 5f, -7f);
    public float smooth = 8f;

    void LateUpdate()
    {
        if (!target) return;

        Vector3 desired = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desired, smooth * Time.deltaTime);

        // Смотреть на игрока
        Vector3 lookPos = target.position + Vector3.up * 1.5f;
        transform.LookAt(lookPos);
    }
}

