using Deez_Notes_Dm.Stores;

namespace Deez_Notes_Dm.Commands
{
    public class ShowCombatSelectionCommand : CommandBase
    {
        private readonly CombatSelectionStore _combatSelectionStore;

        public ShowCombatSelectionCommand(CombatSelectionStore combatSelectionStore)
        {
            this._combatSelectionStore = combatSelectionStore;
        }

        //async
        public override void Execute(object? parameter)
        {
            _combatSelectionStore.Open();

            //testing monsters api
            //List<MonsterDTO> m = await MonsterAPI.GetMonsterAsync("goblin");
            //MessageBox.Show(m[0].name);
        }
    }
}
