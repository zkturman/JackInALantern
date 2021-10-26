using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICombatCharacter
{
    public int Health { get; set; }
    public int Strength { get; set; }
    public void SpawnAction();
    public void AttackAction();
    public void DefendAction();
    public void FallAction();
    public void DrownAction();
    public void DieAction();
    public void TakeDamage(int damageTaken);
    public void IncreaseHealth(int healthGiven);
}
