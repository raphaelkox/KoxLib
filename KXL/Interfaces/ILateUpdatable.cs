using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.Interfaces
{
    public interface ILateUpdatable : IRegistrable
    {
        void OnLateUpdate();
    }
}
