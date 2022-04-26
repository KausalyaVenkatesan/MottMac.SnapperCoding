using MottMac.SnapperCoding.Model;
using System.Collections.Generic;
using MottMac.SnapperCoding.Common;

namespace MottMac.SnapperCoding.Processor
{
   
    public class ScanSnapperFiles
    {
        List<SnapperData> snapperInfo = null;

        /// <summary>
        /// Scan ProcessSnapper for multiple input file for a source file
        /// </summary>
        /// <param name="inputFileNames"></param>
        /// <param name="source2D"></param>
        /// <exception cref="SnapperException"></exception>
        public void ProcessSnapperScan(string[] inputFileNames, List<string> source2D)
        {
            try
            {

                for (int i = 0; i < inputFileNames.Length; i++)
                {
                    #region Compare Snapper Object
                    List<string> target2D = SnapperFactory.SnapperFactoryMethod(inputFileNames[i]).GetObject();
                    SnapperFactory.SnapperFactoryMethod(inputFileNames[i]).DisplayObject();
                    int ntMatchCount = CompareSnapper(source2D, target2D, inputFileNames[i]);
                    #endregion

                    #region Print Scan Output 
                    PrintData.PrintLine();
                    PrintData.PrintWriteLine("Default Indication of Confident >= " + Constants.ConfidenceThreshold * 100 + "%");
                    PrintData.PrintWriteLine(inputFileNames[i] + " Target(s) Found : " + ntMatchCount + " Records");
                    PrintData.PrintWriteLine("");

                    PrintConsoleOutput();
                    #endregion
                }

            }
            catch (SnapperException e)
            {
                PrintData.PrintWriteLine(e.ToString());
                PrintData.PrintWriteLine(e.StackTrace);
                throw new SnapperException(e.Message);
            }


        }


        /// <summary>
        /// Compare source and targer snapper object
        /// </summary>
        /// <param name="src"></param>
        /// <param name="tar"></param>
        /// <param name="targetFileName"></param>
        /// <returns></returns>
        private int CompareSnapper(List<string> src, List<string> tar, string targetFileName)
        {
            #region Variable Declaration 
            snapperInfo = new List<SnapperData>();

            int testImgRows = src.Count;
            int testImgCols = src[0].Length;
            int found = 0;

            int targetImgRows = tar.Count;
            int targetImgCols = tar[0].Length;
            float fullMatch = targetImgRows * targetImgCols;
            float matchCount = 0, confidence = 0;
            #endregion

            #region Compare Snapper using matrix

            for (int drow = 0; drow <= testImgRows - targetImgRows; drow++)
            {
                for (int dcol = 0; dcol <= testImgCols - targetImgCols; dcol++)
                {
                    matchCount = 0;
                    for (int tr = 0; tr < targetImgRows; tr++)
                    {
                        for (int tc = 0; tc < targetImgCols; tc++)
                        {
                            if (tar[tr][tc] == src[drow + tr][dcol + tc])
                            {
                                ++matchCount;
                            }
                        }
                    }
                    #endregion

            #region Calculate Confidence and add it to list for print console purpose
                    confidence = matchCount / fullMatch;
                    if (confidence >= Constants.ConfidenceThreshold)
                    {

                        snapperInfo.Add(new SnapperData
                        {
                            TargetFileName = targetFileName,
                            RowPos = drow,
                            ColPos = dcol,
                            IndicatorConfidence = confidence
                        });
                        found++;
                    }
                    #endregion

                }
            }
            return found;
        }

        /// <summary>
        /// PrintConsoleOutput
        /// </summary>
        private void PrintConsoleOutput()
        {
            #region Print Scan Object
            PrintData.PrintLine();
            PrintData.PrintRow("Target Name", "Row Position", "Column Position", "Coordinates", "Match %");
            PrintData.PrintLine();
            for (int i = 0; i <= snapperInfo.Count - 1; i++)
            {
                PrintData.PrintRow(snapperInfo[i].TargetFileName, snapperInfo[i].RowPos.ToString(), snapperInfo[i].ColPos.ToString(),
                    snapperInfo[i].ColPos.ToString() + "." + snapperInfo[i].RowPos.ToString(),
                    (snapperInfo[i].IndicatorConfidence * 100).ToString());
            }
            PrintData.PrintLine();
            PrintData.PrintWriteLine("\n");
            PrintData.PrintLine('*');
            #endregion
        }
    }

}



