using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.Interfaces
{
    public interface IContentFitEventProvider
    {
        public event Action<Vector2> OnContentSizeDeltaChanged;
    }
}
