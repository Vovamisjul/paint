using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace vovan2
{
    public class Config
    {
        public int width;
        public int height;
        public int color;
        public Config()
        {

        }
        public Config (int width, int height, Color color)
        {
            this.width = width;
            this.height = height;
            this.color = color.ToArgb();
        }
    }
}
