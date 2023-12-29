﻿using System;
namespace myServerBattleNet
{
	public class DictionaryExtensions
	{
        public static Dictionary<string, string> _dictOfExtenshions = new()
        {
            [".css"] = "text/css",
            [".html"] = "text/html",
            [".jpg"] = "image/jpeg",
            [".svg"] = "image/svg+xml",
            [".png"] = "image/png"
        };
    }
}

