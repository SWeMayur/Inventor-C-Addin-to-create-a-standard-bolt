
namespace InvAddIn
{
    /// <summary>
    /// Represents an interface for creating bolts in an Inventor application.
    /// </summary>
    internal interface IBolt
    {
        /// <summary>
        /// Creates a bolt using the specified Inventor application.
        /// </summary>
        /// <param name="inventorApplication">The Inventor application instance.</param>
        void Create(Inventor.Application inventorApplication);
    }
}
