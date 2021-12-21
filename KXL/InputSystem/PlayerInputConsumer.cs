using UnityEngine;

namespace KXL.Input
{
    using Core;

    [AddComponentMenu("KXL/Input/Player Input Consumer")]
    public class PlayerInputConsumer : MonoBehaviour
    {
        [SerializeField] CustomBehaviour consumer;

        [SerializeField] bool Up;
        [SerializeField] bool Down;
        [SerializeField] bool Left;
        [SerializeField] bool Right;
        [SerializeField] bool Jump;
        [SerializeField] bool Interact;
        [SerializeField] bool Menu;

        private void OnEnable() {
            if (Up) {
                PlayerInputGroup.RegisterUpConsumer(consumer);
            }
            if (Down) {
                PlayerInputGroup.RegisterDownConsumer(consumer);
            }
            if (Left) {
                PlayerInputGroup.RegisterLeftConsumer(consumer);
            }
            if (Right) {
                PlayerInputGroup.RegisterRightConsumer(consumer);
            }
            if (Jump) {
                PlayerInputGroup.RegisterJumpConsumer(consumer);
            }
            if (Interact) {
                PlayerInputGroup.RegisterInteractConsumer(consumer);
            }
            if (Menu) {
                PlayerInputGroup.RegisterMenuConsumer(consumer);
            }
        }
    }
}