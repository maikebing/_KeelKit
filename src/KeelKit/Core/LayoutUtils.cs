using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace KeelKit.Core
{
    internal sealed class LayoutUtils
    {
        // Methods
        private LayoutUtils()
        {
        }

        public static int GetPreferredCheckBoxHeight(CheckBox checkBox)
        {
            return GetPreferredHeight(checkBox, checkBox.UseCompatibleTextRendering, checkBox.Width);
        }

        private static int GetPreferredHeight(Control c, bool useCompatibleTextRendering, int requiredWidth)
        {
            using (Graphics graphics = Graphics.FromHwnd(c.Handle))
            {
                if (useCompatibleTextRendering)
                {
                    return graphics.MeasureString(c.Text, c.Font, c.Width).ToSize().Height;
                }
                return TextRenderer.MeasureText(graphics, c.Text, c.Font, new Size(requiredWidth, 0x7fffffff), TextFormatFlags.WordBreak).Height;
            }
        }

        public static int GetPreferredLabelHeight(Label label)
        {
            return GetPreferredLabelHeight(label, label.Width);
        }

        public static int GetPreferredLabelHeight(Label label, int requiredWidth)
        {
            return GetPreferredHeight(label, label.UseCompatibleTextRendering, requiredWidth);
        }

        public static void MirrorControl(Control c)
        {
            c.Left = ((c.Parent.Right - c.Parent.Padding.Left) - c.Margin.Left) - c.Width;
            if (((c.Anchor & AnchorStyles.Left) == AnchorStyles.None) || ((c.Anchor & AnchorStyles.Right) == AnchorStyles.None))
            {
                c.Anchor &= ~AnchorStyles.Left;
                c.Anchor |= AnchorStyles.Right;
            }
        }

        public static void MirrorControl(Control c, Control pivot)
        {
            c.Left = pivot.Right - c.Width;
            if (((c.Anchor & AnchorStyles.Left) == AnchorStyles.None) || ((c.Anchor & AnchorStyles.Right) == AnchorStyles.None))
            {
                c.Anchor &= ~AnchorStyles.Left;
                c.Anchor |= AnchorStyles.Right;
            }
        }

        public static void UnmirrorControl(Control c)
        {
            c.Left = (c.Parent.Left + c.Parent.Padding.Left) + c.Margin.Left;
            if (((c.Anchor & AnchorStyles.Left) == AnchorStyles.None) || ((c.Anchor & AnchorStyles.Right) == AnchorStyles.None))
            {
                c.Anchor &= ~AnchorStyles.Right;
                c.Anchor |= AnchorStyles.Left;
            }
        }

        public static void UnmirrorControl(Control c, Control pivot)
        {
            c.Left = pivot.Left;
            if (((c.Anchor & AnchorStyles.Left) == AnchorStyles.None) || ((c.Anchor & AnchorStyles.Right) == AnchorStyles.None))
            {
                c.Anchor &= ~AnchorStyles.Right;
                c.Anchor |= AnchorStyles.Left;
            }
        }
    }


}
