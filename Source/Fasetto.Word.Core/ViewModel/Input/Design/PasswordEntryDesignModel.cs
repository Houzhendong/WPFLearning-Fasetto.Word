namespace Fasetto.Word.Core
{
    /// <summary>
    /// Details for a message box dialog
    /// </summary>
    public class PasswordEntryDesignModel : PasswordEntryViewModel
    {
        public static PasswordEntryDesignModel Instance => new PasswordEntryDesignModel();

        public PasswordEntryDesignModel()
        {
            Label = "Name";
            FakePassword = "fake-design";
        }
    }
}
