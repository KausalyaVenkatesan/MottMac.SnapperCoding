using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MottMac.SnapperCoding.Processor
{

	public  class ReadSnapperFile
	{

		public int len;

		public List<string> SnapReadder(string fileName)
		{
			StreamReader br = null;
			FileInfo fi = new FileInfo(fileName);
			FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
			List<string> arrStrList = new List<string>();
		   try
		   {

                #region Read File into string List
                 br = new StreamReader(fs);
				   string str;
				   while (!string.ReferenceEquals((str = br.ReadLine()), null))
				   {
					arrStrList.Add(str);
				   }
				#endregion

				len = arrStrList.Count;
				return arrStrList;
		   }
			
		   catch (FileNotFoundException ex)
		   {
			   Console.WriteLine(ex.ToString());
			   Console.Write(ex.StackTrace);
		   }
		   catch (IOException ex)
		   {
			   Console.WriteLine(ex.ToString());
			   Console.Write(ex.StackTrace);
		   }
			catch(Exception ex)
            {
				Console.WriteLine(ex.ToString());
				Console.Write(ex.StackTrace);
			}

			finally
			{

				if (br != null)
				{
					br.Close();
				}

			}
			return null;

		}


	}

}