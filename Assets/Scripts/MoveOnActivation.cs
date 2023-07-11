using UnityEngine;

public class MoveOnActivation : MonoBehaviour
{
    public Transform Destination;

    [SerializeField]
    private float _moveSpeed = 2f;

    private bool _isActivated = false;

    void Update()
    {
        if (_isActivated)
        {
            var step = _moveSpeed * Time.deltaTime;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Destination.position, step);
        }
    }

    [ContextMenu("Activate")]
    public void Activate()
    {
        _isActivated = true;
    }
}
