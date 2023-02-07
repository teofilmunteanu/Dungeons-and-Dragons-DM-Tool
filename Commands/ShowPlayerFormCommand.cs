using Deez_Notes_Dm.API_Managers;
using Deez_Notes_Dm.Json_DTOs;
using Deez_Notes_Dm.Stores;
using System.Collections.Generic;
using System.Windows;

namespace Deez_Notes_Dm.Commands
{
    public class ShowPlayerFormCommand : CommandBase
    {
        private readonly NewPLayerFormStore _newPLayerFormStore;

        public ShowPlayerFormCommand(NewPLayerFormStore newPLayerFormStore)
        {
            this._newPLayerFormStore = newPLayerFormStore;
        }

        public async override void Execute(object? parameter)
        {
            _newPLayerFormStore.Open();

            //testing monsters api
            List<MonsterDTO> m = await MonsterAPI.GetMonsterAsync("goblin");
            MessageBox.Show(m[0].name);
        }
    }
}
