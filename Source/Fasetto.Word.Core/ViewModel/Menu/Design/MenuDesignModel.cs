using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    public class MenuDesignModel : MenuViewModel
    {

        public static MenuDesignModel Instance => new MenuDesignModel();

        public MenuDesignModel()
        {
            Items = new List<MenuItemViewModel>(new[]
            { 
                new MenuItemViewModel{Type = MenuItemType.Header,Text = "Design Header"},
                new MenuItemViewModel{Text = "Test 1", Icon = IconType.File},
                new MenuItemViewModel{Text = "Test 2", Icon = IconType.Picture},
            });
        }
    }
}
