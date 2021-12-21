namespace KXL.Input
{
using Core;

public static partial class InputManager
{
static bool Registered = false;

public static void Setup() {
if (!Registered) {
UpdateGroupsManager.OnPlayerInputUpdate += PlayerInputGroup.OnUpdate;
UpdateGroupsManager.OnMenuInputUpdate += MenuInputGroup.OnUpdate;
Registered = true;
}
}
}
}