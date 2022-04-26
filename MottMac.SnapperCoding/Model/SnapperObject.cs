using MottMac.SnapperCoding.Common;
using System;
using System.Collections.Generic;
using System.IO;
using SnapperReader = MottMac.SnapperCoding.Processor.ReadSnapperFile;

namespace MottMac.SnapperCoding.Model
{
    public class SnapperObject<T>
    {
        public static List<string> shape;
        public static int len;
        public T Data { get; set; }

        public List<string> GetObject()
        {
            SetObject();
            PrintObject();
            return shape;
        }

        private void SetObject()
        {
            string fileFolder = System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();
            string fileName = Path.Combine(fileFolder, Constants.FileFolder, Data.ToString() + Constants.FileType);
            SnapperReader read = new SnapperReader();
            shape = read.SnapReadder(fileName);
            len = read.len;
        }

        public void DisplayObject()
        {
            PrintData.PrintWriteLine(Data.ToString() + " View");
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < shape[i].Length; j++)
                {
                    Console.Write(shape[i][j]);
                }
                Console.WriteLine("");
            }
        }

        private void PrintObject()
        {
            PrintData.PrintWriteLine("\n");
            PrintData.PrintWriteLine(Data.ToString() + " Information");
            PrintData.PrintLine();
            PrintData.PrintRow("File Name", "Row(s)", "Column(s)");
            PrintData.PrintLine();
            PrintData.PrintRow(Data.ToString() + Constants.FileType, shape.Count.ToString(), shape[0].Length.ToString());
            PrintData.PrintLine();
            PrintData.PrintWriteLine("\n");
        }
    }
}
