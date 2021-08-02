using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private List<GameObject> hitboxes;
    [SerializeField] private List<float> hitboxDurations;
    [SerializeField] private float comboTimeFrame;
    private float timeSinceLastAttack = 0f;
    private int lastAttackNumber = 0;

    public float TimeSinceLastAttack => timeSinceLastAttack;
    public int LastAttackNumber => lastAttackNumber;
    public float ComboTimeFrame => comboTimeFrame;

    public event Action OnAttack;

    public void Attack(int attackNumber)
    {
        timeSinceLastAttack = 0f;
        lastAttackNumber = attackNumber;

        player.Audio.Play("player_attack");
        OnAttack?.Invoke();
        StartCoroutine(HitboxActivationCoroutine(attackNumber - 1));
    }

    private IEnumerator HitboxActivationCoroutine(int hitboxIndex)
    {
        hitboxes[hitboxIndex].SetActive(true);

        yield return new WaitForSeconds(hitboxDurations[hitboxIndex]);

        hitboxes[hitboxIndex].SetActive(false);
    }

    private void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
    }
}
