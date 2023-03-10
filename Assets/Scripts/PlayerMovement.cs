using UnityEngine;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float speed;
        private Rigidbody rbPlayer;
        void Awake()
        {
            rbPlayer = GetComponent<Rigidbody>();
        }
        public void MoveCharacter(Vector3 movement)
        {
            rbPlayer.AddForce(movement * speed);
        }
        public void StopPlayer()
        {
            Vector3 currentVelocity = rbPlayer.velocity;
            Vector3 force = -currentVelocity * rbPlayer.mass / Time.fixedDeltaTime;
            rbPlayer.AddForce(force);
        }
#if UNITY_EDITOR
        [ContextMenu("ResetValues")]
        public void ResetValues()
        {
            speed = 2;
        }
#endif
    }

}

