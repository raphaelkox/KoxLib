using System;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.Core
{
using Enumerations;
using Interfaces;

public static class UpdateGroupsManager
{
private static Dictionary<UpdateGroup, bool> UpdateGroupsActive = new Dictionary<UpdateGroup, bool>() {
{UpdateGroup.PlayerInput, false},
{UpdateGroup.MenuInput, false},
{UpdateGroup.Default, true},
{UpdateGroup.World, true},
{UpdateGroup.PlayerMovement, false},
{UpdateGroup.PlayerAttack, false},
};

private static Dictionary<UpdateGroup, bool> UpdateGroupsActiveNext = new Dictionary<UpdateGroup, bool>() {
{UpdateGroup.PlayerInput, false},
{UpdateGroup.MenuInput, false},
{UpdateGroup.Default, true},
{UpdateGroup.World, true},
{UpdateGroup.PlayerMovement, false},
{UpdateGroup.PlayerAttack, false},
};

public static bool IsGroupActive(UpdateGroup group) {
return UpdateGroupsActive[group];
}
public static void SetUpdateGroupState(UpdateGroup group, bool state) {
UpdateGroupsActiveNext[group] = state;
}

public static event Action OnPlayerInputUpdate;
public static event Action OnMenuInputUpdate;
public static event Action OnDefaultUpdate;
public static event Action OnWorldUpdate;
public static event Action OnPlayerMovementUpdate;
public static event Action OnPlayerAttackUpdate;

public static void OnUpdate() {
if (UpdateGroupsActive[UpdateGroup.PlayerInput]) {
OnPlayerInputUpdate?.Invoke();
}
if (UpdateGroupsActive[UpdateGroup.MenuInput]) {
OnMenuInputUpdate?.Invoke();
}
if (UpdateGroupsActive[UpdateGroup.Default]) {
OnDefaultUpdate?.Invoke();
}
if (UpdateGroupsActive[UpdateGroup.World]) {
OnWorldUpdate?.Invoke();
}
if (UpdateGroupsActive[UpdateGroup.PlayerMovement]) {
OnPlayerMovementUpdate?.Invoke();
}
if (UpdateGroupsActive[UpdateGroup.PlayerAttack]) {
OnPlayerAttackUpdate?.Invoke();
}

var keys = new List<UpdateGroup>(UpdateGroupsActive.Keys);
foreach (var key in keys) {
UpdateGroupsActive[key] = UpdateGroupsActiveNext[key];
}
}

public static void RegisterUpdateConsumer(IUpdatable consumer, UpdateGroup group) {
switch (group) {
case UpdateGroup.PlayerInput:
OnPlayerInputUpdate += consumer.OnUpdate;
break;
case UpdateGroup.MenuInput:
OnMenuInputUpdate += consumer.OnUpdate;
break;
case UpdateGroup.Default:
OnDefaultUpdate += consumer.OnUpdate;
break;
case UpdateGroup.World:
OnWorldUpdate += consumer.OnUpdate;
break;
case UpdateGroup.PlayerMovement:
OnPlayerMovementUpdate += consumer.OnUpdate;
break;
case UpdateGroup.PlayerAttack:
OnPlayerAttackUpdate += consumer.OnUpdate;
break;
default:
break;
}
}

public static void UnregisterUpdateConsumer(IUpdatable consumer, UpdateGroup group) {
switch (group) {
case UpdateGroup.PlayerInput:
OnPlayerInputUpdate -= consumer.OnUpdate;
break;
case UpdateGroup.MenuInput:
OnMenuInputUpdate -= consumer.OnUpdate;
break;
case UpdateGroup.Default:
OnDefaultUpdate -= consumer.OnUpdate;
break;
case UpdateGroup.World:
OnWorldUpdate -= consumer.OnUpdate;
break;
case UpdateGroup.PlayerMovement:
OnPlayerMovementUpdate -= consumer.OnUpdate;
break;
case UpdateGroup.PlayerAttack:
OnPlayerAttackUpdate -= consumer.OnUpdate;
break;
default:
break;
}
}

public static event Action OnPlayerInputLateUpdate;
public static event Action OnMenuInputLateUpdate;
public static event Action OnDefaultLateUpdate;
public static event Action OnWorldLateUpdate;
public static event Action OnPlayerMovementLateUpdate;
public static event Action OnPlayerAttackLateUpdate;

public static void OnLateUpdate() {
if (UpdateGroupsActive[UpdateGroup.PlayerInput]) {
OnPlayerInputLateUpdate?.Invoke();
}
if (UpdateGroupsActive[UpdateGroup.MenuInput]) {
OnMenuInputLateUpdate?.Invoke();
}
if (UpdateGroupsActive[UpdateGroup.Default]) {
OnDefaultLateUpdate?.Invoke();
}
if (UpdateGroupsActive[UpdateGroup.World]) {
OnWorldLateUpdate?.Invoke();
}
if (UpdateGroupsActive[UpdateGroup.PlayerMovement]) {
OnPlayerMovementLateUpdate?.Invoke();
}
if (UpdateGroupsActive[UpdateGroup.PlayerAttack]) {
OnPlayerAttackLateUpdate?.Invoke();
}
}

public static void RegisterLateUpdateConsumer(ILateUpdatable consumer, UpdateGroup group) {
switch (group) {
case UpdateGroup.PlayerInput:
OnPlayerInputLateUpdate += consumer.OnLateUpdate;
break;
case UpdateGroup.MenuInput:
OnMenuInputLateUpdate += consumer.OnLateUpdate;
break;
case UpdateGroup.Default:
OnDefaultLateUpdate += consumer.OnLateUpdate;
break;
case UpdateGroup.World:
OnWorldLateUpdate += consumer.OnLateUpdate;
break;
case UpdateGroup.PlayerMovement:
OnPlayerMovementLateUpdate += consumer.OnLateUpdate;
break;
case UpdateGroup.PlayerAttack:
OnPlayerAttackLateUpdate += consumer.OnLateUpdate;
break;
default:
break;
}
}

public static void UnregisterLateUpdateConsumer(ILateUpdatable consumer, UpdateGroup group) {
switch (group) {
case UpdateGroup.PlayerInput:
OnPlayerInputLateUpdate -= consumer.OnLateUpdate;
break;
case UpdateGroup.MenuInput:
OnMenuInputLateUpdate -= consumer.OnLateUpdate;
break;
case UpdateGroup.Default:
OnDefaultLateUpdate -= consumer.OnLateUpdate;
break;
case UpdateGroup.World:
OnWorldLateUpdate -= consumer.OnLateUpdate;
break;
case UpdateGroup.PlayerMovement:
OnPlayerMovementLateUpdate -= consumer.OnLateUpdate;
break;
case UpdateGroup.PlayerAttack:
OnPlayerAttackLateUpdate -= consumer.OnLateUpdate;
break;
default:
break;
}
}
}
}