using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace HotkeyExtend
{
    class ServiceCtrl
    {
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
                    ArrayList arrayList = new ArrayList();
                    foreach(int i in value)
                    {
                        arrayList.Add(i);
                    }
                    Properties.Settings.Default.screenBlockStatus = arrayList;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private Settings settingsInstance = new Settings();

        public Settings settings
        {
            get
            {
                return settingsInstance;
            }
        }

        public bool serviceStatus;
        
        public void startService()
        {
            serviceStatus = true;
        }

        public void stopService()
        {
            serviceStatus = false;
        }

        public class blockStatus
        {
            public bool status { get; set; }
            public int wheelIndex { get; set; }
            public int wheelDownIndex { get; set; }
            public int stayIndex { get; set; }
            public blockStatus()
            {
                status = false;
                wheelIndex = 0;
                wheelDownIndex = 0;
                stayIndex = 0;
            }
        }

        public void initialSettings()
        {
            //Properties.Settings.Default.switchStatus = false;
            Properties.Settings.Default.screenBlockStatus = new ArrayList {
                new blockStatus(),
                new blockStatus(),
                new blockStatus(),
                new blockStatus(),
                new blockStatus(),
                new blockStatus(),
                new blockStatus(),
                new blockStatus(),
            };
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
