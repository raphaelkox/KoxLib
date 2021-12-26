using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.GroupsSystem.Interfaces
{
    using KXL.Core.Interfaces;

    public interface IGroupFixedUpdatable : IFixedUpdatable, IRegistrable
    {
        void CallFixedUpdate();
    }
}
