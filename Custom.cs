using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Figure;

namespace vovan2
{
    [Serializable]
    class Custom : IFigure
    {

        private List<IFigure> components;
        private int width;
        private int height;
        public string name { get; set; }
        public int x1 { get; set; }
        public int x2 { get; set; }
        public int y1 { get; set; }
        public int y2 { get; set; }
        public Custom(string name, List<IFigure> components, int width, int height)
        {
            this.name = name;
            this.components = components;
            this.width = width;
            this.height = height;
        }
        public Custom()
        {
            this.name = "Custom";
        }
        public void draw(int x1, int y1, int x2, int y2, Graphics graphics)
        {
            Pen pen = new Pen(Color.Black);
            foreach(IFigure component in components)
            {
                component.draw(x1 + (x2 - x1) * component.x1 / width, y1 + (y2 - y1) * component.y1 / height, x1 + (x2 - x1) * component.x2 / width, y1 + (y2 - y1) * component.y2 / height, graphics);
            }
        }

        public IFigure build()
        {
            var res = new Custom(name, components, width, height);
            res.x1 = x1;
            res.x2 = x2;
            res.y1 = y1;
            res.y2 = y2;
            return res;
        }
        public IFigure buildBuilder(string name, List<IFigure> components, int width, int height)
        {
            return new Custom(name, components, width, height);
        }
    }
}
