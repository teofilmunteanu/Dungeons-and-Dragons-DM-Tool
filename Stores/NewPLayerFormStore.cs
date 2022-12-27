using System;

namespace Deez_Notes_Dm.Stores
{
    public class NewPLayerFormStore
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
            //reset inputs
            IsOpen = true;
        }

        private void OnIsOpenChanged()
        {
            IsOpenChanged?.Invoke();
        }
    }
}
