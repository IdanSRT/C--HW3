using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ProgramTesting
    {
        public static void Main()
        {
            try{
                Exception ex = new Exception();
                ValueOutOfRangeException vl = new ValueOutOfRangeException(ex, 1, 2);
                throw vl;
            }
            catch(ValueOutOfRangeException ex){
                Console.WriteLine("catch");
            }
            //    Exception ex = new Exception();
            //    FindInFileException vl = new FindInFileException(ex, "", "");
            //    throw vl;


        }

        //public class FindInFileException : Exception
        //{
        //    private string m_FilePath;
        //    public string FilePath
        //    {
        //        get { return m_FilePath; }
        //    }

        //    private string m_Word;
        //    public string Word
        //    {
        //        get { return m_Word; }
        //    }

        //    public FindInFileException(Exception i_InnerException, string i_Word, string i_FilePath)
        //        // sending two params to the base CTOR:
        //        : base(string.Format("An error occured while trying to find the word {0} in file {1}", i_Word, i_FilePath),
        //        i_InnerException)
        //    { }
        //}
    }
}
