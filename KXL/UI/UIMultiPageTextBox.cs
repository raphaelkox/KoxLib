using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.UI
{
    [AddComponentMenu("KXL/UI/Multi Page TextBox")]
    public class UIMultiPageTextBox : UITextBox
    {
        public event Action<int> OnPageChange;
        public event Action OnPastLastPage;

        public int Pages { get; private set; }

        public override void SetText(string text) {
            base.SetText(text);
            Pages = GetPageCount(TextObj.text);
        }

        public void SetPage(int page) {
            Debug.Log($"Setting page to {page}");

            if (page > Pages) {
                Debug.Log("Past Last Page!");
                OnPastLastPage?.Invoke();
                page = Pages;
            }

            if (page < 1) page = 1;

            TextObj.pageToDisplay = page;
            OnPageChange?.Invoke(page);
        }

        public int GetPage() {
            return TextObj.pageToDisplay;
        }

        public void NextPage() {
            Debug.Log("Next Page!");
            SetPage(TextObj.pageToDisplay + 1);
        }

        public void PreviousPage() {
            SetPage(TextObj.pageToDisplay - 1);
        }

        public int GetPageCount(string text) {
            return TextObj.GetTextInfo(text).pageCount;
        }
    }
}
