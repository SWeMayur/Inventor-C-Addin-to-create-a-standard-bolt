namespace InvAddIn
{
    /// <summary>
    /// Represents a factory for creating instances of the StandardBolt class.
    /// </summary>
    internal class StandardBoltFactory : IBoltFactory
    {
        /// <summary>
        /// Creates a new instance of the StandardBolt class with the specified parameters.
        /// </summary>
        /// <param name="diameter">The diameter of the bolt.</param>
        /// <param name="length">The length of the bolt.</param>
        /// <param name="threadDepth">The thread depth of the bolt.</param>
        /// <param name="threadPitch">The thread pitch of the bolt.</param>
        /// <returns>An instance of the IBolt interface representing a standard bolt.</returns>
        public IBolt CreateBolt(double diameter, double length, double threadDepth, double threadPitch)
        {
            return new StandardBolt(diameter, length, threadDepth, threadPitch);
        }
    }
}
