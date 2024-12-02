using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class VignetteByDistance : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform enemy;
    [SerializeField] private float maxDistance = 50f;
    [SerializeField] private float minIntensity = 0f;
    [SerializeField] private float maxIntensity = 1f;

    private Volume volume;
    private Vignette vignette;

    void Start()
    {
        volume = GetComponent<Volume>();

        if (!volume.profile.TryGet(out vignette))
        {
            Debug.LogError("Vignette effect not found in Volume profile!");
        }
    }

    void Update()
    {
        if (player != null && enemy != null)
        {
            if (vignette == null) return;

            float distance = Vector3.Distance(player.position, enemy.position) * 2;

            float normalizedProximity = Mathf.Clamp01(1 - (distance / maxDistance));

            float intensity = Mathf.Lerp(minIntensity, maxIntensity, normalizedProximity);

            if(intensity > 0.9f)
            {
                GameManager.Instance.finishGame();
                intensity = 0f;
            }

            vignette.intensity.value = intensity;
        }
    }

    public void setEnemy(Transform enemy)
    {
        this.enemy = enemy;
    }
}
