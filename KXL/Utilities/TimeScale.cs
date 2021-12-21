using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.Utilities
{
    using Core;
    using Input = UnityEngine.Input;

    public class TimeScale : CustomBehaviour
    {
        [SerializeField] float MinTimescale = 0.2f;
        [SerializeField] float MaxTimescale = 1f;

        // Update is called once per frame
        public override void OnUpdate() {
            if (Input.GetKey(KeyCode.Tab)) {
                Time.timeScale = MinTimescale;
            }
            else {
                Time.timeScale = MaxTimescale;
            }
        }
    }
}