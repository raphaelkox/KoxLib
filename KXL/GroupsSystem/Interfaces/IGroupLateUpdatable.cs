using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.GroupsSystem.Interfaces
{
    using KXL.Core.Interfaces;

    public interface IGroupLateUpdatable : ILateUpdatable, IRegistrable
    {
        void CallLateUpdate();
    }
}
