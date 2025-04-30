using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace something
{
    public class DwmHelper
    {
        // DWM API imports
        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        private static extern int DwmIsCompositionEnabled(out bool pfEnabled);

        // Margins structure
        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int cxLeftWidth;
            public int cxRightWidth;
            public int cyTopHeight;
            public int cyBottomHeight;

            public MARGINS(int left, int right, int top, int bottom)
            {
                cxLeftWidth = left;
                cxRightWidth = right;
                cyTopHeight = top;
                cyBottomHeight = bottom;
            }
        }

        public static void EnableDwm(IntPtr handle)
        {
            // Check if DWM is enabled
            bool isEnabled;
            DwmIsCompositionEnabled(out isEnabled);
            if (isEnabled)
            {
                // Extend the frame into the client area
                MARGINS margins = new MARGINS(0, 0, 25, 0);
                DwmExtendFrameIntoClientArea(handle, ref margins);
            }
            else
            {
                MessageBox.Show("DWM is not enabled on this system.");
            }
        }
    }
}