using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private float amplitudeGainOnDamaged;
    [SerializeField] private float amplitudeGainOnAttack;
    [Range(0, 1.0f)]
    [SerializeField] private float interpolationRate;
    private CinemachineBasicMultiChannelPerlin noiseChannel;

    private void Awake()
    {
        noiseChannel = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void OnEnable()
    {
        GameManager.instance.Player.Damageable.OnDamaged += ApplyDamagedScreenShake;
        GameManager.instance.Player.Damageable.OnDestruct += ApplyDamagedScreenShake;
        GameManager.instance.Player.AttackController.OnAttack += ApplyAttackScreenShake;
    }

    private void OnDisable()
    {
        GameManager.instance.Player.Damageable.OnDamaged -= ApplyDamagedScreenShake;
        GameManager.instance.Player.Damageable.OnDestruct -= ApplyDamagedScreenShake;
        GameManager.instance.Player.AttackController.OnAttack -= ApplyAttackScreenShake;
    }

    private void FixedUpdate()
    {
        if (noiseChannel.m_AmplitudeGain > 0)
            noiseChannel.m_AmplitudeGain = Mathf.Lerp(0, noiseChannel.m_AmplitudeGain, interpolationRate);
        else
            noiseChannel.m_AmplitudeGain = 0;
    }

    private void ApplyDamagedScreenShake()
    {
        noiseChannel.m_AmplitudeGain = amplitudeGainOnDamaged;
    }

    private void ApplyAttackScreenShake()
    {
        noiseChannel.m_AmplitudeGain = amplitudeGainOnAttack;
    }
}
