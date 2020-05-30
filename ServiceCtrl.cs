using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotkeyExtend
{
    class ServiceCtrl
    {
        public struct settings
        {
            public bool switchStatus
            {
                get
                {
                    return Properties.Settings.Default.switchStatus;
                }
            }
            public int[,] screenBlockStatus
            {
                get
                {
                    return Properties.Settings.Default.screenBlockStatus;
                }
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
