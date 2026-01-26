using UnityEngine;

public class Interactor : MonoBehaviour
{
    public Transform interactPoint;
    public float radius = 1.2f;
    public LayerMask interactMask;

    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;

        var hits = Physics.OverlapSphere(interactPoint.position, radius, interactMask);
        if (hits.Length == 0) return;

        // берём первый попавшийся интерактивный объект
        var interactable = hits[0].GetComponent<IInteractable>();
        if (interactable != null)
            interactable.Interact();
    }

    void OnDrawGizmosSelected()
    {
        if (!interactPoint) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactPoint.position, radius);
    }
}
