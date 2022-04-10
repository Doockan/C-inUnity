using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Geekbrains
{
    public class Mine : InteractiveObject, IFlay, IRotation, ICloneable
    {
        private float _lengthFlay;
        private float _speedRotation;
        private GameObject _player;
        private HealthController _health;

        [SerializeField] private float _damage;

        private void Awake()
        {
            _lengthFlay = Random.Range(1.0f, 3.0f);
            _speedRotation = Random.Range(10.0f, 50.0f);
            _player = GameObject.FindGameObjectWithTag("Player");
            _health = _player.GetComponent<HealthController>();
        }

        protected override void Interaction()
        {
            _health.ApplyDamage(_damage);
            Debug.Log($"HP - {_health.CurrentHealth}");
        }

        void IFlay.Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }

        //....
        public object Clone()
        {
            var result = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
            return result;
        }
    }
}