using UnityEngine;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerInput : MonoBehaviour
    {
        private Vector3 movement;
        private PlayerMovement playerMovement;
        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }
        void Update()
        {
            float horizontal = Input.GetAxis(GlobalStringVar.HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(GlobalStringVar.VERTICAL_AXIS);

            movement = new Vector3(vertical, 0, -horizontal).normalized; 
        }
        private void FixedUpdate()
        {
            playerMovement.MoveCharacter(movement);
        }
    }
}
