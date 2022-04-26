using MottMac.SnapperCoding.Model;


namespace MottMac.SnapperCoding.Processor
{
    public static class SnapperFactory
    {
        /// <summary>
        /// Snapper Factory
        /// </summary>
        /// <param name="snapObjectval"></param>
        /// <returns></returns>
        public static SnapperObject<string> SnapperFactoryMethod(string snapObjectval)
        {
           SnapperObject<string> _snapObject = new SnapperObject<string>();
            _snapObject.Data = snapObjectval;
            return _snapObject;

        }

    }
}
