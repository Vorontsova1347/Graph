using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Graph
{//исключить мелкие циклы и дубликаты
    public class Node
    {
        public List<Edge> Edges;
        public int x;
        public int y;
        public bool visited;

       // public string name;
       // public int numVisit;
       // public ConsoleColor color;
        public Node(int x, int y)
        {
            this.x = x;
            this.y = y;
            Edges = new List<Edge>();
        }
    }

    public class Edge
    {
        public Node first;
        public Node second;
       // public int numNode;
       // public ConsoleColor color;
        public Edge(Node first, Node second)
        {
            this.first = first;
            this.second = second;
        }

    }



    public class Graphs
    {
      public  List<Node> Nodes = new List<Node>();
      public  List<Edge> Edges = new List<Edge>();
        int rad = 20;
        public void Draw(Graphics g, List<Node> node)
        {

            g.Clear(Color.White);
            DrawLine(g);
            DrawNode(g, node);
        }
        void DrawLine(Graphics g)
        {
            for (int i = 0; i < Edges.Count; i++)
            {
                g.DrawLine(Pens.Black, Edges[i].first.x, Edges[i].first.y, Edges[i].second.x, Edges[i].second.y);
            }
        }
        void DrawNode(Graphics g, List<Node> node)
        {
            for (int i = 0; i < Nodes.Count; i++)
            {
                Brush brush = node.IndexOf(Nodes[i]) == -1 ? Brushes.Bisque : Brushes.Red;
                g.FillEllipse(brush, Nodes[i].x - 10, Nodes[i].y - 10, 20, 20);
                g.DrawEllipse(Pens.Black, Nodes[i].x - 10, Nodes[i].y - 10, 20, 20);
                g.DrawString(Convert.ToString(i), new Font(FontFamily.GenericMonospace, 15), Brushes.Black, Nodes[i].x - 10, Nodes[i].y - 10);
            }
        }

        //public List<List<bool>> GetMatrix()
        //{
        //    List<List<bool>> Matrix = new List<List<bool>>();
        //    for (int i = 0; i < Nodes.Count; i++)
        //    {
        //        List<bool> a = new List<bool>();
        //        for (int j = 0; j < Nodes.Count; j++)
        //        {
        //            a.Add(false);
        //        }
        //        Matrix.Add(a);
        //    }
        //    for (int i = 0; i < Edges.Count; i++)
        //    {
        //        Matrix[Nodes.IndexOf(Edges[i].first)][Nodes.IndexOf(Edges[i].second)] = true;
        //        Matrix[Nodes.IndexOf(Edges[i].second)][Nodes.IndexOf(Edges[i].first)] = true;
        //    }
        //    return Matrix;
        //}




        public void AddNode(int x, int y)
        {
            Node newNode = new Node(x, y);//создаём новый узел с введёными координатами
            Nodes.Add(newNode);//добавляем новый узел в лист узлов
                               // Edges.Add(new List<Edge>());//добавляем в лист листов рёбер новый лист рёбер 
        }

        public void AddEdge(Node node1, Node node2)
        {
            Edges.Add(new Edge(node1, node2));
            node1.Edges.Add(Edges[Edges.Count - 1]);
            node2.Edges.Add(Edges[Edges.Count - 1]);
        }

        public Node FindNode(Point point)//(int x, int y)
        {
            // Node findNode = new Node(x, y);

            //for (int i = 0; i < Nodes.Count; i++)
            //{
            //    //if (Nodes[i] == findNode)
            //    //{
            //    //    findNode = Nodes[i];
            //    //}
            //    if (Math.Abs(Nodes[i].x - x) < rad && Math.Abs(Nodes[i].y - y) < rad)
            //    {
            //        return Nodes[i];
            //    }
            //}

            for (int i = 0; i < Nodes.Count; i++)
            {
                if (point.X - 15 < Nodes[i].x && point.X + 15 > Nodes[i].x && point.Y - 15 < Nodes[i].y && point.Y + 15 > Nodes[i].y)
                {
                    return Nodes[i];
                }
            }
            return null;
            //return findNode;
        }

        public void Delete(Node node)
        {
            Nodes.Remove(node);
            for (int i = 0; i < Edges.Count; i++)
            {
                if (Edges[i].first == node || Edges[i].second == node)
                {
                    if (node == Edges[i].first)
                    {
                        Edges[i].second.Edges.Remove(Edges[i]);
                    }
                    else
                        Edges[i].first.Edges.Remove(Edges[i]);

                    Edges.Remove(Edges[i]);
                    i--;
                }
            }
        }

        //public List<int> Cycles()
        //{
        //    List<int> list = new List<int>();
        //    for (int i = 0; i < Edges.Count; i++)
        //    {
        //        if (Edges[i].first == Edges[i].second )
        //        {
        //            list.Add(Nodes.IndexOf(Edges[i].first));
        //        }
        //    }

        //    return list;
        //}

        private void ClearVisitable(List<Node> node)
        {
            for (int i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].visited = node.IndexOf(Nodes[i]) != -1;
            }
        }

        private void Cycle2Rec(List<List<int>> list ,Node Start)
        {
            List<Stack<int>> listStk = new List<Stack<int>>();

            for (int i = 0; i < Start.Edges.Count; i++)
            {
                Node newNode = Start.Edges[i].first == Start ? Start.Edges[i].second : Start.Edges[i].first;
                if(!newNode.visited)
                Recursia2(listStk, Start,newNode);           
            }
            for (int i = 0; i < listStk.Count; i++)
            {
                listStk[i].Push(Nodes.IndexOf(Start));
            }

            for (int i = 0; i < listStk.Count; i++)
            {
                List<int> a = new List<int>();
                while (listStk[i].Count!=0)
                {
                    a.Add(listStk[i].Pop());
                }
                list.Add(a);
            }
            //List<int> list = new List<int>();
            //for (int i = 0; i < Edges.Count; i++)
            //{
            //    if (!node.Edges[i].first.visited)
            //    {
            //        list.Add(Nodes.IndexOf(node.Edges[i].first));
            //        Cycle2Rec(node.Edges[i].first);
            //    }
            //    if (!node.Edges[i].second.visited)
            //    {
            //        list.Add(Nodes.IndexOf(node.Edges[i].second));
            //        Cycle2Rec(node.Edges[i].second);
            //    }
            //}
        }

        public void Recursia2(List<Stack<int>> list,Node Start, Node node)
        {
            node.visited = true;
            if (node == Start)
            {
                list.Add(new Stack<int>());
                list[list.Count - 1].Push(Nodes.IndexOf(node));//заносим номер текущей вершины
                node.visited = false;
                return;
            }
            else if (IsVisibleAll(node))
            {
                node.visited = false;
                return;
            }
            int k = list.Count;//от какого значения будем дописывать в стек
            for (int i = 0; i < node.Edges.Count; i++)//последовательное прохождение по всем вершинам, добавляем новые стеки в лист
            {
                Node newNode = node.Edges[i].first == node ? node.Edges[i].second : node.Edges[i].first;
                if(!newNode.visited)
                Recursia2(list, Start, newNode);
            }
            for (int i = k; i < list.Count; i++)//дописываем новые пути в стеки  
            {
                list[i].Push(Nodes.IndexOf(node));
            }
            node.visited = false;
        }
        public List<List<int>> Cycles2(List<Node> node)
        {
            List<List<int>> answ = new List<List<int>>();
            ClearVisitable(node);
            for (int i = 0; i < Nodes.Count; i++)
            {
                if (!Nodes[i].visited)
                {
                    Cycle2Rec(answ, Nodes[i]);
                }
                //List<Stack<int>> list = new List<Stack<int>>();
                
                //answ.Add(list);
            }
            for (int i = 0; i < answ.Count; i++)
            {
                if (answ[i].Count == 3)
                {
                    answ.Remove(answ[i]);
                    i--;
                }
            }
            return RemoveCycle(answ);
        }

        public List<List<int>> RemoveCycle( List<List<int>> answ)
        //метод RemoveCycle удаления найденных повторяющихся циклов;
        {
            for (int i = 0; i < answ.Count - 1; i++)
            {
                for (int j = i + 1; j < answ.Count ; j++)
                {
                    if (CirclesEqual(answ[i], answ[j]))
                    {
                        answ.Remove(answ[j]);
                        j--;
                    }
                }
            }
            for (int i = 0; i < answ.Count - 1; i++)
            {
                for (int j = i + 1; j < answ.Count ; j++)
                {
                    if (CirclesEqual2(answ[i], answ[j]))
                    {
                        answ.Remove(answ[j]);
                        j--;
                    }
                }
            }

            return answ;
        }
        //1321
        //3213

        static bool CirclesEqual(List<int> list1, List<int> list2)
        //метод CirclesEqual проверки на совпадение циклов посимвольно в прямом порядке;
        {
            if (list1.Count != list2.Count) return false;
            else
            {
                if (list2.Contains(list1[0]))  //  если во втором цикле есть первый элемент первого цикла
                {
                    int d;  //смещение
                    for (d = 0; d < list2.Count; d++)
                    {
                        if (list2[d] == list1[0])
                            break;
                    }

                    for (int i = 0; i < list1.Count - 1; i++)
                    {
                        if (list1[i] != list2[GetIndexList1(i, d, list2.Count)])
                            return false;

                    }
                    return true;
                }
                else return false;

            }
        }
        static bool CirclesEqual2(List<int> list1, List<int> list2)
        //метод CirclesEqual проверки на совпадение циклов посимвольно в обратном порядке;
        {
            if (list1.Count != list2.Count) return false;
            else
            {
                int i = 0;
                int j = list1.Count - 1;
                while (i!=list1.Count)
                {
                    if (list1[i] != list2[j])
                    {
                        return false;
                    }
                    i++;
                    j--;
                }
                return true;

            }
        }
        //1321
        //3213
        static int GetIndexList1(int indexList1, int d, int ListCount) 
        // возвращает индекс элемента во втором цикле, который соответствует элементу в первом цикле
        {
            int indexList2 = indexList1 + d;
            if (indexList2 >= ListCount) // если мы вышли за границы цикла
            {
                indexList2 -= ListCount;
                indexList2++;
            }

            return indexList2;
        }

        public bool IsVisibleAll(Node node)
        {
            bool flag = true;

            for (int i = 0; i < node.Edges.Count; i++)
            {
                Node node1 = node.Edges[i].first == node ? node.Edges[i].second : node.Edges[i].first;
                flag &= node1.visited;//проверяем, есть ли хотя бы одна вершина непосещённая вокруг node
            }
            return flag;
        }

        //public int FindDepth(int n, string nameNode)
        //{
        //    int result = -1;
        //    VisitTrue(n);//отметить посещённый
        //    if (Nodes[n].name == nameNode)
        //        result = n;
        //    else
        //    {
        //        int L = Nodes[n].Edges.Length;
        //        int i = -1;
        //        result = -1;
        //        while ((i < L - 1) && (result == -1))
        //        {
        //            int m = Nodes[n].Edges[++i].numNode;
        //            if (!Nodes[m].visited)
        //            {
        //                SetEdgeBlack(n, i);//закрасить дугу
        //                result = FindDepth(m, nameNode);
        //            }
        //        }
        //    }
        //    return result;
        //}

        //public int DepthSearch(int n, string nameNode)
        //{
        //    ClearVisit();
        //    int result = FindDepth(n, nameNode);
        //    return result;
        //}

        //void ClearVisit()
        //{
        //    int N = Nodes.Length;
        //    Lib.Num = 0;
        //    for (int i = 0; i < N; i++)
        //    {
        //        Nodes[i].visited = false;
        //        Nodes[i].numVisit = 0;
        //        Nodes[i].color = Color.White;
        //        int L = Nodes[i].Edges.Length;
        //    }
        //}

        //void VisitTrue(int n)
        //{
        //    Nodes[n].visited = true;
        //    Lib.Num++;
        //    Nodes[n].numVisit = Lib.Num;
        //}

    }
}
