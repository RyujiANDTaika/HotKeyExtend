using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

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
                    Properties.Settings.Default.Upgrade();
                }
            }
            public int[,] screenBlockStatus
            {
                get
                {
                    return Properties.Settings.Default.screenBlockStatus;
                }
                set
                {
                    Properties.Settings.Default.screenBlockStatus = value;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Upgrade();
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
        
        public void startService()
        {
            
        }

        public void stopService()
        {

        }

        public void initialSettings()
        {
            Properties.Settings.Default.switchStatus = false;
            Properties.Settings.Default.screenBlockStatus = new int[8, 4] {
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0}
            };
            Properties.Settings.Default.Save();
        }
    }
}
