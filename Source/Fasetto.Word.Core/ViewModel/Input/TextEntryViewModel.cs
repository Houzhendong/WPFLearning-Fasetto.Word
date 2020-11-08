using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// the view model for a text entry to edit a string value
    /// </summary>
    public class TextEntryViewModel : BaseViewModel
    {
        public TextEntryViewModel()
        {
            EditCommand = new RelayCommand(Edit);
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
        }

        #region Pulic Properties

        /// <summary>
        /// The label to identify what this value is for 
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// the current saved value
        /// </summary>
        public string OriginalText { get; set; }

        /// <summary>
        /// the current non-commit edit text
        /// </summary>
        public string EditedText { get; set; }

        /// <summary>
        /// indicates if the current text is in edit mode
        /// </summary>
        public bool Editing { get; set; }
        #endregion

        #region Public Commands

        public ICommand EditCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public ICommand SaveCommand { get; set; }
        #endregion

        #region Command Methods

        public void Edit()
        {
            EditedText = OriginalText;

            Editing = true; 
        }

        public void Cancel()
        {
            Editing = false;
        }

        public void Save()
        {
            //TODO: Save content
            OriginalText = EditedText;

            Editing = false;
        }
        #endregion
    }
}
