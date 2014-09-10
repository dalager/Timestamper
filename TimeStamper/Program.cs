using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeStamper
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.Out.WriteLine("pass the path to the directory with the files to timestamp");
                return;
            }
            var path = args[0];

            var di = new DirectoryInfo(path);
            if (!di.Exists)
            {
                Console.Out.WriteLine("directory does not exist");
                return;
            }
            var fileInfos = di.GetFiles().OrderBy(x=>x.Name);
            var startDate = new DateTime(2010, 1, 1);
            foreach (var fileInfo in fileInfos)
            {
//                Console.Out.WriteLine(fileInfo.Name + " : "+ fileInfo.CreationTime);
                fileInfo.CreationTime = startDate;
                fileInfo.LastWriteTime = startDate;
                startDate = startDate.AddDays(-1);
            }

            Console.Out.WriteLine("{0} Files timestamped",fileInfos.Count());
            Console.Out.WriteLine("Any key. Any.");
            Console.ReadLine();
        }
    }
}
