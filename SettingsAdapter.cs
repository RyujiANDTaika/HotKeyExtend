﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace HotkeyExtend
{
    class SettingsAdapter
    {
        private static Service service;
        public SettingsAdapter(Service serviceInstance)
        {
            service = serviceInstance;
        }
        public SettingsAdapter()
        {

        }
        public class Settings
        {
            public bool switchStatus
            {
                get
                {
                    return Properties.Settings.Default.switchStatus;
                }
                set
                {
                    Properties.Settings.Default.switchStatus = value;
                    Properties.Settings.Default.Save();
                }
            }
            public int[] screenBlockStatus
            {
                get
                {
                    if (Properties.Settings.Default.screenBlockStatus == null)
                        return null;
                    return (int[])Properties.Settings.Default.screenBlockStatus.ToArray(typeof(int));
                }
                set
                {
                    ArrayList arrayList = new ArrayList(value);
                    Properties.Settings.Default.screenBlockStatus = arrayList;
                    Properties.Settings.Default.Save();
                    service.updateService();
                }
            }

            public List<string> searchText
            {
                get
                {
                    if (Properties.Settings.Default.searchText == null)
                        return null;
                    return new List<string>((string[])Properties.Settings.Default.searchText.ToArray(typeof(string)));
                }
                set
                {
                    ArrayList arrayList = new ArrayList(value);
                    Properties.Settings.Default.searchText = arrayList;
                    Properties.Settings.Default.Save();
                    service.updateService();
                }
            }

            public List<bool> searchTextStatus
            {
                get
                {
                    if (Properties.Settings.Default.searchTextStatus == null)
                        return null;
                    return new List<bool>((bool[])Properties.Settings.Default.searchTextStatus.ToArray(typeof(bool)));
                }
                set
                {
                    ArrayList arrayList = new ArrayList(value);
                    Properties.Settings.Default.searchTextStatus = arrayList;
                    Properties.Settings.Default.Save();
                    service.updateService();
                }
            }
        }

        public Settings settings { get; } = new Settings();
        

        public void initialSettings()
        {
            Properties.Settings.Default.screenBlockStatus = new ArrayList {
                0,0,0,0,
                0,0,0,0,
                0,0,0,0,
                0,0,0,0,
                0,0,0,0,
                0,0,0,0,
                0,0,0,0,
                0,0,0,0,
            };
            Properties.Settings.Default.Save();
        }
    }
}
