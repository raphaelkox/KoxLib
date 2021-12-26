using UnityEngine;

namespace KXL.Input
{
using Core;

[AddComponentMenu("KXL/Input/Player Input Consumer")]
public class PlayerInputConsumer : MonoBehaviour
{
[SerializeField] KXLBehaviour consumer;

[SerializeField] bool Up;
[SerializeField] bool Down;
[SerializeField] bool Left;
[SerializeField] bool Right;
[SerializeField] bool Attack1;
[SerializeField] bool Attack2;
[SerializeField] bool Attack3;
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
if (Attack1) {
PlayerInputGroup.RegisterAttack1Consumer(consumer);
}
if (Attack2) {
PlayerInputGroup.RegisterAttack2Consumer(consumer);
}
if (Attack3) {
PlayerInputGroup.RegisterAttack3Consumer(consumer);
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