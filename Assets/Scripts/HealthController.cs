using System.Collections;
using UnityEngine;


namespace Geekbrains
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] 
        private float _maxHealth;

        private bool _immortal = false;

        public float CurrentHealth;

        public void Awake()
        {
            CurrentHealth = _maxHealth;
        }

        public void ApplyDamage(float damage)
        {
            if (!_immortal)
            {
                CurrentHealth -= damage;
                Debug.Log($"Damage -> {damage}");
                Debug.Log($"HP - {CurrentHealth}");
            }
        }

        public void Immortal(float time)
        {
            _immortal = true;
            Debug.Log($"IMMORTAL for {time} sec!!!!");
            StartCoroutine(Mortal(time));
        }

        private IEnumerator Mortal(float time)
        {
            yield return new WaitForSeconds(time);
            _immortal = false;
            Debug.Log("immortal lost...");
        }
    }
}
