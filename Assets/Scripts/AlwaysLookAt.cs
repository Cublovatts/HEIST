using UnityEngine;

public class AlwaysLookAt : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target, Vector3.up);
            transform.Rotate(Vector3.right, 90f);
        }
    }
}
