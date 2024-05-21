using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveParticleEffect : MonoBehaviour
{
	[SerializeField] GameObject shockwaveParticleEffect;

    private void Update()
    {
        if(PlayerLevelUpManager.Instance.isLeveledUp)
        {
            shockwaveParticleEffect.SetActive(true);
            PlayerLevelUpManager.Instance.isLeveledUp = false;
            Invoke(nameof(DisableParticleEffect), 2f * Time.unscaledDeltaTime);
        }
    }

    private void DisableParticleEffect() => shockwaveParticleEffect.SetActive(false);
}
