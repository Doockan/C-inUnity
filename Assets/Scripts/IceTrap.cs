using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Geekbrains
{
    public class IceTrap : InteractiveObject, IFlay, IRotation, ICloneable
    {
        private float _lengthFlay;
        private float _speedRotation;
        private GameObject _player;
        private PlayerBall _playerScript;
        private Rigidbody _rbPlayer;

        [SerializeField] 
        private float _slowTime;

        [SerializeField]
        private float _slowSpeed;

        private void Awake()
        {
            _lengthFlay = Random.Range(1.0f, 3.0f);
            _speedRotation = Random.Range(10.0f, 50.0f);
            _player = GameObject.FindGameObjectWithTag("Player");
            _playerScript = _player.GetComponent<PlayerBall>();
            _rbPlayer = _player.GetComponent<Rigidbody>();
        }

        protected override void Interaction()
        {
            _rbPlayer.velocity = new Vector3(0, 0, 0);
            _playerScript.ChangeSpeed(_slowTime, _slowSpeed);            
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
