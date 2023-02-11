using System;

namespace Deez_Notes_Dm.Stores
{
    public class CombatSelectionStore
    {
        public bool isOpen = false;
        public bool IsOpen
        {
            get => isOpen;
            set
            {
                isOpen = value;
                OnIsOpenChanged();
            }
        }
        public event Action IsOpenChanged;

        public void Close()
        {
            IsOpen = false;
        }

        public void Open()
        {
            IsOpen = true;
        }

        private void OnIsOpenChanged()
        {
            IsOpenChanged?.Invoke();
        }
    }
}
