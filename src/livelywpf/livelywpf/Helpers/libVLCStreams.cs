﻿using Octokit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace livelywpf
{
    public static class libVLCStreams
    {
        public static bool CheckStream(Uri uri)
        {
            bool status = false;
            var luaPlaylistPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "libvlc", "win-x86", "lua", "playlist");
            if(!Directory.Exists(luaPlaylistPath))
            {
                status = false;
            }

            string host;
            string url;
            try
            {
                url = uri.ToString();
                host = uri.Host;
            }
            catch
            {
                return false;
            }
            
            switch (host)
            {
                case "www.youtube.com":
                    if(url.Contains("youtube.com/watch?v="))
                        status = File.Exists(Path.Combine(luaPlaylistPath, "youtube.luac"));
                    break;
                //todo: more
                default:
                    status = false;
                    break;
            }
            return status;
        }
    }
}
