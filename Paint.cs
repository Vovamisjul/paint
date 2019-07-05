using System;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel;
using System.Data;
using System.Xml;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Xml.Linq;
using Figure;

namespace vovan2 {

    public partial class Paint : Form {

        Color bgColor = Color.White;
        int fig, x1, y1;
        List<IFigure> builders;
        List<IFigure> figureslist;
        Custom custombuilder = new Custom();
        bool pressed;
        Bitmap bmp;
        Graphics g;
        bool isPtr;
        int selectedInd;
        int prevX, prevY;
        int sizing;
        const int border = 21;
        const int startHeight = 112;
        public Paint()
        {
            InitializeComponent();

            builders = new List<IFigure>()
            {
                new Line(),
                new Rect(),
                new Ellipse(),
                new Triangle(),
                new Hex(),
                new Star()
            };

            LoadAssemblies();

            LoadCustomFigures();

            figureslist = new List<IFigure>();
            pressed = false;
            fig = 0;
            foreach (IFigure i in builders)
                comboBox.Items.Add(i.name);
            comboBox.SelectedIndex = 0;
            bmp = new Bitmap(pictureBox.Width, pictureBox.Height);

            g = Graphics.FromImage(bmp);
            isPtr = false;
            prevX = 0;
            prevY = 0;
            selectedInd = -1;
            sizing = -1;
            redrawAll();
        }
        private void redrawAll()
        {
            g.Clear(bgColor);
            foreach (IFigure fig in figureslist)
                fig.draw(fig.x1, fig.y1, fig.x2, fig.y2, g);
            if (selectedInd!=-1 && figureslist.Count!=0)
            {
                Pen pen = new Pen(Color.Black);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                IFigure selected = figureslist[selectedInd];
                if (selected.x2 > selected.x1)
                {
                    if (selected.y2 > selected.y1)
                        g.DrawRectangle(pen, selected.x1 - 5, selected.y1 - 5, selected.x2 - selected.x1 + 10, selected.y2 - selected.y1 + 10);
                    else
                        g.DrawRectangle(pen, selected.x1 - 5, selected.y2 - 5, selected.x2 - selected.x1 + 10, selected.y1 - selected.y2 + 10);
                }
                else
                {
                    if (selected.y2 > selected.y1)
                        g.DrawRectangle(pen, selected.x2 - 5, selected.y1 - 5, selected.x1 - selected.x2 + 10, selected.y2 - selected.y1 + 10);
                    else
                        g.DrawRectangle(pen, selected.x2 - 5, selected.y2 - 5, selected.x1 - selected.x2 + 10, selected.y1 - selected.y2 + 10);
                }
            }

            pictureBox.Image = bmp;
        }

        private void defineCursor(int posX, int posY, IFigure figure)
        {
            pictureBox.Cursor = Cursors.Default;
            int dx=5, dy=5, x1, x2, y1, y2;
            if (figure.x2 > figure.x1)
            {
                x1 = figure.x1;
                x2 = figure.x2;
            }
            else
            {
                x1 = figure.x2;
                x2 = figure.x1;
            }
            if (figure.y2 > figure.y1)
            {
                y1 = figure.y1;
                y2 = figure.y2;
            }
            else
            {
                y1 = figure.y2;
                y2 = figure.y1;
            }
            if (posX < x1 && posX > x1 - dx || posX > x2 && posX < x2 + dx)
                pictureBox.Cursor = Cursors.SizeWE;
            if (posY < y1 && posY > y1 - dy || posY > y2 && posY < y2 + dy)
                pictureBox.Cursor = Cursors.SizeNS;
            if (posX < x1 && posX > x1 - dx && posY < y1 && posY > y1 - dy || posX > x2 && posX < x2 + dx && posY > y2 && posY < y2 + dy)
                pictureBox.Cursor = Cursors.SizeNWSE;
            if (posX < x1 && posX > x1 - dx && posY > y2 && posY < y2 + dy || posX > x2 && posX < x2 + dx && posY < y1 && posY > y1 - dy)
                pictureBox.Cursor = Cursors.SizeNESW;
        }
        private void defineSizing(int posX, int posY, IFigure figure)
        {
            sizing = -1;
            int dx = 5, dy = 5, x1, x2, y1, y2;
            if (figure.x2 > figure.x1)
            {
                x1 = figure.x1;
                x2 = figure.x2;
            }
            else
            {
                x1 = figure.x2;
                x2 = figure.x1;
            }
            if (figure.y2 > figure.y1)
            {
                y1 = figure.y1;
                y2 = figure.y2;
            }
            else
            {
                y1 = figure.y2;
                y2 = figure.y1;
            }
            if (posX < x1 && posX > x1 - dx)
                sizing = 0;
            if (posX > x2 && posX < x2 + dx)
                sizing = 1;
            if (posY < y1 && posY > y1 - dy)
                sizing = 2;
            if (posY > y2 && posY < y2 + dy)
                sizing = 3;
            if (posX < x1 && posX > x1 - dx && posY < y1 && posY > y1 - dy)
                sizing = 4;
            if (posX > x2 && posX < x2 + dx && posY < y1 && posY > y1 - dy)
                sizing = 5;
            if (posX < x1 && posX > x1 - dx && posY > y2 && posY < y2 + dy)
                sizing = 6;
            if (posX > x2 && posX < x2 + dx && posY > y2 && posY < y2 + dy)
                sizing = 7;
        }

        private void LoadAssemblies()
        {
            String PaintDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            String[] PaintAssemblies = Directory.GetFiles(PaintDir, "*.dll");
            List<Type> PaintTypes = new List<Type>();

            foreach (String file in PaintAssemblies)
            {
                try
                {
                    Assembly PaintAssembly = Assembly.LoadFrom(file);
                    foreach (Type t in PaintAssembly.GetExportedTypes())
                    {
                        if (t.IsClass && typeof(IFigure).IsAssignableFrom(t))
                            PaintTypes.Add(t);
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка при загрузке сборки");
                }
            }

            foreach (Type t in PaintTypes)
            {
                IFigure newFig = (IFigure)Activator.CreateInstance(t);
                builders.Add(newFig);
            }
        }

        private void LoadCustomFigures()
        {
            String PaintDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location); String[] CustimFigures = Directory.GetFiles(PaintDir, "*.fig");
            BinaryFormatter binFormat = new BinaryFormatter();

            foreach (String file in CustimFigures)
            {
                FileStream buffer = File.OpenRead(file);
                IFigure figure;
                try
                {
                    figure = binFormat.Deserialize(buffer) as Custom;
                    builders.Add(figure);
                }
                catch
                {
                    MessageBox.Show("Ошибка при загрузке пользовательской фигуры " + file);
                }
                buffer.Close();
            }
        }

        private void LoadConfig()
        {
            try
            {
                XDocument xDoc = XDocument.Load("config.xml");
                XElement config = xDoc.Element("config");
                XElement form = config.Element("form");
                XElement width = form.Element("width");
                XElement height = form.Element("height");
                XElement paint = config.Element("paint");
                XElement color = paint.Element("color");
                Width = Int32.Parse(width.Value);
                Height = Int32.Parse(height.Value);
                bgColor = Color.FromArgb(Int32.Parse(color.Value));
                redrawAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Paint");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }

        private void SaveConfig()
        {
            XDocument xDoc = new XDocument(
                new XElement("config",
                    new XElement("form",
                        new XAttribute("width", Width),
                        new XAttribute("height", Height)),
                    new XElement("paint",
                        new XElement("color", bgColor.ToArgb()))));
            xDoc.Save("config.xml");
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox.Focus();
            pressed = true;
            if (!isPtr)
            {
                figureslist.Add(builders[fig].build());
                x1 = e.X;
                y1 = e.Y;
                figureslist.Last().x1 = e.X;
                figureslist.Last().y1 = e.Y;
            }
            else
            {
                IFigure selected =null;
                Pen pen = new Pen(Color.Black);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                foreach (IFigure figure in figureslist)
                    if ((e.X > figure.x1-5 && e.X < figure.x2+5 || e.X < figure.x1+5 && e.X > figure.x2-5) && (e.Y > figure.y1-5 && e.Y < figure.y2+5 || e.Y < figure.y1+5 && e.Y > figure.y2-5))
                        selected = figure;
                if (selected != null)
                {
                    defineSizing(e.X, e.Y, selected);
                    selectedInd = figureslist.LastIndexOf(selected);
                }
                else
                    selectedInd = -1;
                redrawAll();
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox.Cursor = Cursors.Default;
            if (pressed)
            {
                pressed = false;
                if (!isPtr)
                {
                    figureslist.Last().x2 = e.X;
                    figureslist.Last().y2 = e.Y;
                    redrawAll();
                }
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            figureslist.Clear();
            redrawAll();
            selectedInd = -1;

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            saveDialog.Title = "Сохранить файл";
            saveDialog.Filter = "Paint файлы (*.pnt)|*.pnt";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = saveDialog.FileName;
                BinaryFormatter binFormat = new BinaryFormatter();
                FileStream buffer = File.Create(filename);
                binFormat.Serialize(buffer, figureslist);
                buffer.Close();
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDialog.Title = "Открыть новый файл";
            openDialog.Filter = "Paint файлы (*.pnt)|*.pnt";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openDialog.FileName;
                BinaryFormatter binFormat = new BinaryFormatter();
                figureslist.Clear();
                redrawAll();
                using (FileStream buffer = File.OpenRead(filename))
                {
                    try
                    {
                        figureslist = binFormat.Deserialize(buffer) as List<IFigure>;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка");
                    }
                }
                redrawAll();
            }
        }

        private void buttonPtr_Click(object sender, EventArgs e)
        {
            isPtr = true;
        }

        private void Paint_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FigName.Text == "")
            {
                MessageBox.Show("Введите название фигуры", "Paint");
                return;
            }
            if (builders.Exists(builder => builder.name == FigName.Text))
            {
                MessageBox.Show("Ошибка! Такая фигура уже существует", "Paint");
                return;
            }
            List<IFigure> temp = new List<IFigure>();
           
            foreach (IFigure fig in figureslist)
            {
                IFigure tempFig = fig.build();
                tempFig.x1 = fig.x1;
                tempFig.x2 = fig.x2;
                tempFig.y1 = fig.y1;
                tempFig.y2 = fig.y2;
                temp.Add(tempFig);
            }
            builders.Add(custombuilder.buildBuilder(FigName.Text, temp, this.Width, this.Height));
            comboBox.Items.Add(FigName.Text);
            FigName.Text = "";
            MessageBox.Show("Добавлено успешно", "Paint");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (fig == -1)
            {
                MessageBox.Show("Выберите фигуру для удаления", "Paint");
                return;
            }
            if (builders[fig].GetType() != custombuilder.GetType())
            {
                MessageBox.Show("Нельзя удалить фигуру, так как \n она является базовой", "Paint");
                return;
            }
            foreach (IFigure figure in figureslist)
                if (figure.GetType() == builders[fig].GetType())
                {
                    MessageBox.Show("Нельзя удалить фигуру, так как она\n используется в текущем рисунке", "Paint");
                    return;
                }
            builders.Remove(builders[fig]);
            comboBox.Items.Remove(comboBox.Items[fig]);
            MessageBox.Show("Фигура удалена", "Paint");
        }


        private void SaveCustomFigures()
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            foreach (IFigure builder in builders)
            {
                if (builder.GetType() == custombuilder.GetType())
                {
                    FileStream buffer = File.Create(builder.name + ".fig");
                    binFormat.Serialize(buffer, builder);
                    buffer.Close();
                }
            }
        }
        private void Paint_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveCustomFigures();
            SaveConfig();
        }

        private void btnBgColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                bgColor = colorDialog1.Color;
            }
            redrawAll();
        }

        private void Paint_Resize(object sender, EventArgs e)
        {
            pictureBox.Width = Width - 2 * border;
            pictureBox.Height = Height - startHeight;
            bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            g = Graphics.FromImage(bmp);
            redrawAll();
        }

        private void pictureBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (isPtr)
                {
                    figureslist.Remove(figureslist[selectedInd]);
                    selectedInd = -1;
                    redrawAll();
                }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (pressed)
            {
                if (!isPtr)
                {
                    figureslist.Last().x2 = e.X;
                    figureslist.Last().y2 = e.Y;
                    redrawAll();
                }
                else
                {
                    if (selectedInd != -1)
                    {
                        int x1, x2, y1, y2;
                        if (figureslist[selectedInd].x2 > figureslist[selectedInd].x1)
                        {
                            x1 = figureslist[selectedInd].x1;
                            x2 = figureslist[selectedInd].x2;
                        }
                        else
                        {
                            x1 = figureslist[selectedInd].x2;
                            x2 = figureslist[selectedInd].x1;
                        }
                        if (figureslist[selectedInd].y2 > figureslist[selectedInd].y1)
                        {
                            y1 = figureslist[selectedInd].y1;
                            y2 = figureslist[selectedInd].y2;
                        }
                        else
                        {
                            y1 = figureslist[selectedInd].y2;
                            y2 = figureslist[selectedInd].y1;
                        }
                        switch (sizing)
                        {
                            case 0:
                                x1 += e.X - prevX;
                                break;
                            case 1:
                                x2 += e.X - prevX;
                                break;
                            case 2:
                                y1 += e.Y - prevY;
                                break;
                            case 3:
                                y2 += e.Y - prevY;
                                break;
                            case 4:
                                x1 += e.X - prevX;
                                y1 += e.Y - prevY;
                                break;
                            case 5:
                                x2 += e.X - prevX;
                                y1 += e.Y - prevY;
                                break;
                            case 6:
                                x1 += e.X - prevX;
                                y2 += e.Y - prevY;
                                break;
                            case 7:
                                x2 += e.X - prevX;
                                y2 += e.Y - prevY;
                                break;

                            default:
                                {
                                    x1 += e.X - prevX;
                                    x2 += e.X - prevX;
                                    y1 += e.Y - prevY;
                                    y2 += e.Y - prevY;
                                    break;
                                }
                        }
                        figureslist[selectedInd].x1 = x1;
                        figureslist[selectedInd].x2 = x2;
                        figureslist[selectedInd].y1 = y1;
                        figureslist[selectedInd].y2 = y2;
                        redrawAll();
                    }
                }
            }
            else
            {
                if (selectedInd != -1)
                {
                    defineCursor(e.X, e.Y, figureslist[selectedInd]);
                }
            }
            prevX = e.X;
            prevY = e.Y;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            isPtr = false;
            selectedInd = -1;
            fig = comboBox.SelectedIndex;
        }
    }
}
