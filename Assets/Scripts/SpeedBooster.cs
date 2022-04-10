using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Geekbrains
{
    public class SpeedBooster : InteractiveObject, IFlay, IFlicker
    {
        private Material _material;
        private float _lengthFlay;

        private GameObject _player;
        private PlayerBall _playerScript;

        [SerializeField]
        private float _boostTime;

        [SerializeField]
        private float _boostSpeed;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Random.Range(1.0f, 5.0f);
            _player = GameObject.FindGameObjectWithTag("Player");
            _playerScript = _player.GetComponent<PlayerBall>();
        }

        protected override void Interaction()
        {
            _playerScript.ChangeSpeed(_boostTime, _boostSpeed);
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
