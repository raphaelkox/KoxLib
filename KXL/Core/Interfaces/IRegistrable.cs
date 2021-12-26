using System;

namespace KXL.Core.Interfaces
{
    public interface IRegistrable
    {
        public event Action<IRegistrable> OnDisableEvent;
        public event Action<IRegistrable> OnDestroyEvent;
    }
}
