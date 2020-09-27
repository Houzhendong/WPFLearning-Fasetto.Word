using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// Helpers for the <see cref="SecureString"/>
    /// </summary>
    public static class SecureStringHelpers
    {

        /// <summary>
        /// unsecure a <see cref="SecureString"/> to plain text
        /// </summary>
        /// <param name="secureString">the secure string</param>
        /// <returns></returns>
        public static string Unsecure(this SecureString secureString)
        {
            if (secureString == null)
                return string.Empty;

            var unmanagedString = IntPtr.Zero;

            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
