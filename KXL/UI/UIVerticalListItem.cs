using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.UI
{
    [AddComponentMenu("KXL/UI/Vertical List Item")]
    public class UIVerticalListItem : UIListItem
    {
        [field: SerializeField] public RectTransform rectTransform;

        public override float GetItemSize() {
            return rectTransform.sizeDelta.y;
        }
    }
}
