using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KXL.Input.Interfaces
{
    public interface IPlayerUpInputConsumer
    {
        public void HandleUpInputDown();
        public void HandleUpInputUp();
    }
}
