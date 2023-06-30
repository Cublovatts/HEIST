using UnityEngine;

public class Valuable : MonoBehaviour
{
    public void OnPickup()
    {
        Debug.Log("Item picked up");
        Destroy(gameObject);
    }
}
