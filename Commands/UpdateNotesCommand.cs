using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.ViewModels;
using System;
using System.Windows;

namespace Deez_Notes_Dm.Commands
{
    public class UpdateMonsterNotesCommand : CommandBase
    {
        private readonly MonsterViewModel _monsterViewModel;
        private readonly MonstersManager _monstersManager;

        public UpdateMonsterNotesCommand(MonsterViewModel monsterViewModel, MonstersManager monstersManager)
        {
            _monsterViewModel = monsterViewModel;
            _monstersManager = monstersManager;
        }


        public override void Execute(object? parameter)
        {
            try
            {
                _monstersManager.SetNotesToMonsterWithId(_monsterViewModel.ID, _monsterViewModel.Notes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
