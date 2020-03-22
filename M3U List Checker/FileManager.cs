using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace M3U_List_Checker
{
    class FileManager
    {
        private static List<Channel> ChannelList = new List<Channel>();
        public static List<Channel> ParseFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string[] lines = File.ReadAllLines(path);
                    string lastLine = "";
                    foreach(string line in lines)
                    {
                        if (line.Length>0 && line[0] != '#' && (line[0]=='h' || line[0] == 'H'))
                        {
                            Channel chan = new Channel(lastLine, line);
                            ChannelList.Add(chan);
                        } else
                        {
                            lastLine = line;
                        }
                    }
                    return ChannelList;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading file:");
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public static void WriteChannels(List<Channel> chans, string path)
        {
            List<String> output = new List<String>();
            output.Add("#EXTM3U");
            foreach (Channel chan in chans)
            {
                output.Add(chan.header);
                output.Add(chan.url);
            }

            System.IO.File.WriteAllLines(path, output.ToArray());
        }
        public static List<Channel> getList()
        {
            return ChannelList;
        }
    }
}
