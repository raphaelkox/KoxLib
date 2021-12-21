using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KXL.UI
{
    [AddComponentMenu("KXL/UI/Vertical List")]
    public class UIVerticalList : UIList
    {
        VerticalLayoutGroup layoutGroup;

        private void Start() {
            layoutGroup = ListRoot.GetComponent<VerticalLayoutGroup>();
        }

        protected override float GetPaddingStart() {
            return layoutGroup.padding.top;
        }

        protected override float GetPaddingEnd() {
            return layoutGroup.padding.bottom;
        }

        protected override float GetSpacing() {
            return layoutGroup.spacing;
        }

        protected override void OnSizeChange() {
            UIVerticalListItem listItem = ListItem.GetComponent<UIVerticalListItem>();

            var sizeX = ListRoot.sizeDelta.x;
            var sizeY = GetPaddingStart() + (itemCount * listItem.GetItemSize()) + (itemCount * GetSpacing()) + GetPaddingEnd();

            Vector2 sizeDelta = new Vector2(sizeX, sizeY);

            RaiseOnContentSizeDeltaChangedEvent(sizeDelta);
        }
    }
}
