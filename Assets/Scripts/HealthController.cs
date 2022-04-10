using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Geekbrains
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] 
        private float _maxHealth;

        public float CurrentHealth;

        public void ApplyDamage(float damage)
        {
            CurrentHealth -= damage;
        }



        public void Start()
        {
            CurrentHealth = _maxHealth;
        }
    }
}
