using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Geekbrains
{
    public class Immortal : InteractiveObject, IFlay, IFlicker
    {
        private Material _material;
        private float _lengthFlay;

        private GameObject _player;
        private PlayerBall _playerScript;
        private HealthController _health;


        [SerializeField]
        private float _immortalTime;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Random.Range(1.0f, 5.0f);
            _player = GameObject.FindGameObjectWithTag("Player");
            _playerScript = _player.GetComponent<PlayerBall>();
            _health = _player.GetComponent<HealthController>();

        }

        protected override void Interaction()
        {
            _health.Immortal(_immortalTime);
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }
    }
}
