using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.UI
{
    [AddComponentMenu("KXL/UI/Vertical Cursor")]
    public class UIVerticalCursor : UICursor
    {
        protected override void UpdatePosition() {
            var posX = rectTransform.anchoredPosition.x;
            var posY = -paddingStart - (currentOption * optionSize) - (currentOption * spacingSize) - (optionSize / 2);

            rectTransform.anchoredPosition = new Vector2(posX, posY);
        }
    }
}
