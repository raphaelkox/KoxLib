using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.UI
{
    public abstract class UIList : UIElement
    {
        [field: SerializeField]public GameObject ListItem { get; set; }
        [field: SerializeField]public RectTransform ListRoot { get; set; }

        protected int itemCount;

        public GameObject AddItem() {
            var newItem = Instantiate(ListItem, ListRoot);
            itemCount++;
            return newItem;
        }

        public virtual void Clear() {
            foreach (Transform child in ListRoot.transform) {
                Destroy(child.gameObject);
            }
            itemCount = 0;
        }

        protected virtual void OnSizeChange() {
        }

        protected abstract float GetSpacing();
        protected abstract float GetPaddingStart();
        protected abstract float GetPaddingEnd();
    }
}
