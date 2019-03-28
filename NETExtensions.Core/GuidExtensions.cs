using System;
namespace System
{
    public static class GuidExtensions
    {
        /// <summary>
        /// Check if the guid is not null and not equal to Guid.Empty.
        /// </summary>
        /// <returns><c>true</c>, if valid, <c>false</c> otherwise.</returns>
        /// <param name="guid">GUID.</param>
        public static bool IsValid(this Guid guid)
        {
            return guid != null && guid != Guid.Empty;
        }

        /// <summary>
        /// Check if the guid is null or equal to Guid.Empty.
        /// </summary>
        /// <returns><c>true</c>, if not valid was ised, <c>false</c> otherwise.</returns>
        /// <param name="guid">GUID.</param>
        public static bool IsNotValid(this Guid guid)
        {
            return !guid.IsValid();
        }
    }
}
