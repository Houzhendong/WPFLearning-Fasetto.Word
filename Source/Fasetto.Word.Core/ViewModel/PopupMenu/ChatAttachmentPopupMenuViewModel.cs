using Fasetto.Word.Core;
using System.CodeDom;

namespace Fasetto.Word
{
    public class ChatAttachmentPopupMenuViewModel : BasePopupViewModel 
    {

        public ChatAttachmentPopupMenuViewModel()
        {
            Content = new MenuViewModel
            {
                Items = new System.Collections.Generic.List<MenuItemViewModel>(new[]
                {
                    new MenuItemViewModel{Text = "Attach a file...",Type = MenuItemType.Header},
                    new MenuItemViewModel {Text = "From Computer", Icon = IconType.File},
                    new MenuItemViewModel {Text = "From Pictures", Icon = IconType.Picture},
                })
            };
        }
    }
}
