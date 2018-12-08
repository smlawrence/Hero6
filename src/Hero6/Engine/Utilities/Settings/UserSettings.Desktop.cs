﻿// <copyright file="UserSettings.Desktop.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

#if DESKTOPGL
namespace LateStartStudio.Hero6.Engine.Utilities.Settings
{
    using System.IO;
    using Newtonsoft.Json;

    public class UserSettings : IUserSettings
    {
        private static readonly string Filename = $"{Game.UserFilesDir}.usersettings.json";
        private UserSettingsData data;

        public UserSettings()
        {
            if (File.Exists(Filename))
            {
                data = JsonConvert.DeserializeObject<UserSettingsData>(File.ReadAllText(Filename));
            }
            else
            {
                data = new UserSettingsData();
            }

            GameStartedCount++;
            Save();
        }

        public bool IsFullScreen
        {
            get { return data.IsFullScreen; }
            set { data.IsFullScreen = value; }
        }

        public int WindowWidth
        {
            get { return data.WindowWidth; }
            set { data.WindowWidth = value; }
        }

        public int WindowHeight
        {
            get { return data.WindowHeight; }
            set { data.WindowHeight = value; }
        }

        public int GameStartedCount
        {
            get { return data.GameStartedCount; }
            private set { data.GameStartedCount = value; }
        }

        public void Save() => File.WriteAllText(Filename, JsonConvert.SerializeObject(data));

        public void Reset()
        {
            File.Delete(Filename);
            data = new UserSettingsData();
            GameStartedCount++;
            Save();
        }

        private class UserSettingsData
        {
            public bool IsFullScreen { get; set; } = false;

            public int WindowWidth { get; set; } = 960;

            public int WindowHeight { get; set; } = 720;

            public int GameStartedCount { get; set; } = 0;
        }
    }
}
#endif
