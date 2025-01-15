using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystemService : MonoBehaviour
{
   [SerializeField] private int _health;

   private static int _maxHealth = 3;

   private static int _minHealth = 1;
    
   [SerializeField] private HeartsPanel _heartsPanel;

    private void Awake()
    {
        _health = _maxHealth;
        ResetHealth();
    }

    private void OnEnable()
    {
        EventService.OnTakeDamage += TakeDamage;
        ResetHealth();
    }
    private void OnDisable()
    {
        EventService.OnTakeDamage -= TakeDamage;
        ResetHealth();
    }

    public int GetHealth()
    {
        return _health;
    }
    public void TakeDamage()
    {
        if (_health==_minHealth)
        {
            StartCoroutine(DeathRoutine());
        }
        ReduceHealth();
        Debug.Log("Health : " + _health);
    }

    public void ReduceHealth()
    {
        _health--;
        _heartsPanel.ReduceHearts();
    }

    public void ResetHealth()
    {
        _health = _maxHealth;
        _heartsPanel.ResetHearts();
    }

    private IEnumerator DeathRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        EventService.CallOnLevelLose();
    }

}
