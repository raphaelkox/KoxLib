using UnityEngine;

namespace KXL.Input
{
using Core;

[AddComponentMenu("KXL/Input/Menu Input Consumer")]
public class MenuInputConsumer : MonoBehaviour
{
[SerializeField] CustomBehaviour consumer;

[SerializeField] bool Up;
[SerializeField] bool Down;
[SerializeField] bool Left;
[SerializeField] bool Right;
[SerializeField] bool Cancel;
[SerializeField] bool Confirm;

private void OnEnable() {
if (Up) {
MenuInputGroup.RegisterUpConsumer(consumer);
}
if (Down) {
MenuInputGroup.RegisterDownConsumer(consumer);
}
if (Left) {
MenuInputGroup.RegisterLeftConsumer(consumer);
}
if (Right) {
MenuInputGroup.RegisterRightConsumer(consumer);
}
if (Cancel) {
MenuInputGroup.RegisterCancelConsumer(consumer);
}
if (Confirm) {
MenuInputGroup.RegisterConfirmConsumer(consumer);
}
}
}
}