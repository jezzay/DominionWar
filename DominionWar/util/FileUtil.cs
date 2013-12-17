#region Copyright

// Created by Jeremy 
// 09 2013

#endregion

using System;
using System.IO;

namespace Dominion_War.util
{
    public class FileUtil
    {
        public static StreamReader ReadFile(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new Exception(filename + " file not found");
            }
            return new StreamReader(filename);
        }
    }
}