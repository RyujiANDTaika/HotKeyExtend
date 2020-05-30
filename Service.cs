using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotkeyExtend
{
    class Service
    {
        public bool serviceStatus;
        public static Hook hook = new Hook();
        public static MouseService mouseService = new MouseService();
        public static KeyboardService KeyboardService = new KeyboardService();

        public void start()
        {
            serviceStatus = true;
            loadService();
            hook.Start();
        }

        public void stop()
        {
            serviceStatus = false;
            unloadService();
            hook.Stop();
        }

        public void loadService()
        {
            hook.mouseService += mouseService.mouseMsgReceiver;
            hook.keyboardService += KeyboardService.keyboardMsgReceiver;
            updateService();
        }

        public void unloadService()
        {
            hook.mouseService -= mouseService.mouseMsgReceiver;
            hook.keyboardService -= KeyboardService.keyboardMsgReceiver;
        }

        public void updateService()
        {
            mouseService.updateService();
            KeyboardService.updateService();
        }
    }
}
