using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MouseKeyboardActivityMonitor.WinApi;
using MouseKeyboardActivityMonitor;
using System.Windows.Forms;

namespace TestDotNetProject
{
    public class Main
    {
        private NodeJSWrapper hook = new NodeJSWrapper();

        public async Task<object> AddEvents(IDictionary<string, object> events)
        {
            Console.WriteLine("Hello?");

            var onMouseMove = events["onMouseMove"] as Func<object, Task<object>>;
            var testTimer = new System.Threading.Timer(o => {
                onMouseMove(new { simulated = true });
            }, null, 0, 500);
            
            return hook;
        }
        

    }

    public class NodeJSWrapper
    {
        public Hooker hook;
        public KeyboardHookListener keyboardHook;
        public MouseHookListener mouseHook;

        public NodeJSWrapper()
        {
            hook = new GlobalHooker();
            keyboardHook = new KeyboardHookListener(hook);
            mouseHook = new MouseHookListener(hook);
        }

        public void OnKeyPress(KeyPressEventHandler handler)
        {
            keyboardHook.KeyPress += handler;
            keyboardHook.Enabled = true;
        }
        public void OnMouseMove(MouseEventHandler handler)
        {
            mouseHook.MouseMove += handler;
            mouseHook.Enabled = true;
        }
    }
}
