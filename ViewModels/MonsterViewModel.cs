using System.Runtime.CompilerServices;

namespace Deez_Notes_Dm.ViewModels
{
    public class MonsterViewModel : ViewModelBase
    {
        protected void SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            OnPropertyChanged(propertyName);
        }

        private string damageVulnerabilities;
        public string DamageVulnerabilities
        {
            get => damageVulnerabilities;
            set => SetField(ref damageVulnerabilities, value);
        }

        private string damageResistances;
        public string DamageResistances
        {
            get => damageResistances;
            set => SetField(ref damageResistances, value);
        }

        private string damageImmunities;
        public string DamageImmunities
        {
            get => damageImmunities;
            set => SetField(ref damageImmunities, value);
        }

        private string conditionImmuniuties;
        public string ConditionImmuniuties
        {
            get => conditionImmuniuties;
            set => SetField(ref conditionImmuniuties, value);
        }
    }
}
