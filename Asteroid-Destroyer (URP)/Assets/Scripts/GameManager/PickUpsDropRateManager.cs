using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpsDropRateManager : MonoBehaviour
{
    public static PickUpsDropRateManager Instance { get; private set; }

    [SerializeField] float shieldPickUpDropRate;
    [SerializeField] float healthPickUpDropRate;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float GetShieldPickUpDropRate() => shieldPickUpDropRate;
    public float GetHealthPickUpDropRate() => healthPickUpDropRate;

    public void SetShieldPickUpDropRate(float shieldPickUpDropRate) => this.shieldPickUpDropRate = shieldPickUpDropRate;
    public void SetHealthPickUpDropRate(float healthPickUpDropRate) => this.healthPickUpDropRate = healthPickUpDropRate;

}
