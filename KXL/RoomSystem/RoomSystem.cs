using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

namespace KXL.RoomSystem
{
    using Core;
    using Core.Enumerations;

    public static class RoomSystem
    {
        public static string NextRoomSpawn = "RIGHT";
        static CanvasGroup ScreenCover;

        static float ScreenFadeInTime = 1f;
        static float ScreenFadeOutTime = 1f;

        public static void Warp(string TargetScene, string TargetSpawn) {
            UpdateGroupsManager.instance.SetGroupState(UpdateGroupName.Player, false);
            UpdateGroupsManager.instance.SetGroupState(UpdateGroupName.World, false);
            NextRoomSpawn = TargetSpawn;
            FadeOutScreen(ScreenFadeOutTime, () => { SceneManager.LoadScene(TargetScene); });
        }

        public static void SetScreenCover(CanvasGroup screenCover) {
            ScreenCover = screenCover;
        }

        public static void FadeOutScreen(float time, TweenCallback callback) {
            var sq = DOTween.Sequence();
            sq.Append(ScreenCover.DOFade(1f, time));
            sq.AppendCallback(callback);
        }

        public static void FadeInScreen(TweenCallback callback) {
            var sq = DOTween.Sequence();
            sq.Append(ScreenCover.DOFade(0f, ScreenFadeInTime));
            sq.AppendCallback(callback);
        }

        public static void SetScreenFade(float value) {
            ScreenCover.alpha = value;
        }
    }
}