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
        public void GetSlow(float slowTime, float slowSpeed)
        {
            StartCoroutine(Slow(slowTime, slowSpeed));
        }

        private IEnumerator Slow(float slowTime, float slowSpeed)
        {
            yield return new WaitForSeconds(slowTime);
            Speed /= slowSpeed;
        }
    }
}
