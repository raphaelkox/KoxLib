using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.GroupsSystem
{
    public class BaseGroup<TName> where TName : Enum
    {
        public TName GroupName;

        public bool ActiveState;
        public bool NextActiveState;

        public void UpdateActiveState() {
            ActiveState = NextActiveState;
        }
    }
}