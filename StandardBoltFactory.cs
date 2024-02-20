namespace InvAddIn
{
    internal class StandardBoltFactory : IBoltFactory
    {
        public IBolt CreateBolt(double diameter, double length, double threadDepth, double threadPitch)
        {
            return new StandardBolt(diameter, length, threadDepth, threadPitch);
        }
    }
}
