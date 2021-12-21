using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KXL.UI
{
    [AddComponentMenu("KXL/UI/Horizontal Bar")]
    public class UIHorizontalBar : UIBar
    {
        [field: SerializeField] public bool ReverseDirection { get; set; }

        // Start is called before the first frame update
        protected override void Start() {
            base.Start();

            BarObj.fillMethod = Image.FillMethod.Horizontal;
            BarObj.fillOrigin = ReverseDirection ? 1 : 0;
        }
    }
}
