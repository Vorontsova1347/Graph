using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph
{
    public partial class Form1 : Form
    {
        int Comand = 0;
        bool flag, flag1;
        Graphs graph1 = new Graphs();
        List<Node> selectionNode = new List<Node>();
        MouseEventArgs FirstClick1;
        MouseEventArgs SecondClick1;

        public Form1()
        {
            InitializeComponent();
            flag = false;
            openFileDialog1.Filter = "Graph Documents|*.graph";
            saveFileDialog1.Filter = "Graph Documents|*.graph";
            Graphics graphics = graph1PB.CreateGraphics();
            graphics.Clear(Color.White);
        }

        void Obr()
        {
            if (AddNodeBtn.Checked)
            {
                PictureBox pictureBox = graph1PB;
                Graphs gr = graph1;
                MouseEventArgs mouseEventArgs =  FirstClick1;
                gr.AddNode(mouseEventArgs.X, mouseEventArgs.Y);
                gr.Draw(pictureBox.CreateGraphics(), selectionNode);
            }
            else if (DeleteNodeBtn.Checked)
            {
                Graphs gr =  graph1;
                PictureBox pictureBox = graph1PB;
                MouseEventArgs mouseEventArgs = FirstClick1;
                Node nodeGrathic = gr.FindNode(mouseEventArgs.Location);
                if (nodeGrathic != null)
                {
                    gr.Delete(nodeGrathic);
                }
                gr.Draw(pictureBox.CreateGraphics(), selectionNode);
            }
            else if (GetEdgeBtn.Checked)
            {
                Graphs gr =  graph1;
                PictureBox pictureBox = graph1PB;
                MouseEventArgs mouseEventArgs1 = FirstClick1;
                MouseEventArgs mouseEventArgs2 = SecondClick1;
                Node nodeGrathic1 = gr.FindNode(mouseEventArgs1.Location);
                Node nodeGrathic2 = gr.FindNode(mouseEventArgs2.Location);
                if (nodeGrathic1 != null && nodeGrathic2 != null && nodeGrathic1 != nodeGrathic2)
                {
                    gr.AddEdge(nodeGrathic1, nodeGrathic2);
                }
                gr.Draw(pictureBox.CreateGraphics(), selectionNode);
            }
            else if (SelectionNodeBtn.Checked)
            {
                Node node = graph1.FindNode(FirstClick1.Location);
                if ( node != null )
                {
                    if (selectionNode.IndexOf(node) != -1)
                    {
                        selectionNode.Remove(node);
                    }
                    else
                    {
                        selectionNode.Add(node);
                    }
                }
                graph1.Draw(graph1PB.CreateGraphics(), selectionNode);
            }
        }

        Bitmap bmp1 = null;
        Bitmap bmp2 = null;
        private void graph1PB_MouseDown(object sender, MouseEventArgs e)
        { 
            if (GetEdgeBtn.Checked)
            {
                bmp1 = new Bitmap(graph1PB.Width, graph1PB.Height);

                graph1.Draw(Graphics.FromImage(bmp1), selectionNode);

            }
            FirstClick1 = e;
            flag = GetEdgeBtn.Checked;
        }

        private void graph1PB_MouseMove(object sender, MouseEventArgs e)
        {
            SecondClick1 = e;
            if (flag)
            {

                Graphics graphics = graph1PB.CreateGraphics();
                if (bmp1 != null)
                    graphics.DrawImage(bmp1, 0, 0);

            }
        }


        private void StartBtn_Click(object sender, EventArgs e)
        {
           List<List<int>> answer = graph1.Cycles2(selectionNode);
            textBox1.Lines = new string[0];
            List<string> list = new List<string>();
            for (int i = 0; i < answer.Count; i++)
            {
                string s = "";
                for (int j = 0; j < answer[i].Count; j++)
                {
                    s += Convert.ToString(answer[i][j])+' ';
                }
                list.Add(s);
            }
            textBox1.Lines = list.ToArray();
        }

        private void openGraph1Btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                graph1 = ClassLibrary1.FileGraph.OpenGraph(openFileDialog1.FileName);
                graph1.Draw(graph1PB.CreateGraphics(), selectionNode);
            }
        }

        private void saveGraph1Btn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ClassLibrary1.FileGraph.SaveGraph(saveFileDialog1.FileName, graph1);
            }
        }


        private void ClearBtn_Click(object sender, EventArgs e)
        {
            graph1 = new Graphs();
            graph1.Draw(graph1PB.CreateGraphics(), selectionNode);
            textBox1.Lines = null;
        }

        private void graph1PB_MouseUp(object sender, MouseEventArgs e)
        {
            if (bmp1 != null)
            {
                bmp1.Dispose();
                bmp1 = null;
            }
            SecondClick1 = e;
            flag = false;
            Obr();
        }


    }
}
