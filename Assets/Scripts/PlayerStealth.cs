using StarterAssets;
using UnityEngine;

public class PlayerStealth : MonoBehaviour
{
    public GameObject StandingTarget;
    public GameObject CrouchedTarget;

    private StarterAssetsInputs _playerAssetInputs;

    private float _visibilityFactor;

    void Start()
    {
        _playerAssetInputs = GetComponent<StarterAssetsInputs>();
    }

    void Update()
    {
        UpdateVisibilityFactor();
    }

    public float GetVisibilityFactor()
    {
        return _visibilityFactor;
    }

    public GameObject GetVisionTarget()
    {
        if (_playerAssetInputs.crouch)
        {
            return CrouchedTarget;
        } else
        {
            return StandingTarget;
        }
    }

    private void UpdateVisibilityFactor()
    {
        // Detect whether player is in light, long grass, wearing invisibility cloak, anything that would obscure their visibility
        _visibilityFactor = 1f;
    }
}
