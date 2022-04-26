using MottMac.SnapperCoding.Common;
using MottMac.SnapperCoding.Processor;
using System;
using System.Collections.Generic;

namespace MottMac.SnapperCoding
{
    /// <summary>
    /// To find the targets Torpedo and Starship in the given target data
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                #region Process Snapper Scanning
                ScanSnapperFiles scanner = new ScanSnapperFiles();
                List<string> source2D = SnapperFactory.SnapperFactoryMethod(Constants.TestShape).GetObject();
                string[] inputFileNames = new string[] { Constants.NuclearTorpedo, Constants.Starship };
                scanner.ProcessSnapperScan(inputFileNames, source2D);
                #endregion

                Console.ReadLine();
            }
            catch (SnapperException e)
            {
                PrintData.PrintWriteLine(e.ToString());
                PrintData.PrintWriteLine(e.StackTrace);
                throw new SnapperException(e.Message);
            }

        }
    }
}
