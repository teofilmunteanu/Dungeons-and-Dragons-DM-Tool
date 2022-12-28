using Deez_Notes_Dm.Commands;
using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.Stores;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Deez_Notes_Dm.ViewModels
{
    public class NewPlayerFormViewModel : ViewModelBase
    {
        //add and bind data - watch 3rd video from SingletonSean
        protected void SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            OnPropertyChanged(propertyName);
        }

        private string name;
        public string Name
        {
            get => name;
            set => SetField(ref name, value);
        }

        private string race;
        public string Race
        {
            get => race;
            set => SetField(ref race, value);

        }

        private string mainClass;
        public string MainClass
        {
            get => mainClass;
            set => SetField(ref mainClass, value);
        }

        private string hp;
        public string HP
        {
            get => hp;
            set => SetField(ref hp, value);
        }

        private string ac;
        public string AC
        {
            get => ac;
            set => SetField(ref ac, value);
        }

        private string speed;
        public string Speed
        {
            get => speed;
            set => SetField(ref speed, value);
        }

        private string flySpeed;
        public string FlySpeed
        {
            get => flySpeed;
            set => SetField(ref flySpeed, value);
        }

        private string _str;
        public string STR
        {
            get => _str;
            set => SetField(ref _str, value);
        }

        private string _dex;
        public string DEX
        {
            get => _dex;
            set => SetField(ref _dex, value);
        }

        private string _con;
        public string CON
        {
            get => _con;
            set => SetField(ref _con, value);
        }

        private string _int;
        public string INT
        {
            get => _int;
            set => SetField(ref _int, value);
        }

        private string _wis;
        public string WIS
        {
            get => _wis;
            set => SetField(ref _wis, value);
        }

        private string _cha;
        public string CHA
        {
            get => _cha;
            set => SetField(ref _cha, value);
        }

        private bool insightProficiency;
        public bool InsightProficiency
        {
            get => insightProficiency;
            set => SetField(ref insightProficiency, value);
        }

        private bool perceptionProficiency;
        public bool PerceptionProficiency
        {
            get => perceptionProficiency;
            set => SetField(ref perceptionProficiency, value);
        }

        private bool investigationProficiency;
        public bool InvestigationProficiency
        {
            get => investigationProficiency;
            set => SetField(ref investigationProficiency, value);
        }


        public ICommand CancelCommand { get; }
        public ICommand CreateCommand { get; }

        public NewPlayerFormViewModel(PlayersManager playersManager, NewPLayerFormStore newPLayerFormStore)
        {
            CancelCommand = new CancelPlayerFormCommand(this, newPLayerFormStore);
            CreateCommand = new CreatePlayerCommand(this, playersManager);
        }
    }
}
