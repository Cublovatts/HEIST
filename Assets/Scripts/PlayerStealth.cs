using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStealth : MonoBehaviour
{
    public GameObject StandingTarget;
    public GameObject CrouchedTarget;

    private StarterAssetsInputs _playerAssetInputs;

    void Start()
    {
        _playerAssetInputs = GetComponent<StarterAssetsInputs>();
    }

    void Update()
    {
        
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
}
