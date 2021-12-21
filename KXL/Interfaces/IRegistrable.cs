using System;

namespace KXL.Interfaces
{
    public interface IRegistrable
    {
        public event Action<IRegistrable> OnDisableEvent;
        public event Action<IRegistrable> OnDestroyEvent;
    }
}
