using System;
using System.Collections.Generic;

namespace M3U_List_Checker
{
    class Program
    {
        private static string InputFilePath;
        private static string OutputFilePath;
        private static List<Channel> WorkingChannels = new List<Channel>();
        static void Main(string[] args)
        {
            Console.WriteLine("M3U File Checker");
            Console.WriteLine("By: Brendan McShane");
            //input path:
            if (args.Length < 1)
            {
                Console.WriteLine("Input File Path:");
                InputFilePath = Console.ReadLine().ToString();
            } else
            {
                InputFilePath = args[0];
            }
            Console.WriteLine("Input File Path: " + InputFilePath);
            //output path:
            if (args.Length < 2)
            {
                Console.WriteLine("Output File Path:");
                OutputFilePath = Console.ReadLine().ToString();
            }
            else
            {
                OutputFilePath = args[1];
            }
            Console.WriteLine("Output File Path: " + OutputFilePath);
            Console.WriteLine("Checking...");

            //Create list for channels:
            List<Channel> ChannelList = FileManager.ParseFile(InputFilePath);

            //Check each chan
            foreach(Channel chan in ChannelList)
            {
                if (Check.ExistanceCheck(chan.url))
                {
                    WorkingChannels.Add(chan);
                }
            }

            FileManager.WriteChannels(WorkingChannels, OutputFilePath);

            Console.WriteLine("Done.");
            Console.WriteLine(Check.excludedChans + " Channels excluded.");

        }
    }
}
