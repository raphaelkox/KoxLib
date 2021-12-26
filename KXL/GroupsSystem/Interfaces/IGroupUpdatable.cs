using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.GroupsSystem.Interfaces
{
    using KXL.Core.Interfaces;

    public interface IGroupUpdatable : IUpdatable, IRegistrable
    {
        void CallUpdate();
    }
}
