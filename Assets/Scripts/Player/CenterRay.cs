using UnityEngine;

public class CenterRay : MonoBehaviour
{
    public float distance = 5f;

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0f));
        if(Physics.Raycast(ray, out RaycastHit hit, distance))
        {
            Debug.Log(hit.collider.name);
        }
    }
}
