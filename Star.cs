using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Figure;

namespace vovan2 {
    [Serializable]
    class Star : IFigure
    {
        public string name { get; set; }
        public int x1 { get; set; }
        public int x2 { get; set; }
        public int y1 { get; set; }
        public int y2 { get; set; }
        public Star()
        {
            name = "Star";
        }
        public void draw(int x1, int y1, int x2, int y2, Graphics graphics)
        {
            Pen pen = new Pen(Color.Black);
            graphics.DrawLine(pen, (x1 + x2) / 2, y1, x1 + (x2 - x1) * 2 / 3, y1 + (y2 - y1) / 3);
            graphics.DrawLine(pen, x1 + (x2 - x1) * 2 / 3, y1 + (y2 - y1) / 3, x2, y1 + (y2 - y1) / 3);
            graphics.DrawLine(pen, (x1 + x2) / 2, y1, x1 + (x2 - x1) / 3, y1 + (y2 - y1) / 3);
            graphics.DrawLine(pen, x1 + (x2 - x1) / 3, y1 + (y2 - y1) / 3, x1, y1 + (y2 - y1) / 3);
            graphics.DrawLine(pen, x2, y1 + (y2 - y1) / 3, x1 + (x2 - x1) * 3 / 4, y1 + (y2 - y1) * 2 / 3);
            graphics.DrawLine(pen, x1, y1 + (y2 - y1) / 3, x1 + (x2 - x1) / 4, y1 + (y2 - y1) * 2 / 3);
            graphics.DrawLine(pen, x1 + (x2 - x1) * 3 / 4, y1 + (y2 - y1) * 2 / 3, x1 + (x2 - x1) * 4 / 5, y2);
            graphics.DrawLine(pen, x1 + (x2 - x1) / 4, y1 + (y2 - y1) * 2 / 3, x1 + (x2 - x1) / 5, y2);
            graphics.DrawLine(pen, x1 + (x2 - x1) / 5, y2, (x1 + x2) / 2, y1 + (y2 - y1) * 3 / 4);
            graphics.DrawLine(pen, x1 + (x2 - x1) * 4 / 5, y2, (x1 + x2) / 2, y1 + (y2 - y1) * 3 / 4);
        }

        public IFigure build()
        {
            return new Star();
        }
    }
}
