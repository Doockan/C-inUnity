using UnityEngine;
using System.Collections;
namespace Geekbrains
{
    public sealed class PlayerBall : Player
    {
        private void FixedUpdate()
        {
            Move();
        }
        public void ChangeSpeed(float time, float force)
        {
            Speed *= force;
            StartCoroutine(ReturnSpeed(time, force));
        }

        private IEnumerator ReturnSpeed(float time, float force)
        {
            yield return new WaitForSeconds(time);
            Speed /= force;
        }
    }
}
