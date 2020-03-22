using System;
using System.Collections.Generic;
using System.Text;

namespace M3U_List_Checker
{
    class Channel
    {
        public Channel(string header, string url)
        {
            this.header = header;
            this.url = url;
        }
        public string header;
        public string url;
    }
}