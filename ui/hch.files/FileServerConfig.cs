using System;
using System.Collections.Generic;

namespace hch.files
{
    public class FileServerConfig
    {
        public List<FileConfig> Configs { get; set; }
    }

    public class FileConfig
    {
        public string FType { get; set; }

        public string FileServerLocal { get; set; }

        public string[]  AllowedExt { get; set; }

        public long Size { get; set; }

        public int Count { get; set; }
    }
}
