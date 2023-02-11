using Deez_Notes_Dm.Json_DTOs;
using Deez_Notes_Dm.Models;
using Deez_Notes_Dm.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace Deez_Notes_Dm.Commands
{
    public class SearchMonsterCommand : CommandBase
    {
        private readonly CombatSelectionViewModel _combatSelectionViewModel;
        private readonly MonstersManager _monstersManager;

        public SearchMonsterCommand(CombatSelectionViewModel combatSelectionViewModel, MonstersManager monstersManager)
        {
            _combatSelectionViewModel = combatSelectionViewModel;
            _monstersManager = monstersManager;

            _combatSelectionViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(PlayerViewModel.HP_Input))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            bool HasSearchTerm = !string.IsNullOrEmpty(_combatSelectionViewModel.SearchInput);

            return HasSearchTerm && base.CanExecute(parameter);
        }

        public async override void Execute(object? parameter)
        {
            try
            {
                string monsterToSearch = _combatSelectionViewModel.SearchInput;

                List<MonsterDTO> monstersData = await _monstersManager.GetMonstersDataAsync(monsterToSearch);
                List<string> monsterNames = new List<string>();

                foreach (MonsterDTO monster in monstersData)
                {
                    monsterNames.Add(monster.name);
                }

                _combatSelectionViewModel.FoundMonsters = monsterNames;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
