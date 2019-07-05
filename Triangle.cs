using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Figure;

namespace vovan2 {
    [Serializable]
    class Triangle : IFigure
    {
        public string name { get; set; }
        public int x1 { get; set; }
        public int x2 { get; set; }
        public int y1 { get; set; }
        public int y2 { get; set; }
        public Triangle()
        {
            name = "Triangle";
        }
        public void draw(int x1, int y1, int x2, int y2, Graphics graphics)
        {
            Pen pen = new Pen(Color.Black);
            graphics.DrawLine(pen, x1, y2, (x1 + x2) / 2, y1);
            graphics.DrawLine(pen, x1, y2, x2, y2);
            graphics.DrawLine(pen, x2, y2, (x1 + x2) / 2, y1);
        }

        public IFigure build()
        {
            return new Triangle();
        }
    }
}
