using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Automaton_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pbxDraw.Width, pbxDraw.Height);

        }
        Bitmap bmp;
        int drag = -1;
        Graphics g;
        
        Parser myParser = new Parser();
        Automaton myAutomaton = new Automaton();
        List<State> newState = new List<State>();
        State selectedState = new State();
        bool doubleClick = false;
        int c = 1;
        int wid = 80;
        int mdState = 0;
        int muState = 0;
        State current = new State();

        private void Form1_Load(object sender, EventArgs e)
        {
            tbxDrawName.Visible = false;
            radioInitial.Checked = true;
            radioInter.Enabled = true;
            
            //tbxFile.Text = "../../XMLFile5.xml";
            
            myParser = new Parser();
            myAutomaton = new Automaton();
            newState = new List<State>();
            g = Graphics.FromImage(bmp);//pbxDraw.CreateGraphics();
            
            
            statePoints = new List<Point>();
            selectedState = new State();

            c = statePoints.Count+1;
            wid = (pbxDraw.Width-170) / (c);
        }

        List<Point> statePoints;

        private void setStatePoints()
        { 
            /*
             * Given a list of automaton states, assign each one a coordinate point on the picturebox
             */

            //int c = myAutomaton.intermediateStates.Count + 1 + myAutomaton.finalStates.Count;
            statePoints = new List<Point>(c);
            //int wid = pictureBox1.Width / c;
            int i = 0;
            int y = pbxDraw.Height / 2;
            int ht = pbxDraw.Height / 4;
            int yP = 0;
            Random rand = new Random();
            int m = myAutomaton.startState.uniqueID;
            statePoints.Add(new Point(10, y));
            foreach (State s in myAutomaton.intermediateStates)
            {
                //y = rand.Next(0,400);
                i++;
                int n = s.uniqueID;
                int xP = i * wid + 20;
                if (n % 3 == 0)
                {
                    yP = y + ht; 
                }
                else if (n % 3 == 1)
                {
                    yP = y - ht;
                }
                else
                {
                    yP = y;
                    xP += wid ;
                }
                if (n < statePoints.Count)
                {
                    statePoints.Insert(n, new Point(xP, yP));
                }
                else
                {
                    statePoints.Add(new Point(xP, yP));
                }
            }
            foreach (State s in myAutomaton.finalStates)
            {
                if (s.uniqueID % 2 == 0)
                {
                    yP = y + ht;
                }
                else
                {
                    yP = y - ht;
                }
                i++;
                //statePoints[s.uniqueID] = new Point(i * wid, y);
                statePoints.Insert(s.uniqueID, new Point(i*wid+15, yP));
            }
        }

        private int findStatePoint(Point p)
        {
            /*
             Given a coordinate point on the picturebox, find an overlapping statepoint, returns -1 if none found
             */
            if (statePoints.Count > 0)
            {
                for (int i = 0; i < statePoints.Count; i++)
                {
                    float diffX = statePoints[i].X - p.X;
                    float diffY = statePoints[i].Y - p.Y;
                    double dist = Math.Sqrt((diffX * diffX + diffY * diffY));
                    if (dist < wid / 2 && myAutomaton.stateList[i].alive)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }


        private string simpleRegex()
        {
            string str = "";
            for (int i = 0; i < myParser.regex.Length; i++)
            {
                str += myParser.regex[i];
                if (myParser.regex[i] == '[')
                {
                    str += myParser.regex[i + 1] + "-";
                    while (myParser.regex[i] != ']')
                    {
                        i++;
                    }
                    str += myParser.regex[i - 1] + "]";
                }
            }
            return str;
        }
        private void drawStateIDs()
        {
            /*
             * Draws the name for each state
             */
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            Pen blackPen = new Pen(Color.Black);
            System.Drawing.Font font = new System.Drawing.Font("Times New Roman", 12);
            //int c = myAutomaton.intermediateStates.Count + 1 + myAutomaton.finalStates.Count;
            //int wid = pictureBox1.Width / c;

            if (myParser.regex.Length < 5)
            {
                g.DrawString(myParser.regex, font, blackBrush, new PointF(20, 20));
            }
            else
            {
                g.DrawString(simpleRegex(), font, blackBrush, new PointF(20, 20));
            }

            if (myAutomaton.startState.alive)
            {
                Point m = new Point(statePoints[myAutomaton.startState.uniqueID].X + wid / 6, statePoints[myAutomaton.startState.uniqueID].Y + wid / 6);
                g.DrawString(myAutomaton.startState.name, font, blackBrush, m);
                //g.DrawString(myAutomaton.startState.uniqueID.ToString(), font, blackBrush, m);
            }
            foreach(State s in myAutomaton.intermediateStates)
            {
                if (s.alive)
                {
                    Point p = new Point(statePoints[s.uniqueID].X + wid / 6, statePoints[s.uniqueID].Y + wid / 6);
                    g.DrawString(s.name, font, blackBrush, p);
                }
            }
            foreach (State s in myAutomaton.finalStates)
            {
                if (s.alive)
                {
                    Point p = new Point(statePoints[s.uniqueID].X + wid / 6, statePoints[s.uniqueID].Y + wid / 6);
                    g.DrawString(s.name, font, blackBrush, p);
                }
            }
        }
        private int findIndex(string mName)
        {
            for (int i = 0; i < newState.Count; i++)
            {
                if (newState[i].name == mName)
                {
                    return i;
                }
            }
            return -1;
        }
        private void drawConnections()
        {
            /*
             Draw transition lines and acceptable strings for each corresponding transition
             */
            System.Drawing.Font font = new System.Drawing.Font("Times New Roman", 12);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            Pen blackPen = new Pen(Color.Black);
            //int c = myAutomaton.intermediateStates.Count + 1 + myAutomaton.finalStates.Count;
            //int wid = pictureBox1.Width / c;
            

            //sc - list of states that the startState connects to
            string[] sc = System.Text.RegularExpressions.Regex.Split(myAutomaton.startState.connect, "_");

            
            int s = 0;
            for (int j = 0; j < sc.Length; j++)
            {
                if (sc[j] != "N/A" && sc[j] != "")
                {
                    s = findIndex(sc[j]);//System.Convert.ToInt32(sc[j]);
                    string[] s3 = System.Text.RegularExpressions.Regex.Split(myAutomaton.startState.connectsWith, "_");
                if (s < statePoints.Count && s >= 0 && myAutomaton.startState.alive && myAutomaton.stateList[s].alive && j < s3.Length)
                {
                    Point p1 = new Point(statePoints[myAutomaton.startState.uniqueID].X + wid / 4, statePoints[myAutomaton.startState.uniqueID].Y + wid / 4);
                    Point p2 = new Point(statePoints[s].X + wid / 4, statePoints[s].Y + wid / 4);
                    Point p3 = new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
                    g.DrawLine(blackPen, p1, p2);


                    if (s3[j].Length < 5)
                    {
                        g.DrawString(s3[j], font, redBrush, new Point((p3.X + p2.X) / 2, (p3.Y + p2.Y) / 2 + 5));
                    }
                    else
                    {
                        g.DrawString("["+s3[j][0].ToString()+"-"+s3[j][s3[j].Length-1].ToString()+"]".ToString(), font, redBrush, new Point((p3.X + p2.X) / 2, (p3.Y + p2.Y) / 2 + 5));
                    }
                    g.FillRectangle(blackBrush, (float)((p3.X + p2.X) / 2) - 2, (float)((p3.Y + p2.Y) / 2) - 2, (float)5.0f, (float)5.0f);
                    if (p1 == p2)
                    //if(sc[j] == myAutomaton.startState.uniqueID.ToString())
                    {
                        g.DrawEllipse(blackPen, p1.X + wid / 12, p1.Y + wid / 12, wid / 3, wid / 3);
                        if (j < s3.Length)
                        {
                            if (s3[j].Length < 5)
                            {
                                g.DrawString(s3[j], font, redBrush, new Point(p1.X + wid / 3, p1.Y + wid / 3));
                            }
                            else
                            {
                                g.DrawString("["+s3[j][0].ToString()+"-"+s3[j][s3[j].Length-1]+"]", font, redBrush, new Point(p1.X + wid / 3, p1.Y + wid / 3));
                            }
                        }
                    }

                    foreach (State m in myAutomaton.intermediateStates)
                    {
                        if (m.alive)
                        {
                            string[] s1 = System.Text.RegularExpressions.Regex.Split(m.connect, "_");
                            string[] s2 = System.Text.RegularExpressions.Regex.Split(m.connectsWith, "_");

                            for (int i = 0; i < s1.Length; i++)
                            {
                                if (s1[i] != "" && s1[i] != "N/A")
                                {
                                    s = findIndex(s1[i]);//System.Convert.ToInt32(s1[i]);
                                    if (s >= 0)
                                    {
                                        if (myAutomaton.stateList[s].alive)
                                        {
                                            p1 = new Point(statePoints[m.uniqueID].X + wid / 4, statePoints[m.uniqueID].Y + wid / 4);
                                            if (s < statePoints.Count)
                                            {
                                                p2 = new Point(statePoints[s].X + wid / 4, statePoints[s].Y + wid / 4);
                                            }
                                            else
                                            {
                                                p2 = p1;
                                            }
                                            g.DrawLine(blackPen, p1, p2);
                                            p3 = new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
                                            Point p4 = new Point((int)((p3.X + p2.X) / 2) - 2, (int)((p3.Y + p2.Y) / 2) - 2);
                                            if (i < s2.Length)
                                            {
                                                if (s2[i].Length < 5)
                                                {
                                                    g.DrawString(s2[i], font, redBrush, new Point(p4.X, p4.Y + 5));
                                                }
                                                else
                                                {
                                                    g.DrawString("["+s2[i][0].ToString()+"-"+s2[i][s2[i].Length-1].ToString()+"]", font, redBrush, new Point(p4.X, p4.Y + 5));
                                                }
                                            }

                                            g.FillRectangle(blackBrush, p4.X, p4.Y, (float)5.0f, (float)5.0f);
                                            float xDiff = p2.X - p1.X;
                                            float yDiff = p2.Y - p1.Y;
                                            double angle = Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;
                                            //g.DrawArc(blackPen, (float)(p1.X+p2.X)/2, (float)(p1.Y+p2.Y)/2, 20.0f, 20.0f, (float)angle-50,115.0f);

                                            //If you rotate point (px, py) around point (ox, oy) by angle theta you'll get:
                                            //p'x = cos(theta) * (px-ox) - sin(theta) * (py-oy) + ox
                                            //p'y = sin(theta) * (px-ox) + cos(theta) * (py-oy) + oy

                                            Point a1;
                                            //a1.X = Math.Cos(angle)

                                            if (p1 == p2)
                                            {
                                                g.DrawEllipse(blackPen, p1.X + wid / 12, p1.Y + wid / 12, wid / 3, wid / 3);
                                                if (i < s2.Length)
                                                {
                                                    if (s2[i].Length < 5)
                                                    {
                                                        g.DrawString(s2[i], font, redBrush, new Point(p1.X + wid / 3, p1.Y + wid / 3));
                                                    }
                                                    else
                                                    {
                                                        g.DrawString("["+s2[i][0].ToString()+"-"+s2[i][s2[i].Length-1].ToString()+"]", font, redBrush, new Point(p1.X + wid / 3, p1.Y + wid / 3));
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        }

                    foreach (State m in myAutomaton.finalStates)
                    {
                        if (m.alive)
                        {
                            string[] s1 = System.Text.RegularExpressions.Regex.Split(m.connect, "_");
                            string[] s2 = System.Text.RegularExpressions.Regex.Split(m.connectsWith, "_");

                            for (int i = 0; i < s1.Length; i++)
                            {
                                if (s1[i] != "" && s1[i] != "N/A")
                                {
                                    s = findIndex(s1[i]);//System.Convert.ToInt32(s1[i]);
                                    if (myAutomaton.stateList[s].alive && s >= 0)
                                    {
                                        p1 = new Point(statePoints[m.uniqueID].X + wid / 4, statePoints[m.uniqueID].Y + wid / 4);
                                        if (s < statePoints.Count)
                                        {
                                            p2 = new Point(statePoints[s].X + wid / 4, statePoints[s].Y + wid / 4);
                                        }
                                        else
                                        {
                                            p2 = p1;
                                        }
                                        g.DrawLine(blackPen, p1, p2);
                                        p3 = new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
                                        Point p4 = new Point((int)((p3.X + p2.X) / 2) - 2, (int)((p3.Y + p2.Y) / 2) - 2);
                                        if (i < s2.Length)
                                        {
                                            if (s2[i].Length < 5)
                                            {
                                                g.DrawString(s2[i], font, redBrush, new Point(p4.X, p4.Y + 5));
                                            }
                                            else
                                            {
                                                g.DrawString("["+s2[i][0].ToString()+"-"+s2[i][s2[i].Length-1].ToString()+"]", font, redBrush, new Point(p4.X, p4.Y + 5));
                                            }
                                        }

                                        g.FillRectangle(blackBrush, p4.X, p4.Y, (float)5.0f, (float)5.0f);
                                        float xDiff = p2.X - p1.X;
                                        float yDiff = p2.Y - p1.Y;
                                        double angle = Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;
                                        //g.DrawArc(blackPen, (float)(p1.X+p2.X)/2, (float)(p1.Y+p2.Y)/2, 20.0f, 20.0f, (float)angle-50,115.0f);

                                        //If you rotate point (px, py) around point (ox, oy) by angle theta you'll get:
                                        //p'x = cos(theta) * (px-ox) - sin(theta) * (py-oy) + ox
                                        //p'y = sin(theta) * (px-ox) + cos(theta) * (py-oy) + oy

                                        Point a1;
                                        //a1.X = Math.Cos(angle)

                                        if (p1 == p2)
                                        {
                                            g.DrawEllipse(blackPen, p1.X + wid / 12, p1.Y + wid / 12, wid / 3, wid / 3);
                                            if (i < s2.Length)
                                            {
                                                if (s2[i].Length < 5)
                                                {
                                                    g.DrawString(s2[i], font, redBrush, new Point(p1.X + wid / 3, p1.Y + wid / 3));
                                                }
                                                else
                                                {
                                                    g.DrawString("["+s2[i][0].ToString()+"-"+s2[i][s2[i].Length-1]+"]", font, redBrush, new Point(p1.X + wid / 3, p1.Y + wid / 3));
                                                }
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                    }
                }
            }
        }

        private void drawStatePoints()
        {
            SolidBrush redBrush = new SolidBrush(Color.Red);
            Pen blackPen = new Pen(Color.Black);
            System.Drawing.Font font = new System.Drawing.Font("Times New Roman", 12);
            //int c = myAutomaton.intermediateStates.Count + 1 + myAutomaton.finalStates.Count;
            //int wid = pictureBox1.Width / (c+2);

            for (int i = 0; i < statePoints.Count; i++)
            {
                if (myAutomaton.stateList[i].alive)
                {
                    g.FillEllipse(new SolidBrush(Color.White), statePoints[i].X, statePoints[i].Y, wid / 2, wid / 2);
                    g.DrawEllipse(blackPen, statePoints[i].X, statePoints[i].Y, wid / 2, wid / 2);
                    if (myAutomaton.stateList[i].category.Contains("Final"))
                    {
                        g.DrawEllipse(blackPen, statePoints[i].X + 5, statePoints[i].Y + 5, wid / 2 - 10, wid / 2 - 10);

                    }
                }
            }
        }


        private void printStates()
        {
            //int c = myAutomaton.intermediateStates.Count + 1 + myAutomaton.finalStates.Count;
            //int wid = pictureBox1.Width / c;
            SolidBrush redBrush = new SolidBrush(Color.Red);
            Pen blackPen = new Pen(Color.Black);
            System.Drawing.Font font = new System.Drawing.Font("Times New Roman", 12);

            int x = 0;
            int y = 150;


            g.DrawEllipse(blackPen, 10, y + 10, wid/2 - 20, wid/2 - 20);
            g.DrawEllipse(blackPen, (c - 1) * wid + 10, y + 10, wid/2 - 20, wid/2 -20);

            g.DrawLine(blackPen, wid / 2, y+wid/4, wid, y+wid/4);
            for (int i = 0; i < c; i++)
            {
                g.DrawEllipse(blackPen, i * wid, y, wid/2, wid/2);
                if (i < c - 1)
                {
                    g.DrawLine(blackPen, i * wid + wid / 2, y + wid / 4, i * wid + wid, y + wid / 4);
                }
            }
            
            string str = myAutomaton.startState.uniqueID.ToString();
            g.DrawString(str, font, redBrush, wid/5, y+15);
            int j = 0;
            foreach (State s in myAutomaton.intermediateStates)
            {
                j++;
                str = s.uniqueID.ToString();
                g.DrawString(str, font, redBrush, j * wid+15, y+15);
                
            }
            foreach (State s in myAutomaton.finalStates)
            {
                j++;
                str = s.uniqueID.ToString();
                g.DrawString(str, font, redBrush, j * wid + 15, y + 15);   
            }
        }

        private void drawCurrentState()
        {
            Pen blackPen = new Pen(Color.Black);
            Pen bluePen = new Pen(Color.Blue);
            SolidBrush red = new SolidBrush(Color.Red);

            //int c = myAutomaton.intermediateStates.Count + 1 + myAutomaton.finalStates.Count;
            //int wid = pictureBox1.Width / (c+2);
            g.FillEllipse(red, statePoints[myAutomaton.currentState.uniqueID].X, statePoints[myAutomaton.currentState.uniqueID].Y, wid/2, wid/2);
            g.DrawEllipse(blackPen, statePoints[myAutomaton.currentState.uniqueID].X, statePoints[myAutomaton.currentState.uniqueID].Y, wid / 2, wid / 2);

            g.DrawRectangle(bluePen, statePoints[selectedState.uniqueID].X-wid/8, statePoints[selectedState.uniqueID].Y-wid/8, wid*0.8f, wid*0.8f);
        }

        private void drawDiagram()
        {
            setComboBox();
            if (!selectedState.alive) { selectedState = myAutomaton.stateList[0]; }
            current = myAutomaton.currentState;
            myAutomaton = new Automaton();
            myAutomaton.build(newState);
            myAutomaton.currentState = current;
            wid = Math.Max(wid, 80);
            wid = Math.Min(wid, 200);
            //using (g = Graphics.FromImage(bmp))
            using (g = pbxDraw.CreateGraphics()) 
            {
                g.Clear(Color.CornflowerBlue);
                drawConnections();

                drawStatePoints();
                drawCurrentState();
                drawStateIDs();
            }
            //pbxDraw.Image = bmp;
            //bmp = new Bitmap(pbxDraw.Width, pbxDraw.Height);
            //pbxDraw.DrawToBitmap(bmp, pbxDraw.ClientRectangle);
            //pbxDraw.BackgroundImage = bmp;
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "../../";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
        }


        private void setComboBox()
        {
            comboBox1.Items.Clear();
            for (int i = 0; i < newState.Count; i++)
            {
                if (!comboBox1.Items.Contains(newState[i].name))
                {
                    comboBox1.Items.Add(newState[i].name);
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            showSelectedStateInfo();
            tbxFile.Text = openFileDialog1.FileName;
            //myParser.loadXML(openFileDialog1.FileName);
            //drawDiagram();

            cbxDraw.Enabled = true;
            btnReset.Enabled = true;
            g = pbxDraw.CreateGraphics();
            btnRun.Enabled = true;
            g.Clear(Color.White);
            myParser = new Parser();
            myAutomaton = new Automaton();

            string inputFile = tbxFile.Text;
            //myParser.loadXML("../../SampleFormat.xml");
            if (cbxRegEx.Checked)
            {
                myParser.loadRegEx(inputFile);
                myParser.stateList = new List<State>(myParser.buildFromRegEx(myParser.stateList, 0, myParser.regex));
            }
            else
            {
                myParser.loadXML(inputFile);
            }
            newState = new List<State>(myParser.stateList);

            myAutomaton.build(myParser.stateList);
            c = myAutomaton.stateList.Count;
            wid = (pbxDraw.Width - 170) / (c) + 10;
            setStatePoints();
            drawDiagram();
            setComboBox();
            
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //statePoints = new List<Point>();

            
            cbxDraw.Enabled = true;
            tbxConnectTo.Clear();
            tbxConnectWith.Clear();
            btnAdd.Enabled = false;
            btnRun.Enabled = true;
            //btnRun.Enabled = false;
            cbxDraw.Checked = false;
            if (newState.Count == 0)
            { radioInitial.Checked = true; }
            else
            { radioInter.Checked = true; }
            
            
            setComboBox();
        }

        private void pbxDraw_MouseDown(object sender, MouseEventArgs e)
        {
            if (!cbxDraw.Checked)
            {
                drag = findStatePoint(new Point(e.X, e.Y));
                
            }
            if (!btnAdd.Enabled)
            {
                tbxID.Enabled = true;
                tbxName.Enabled = true;
                tbxConnectTo.Enabled = true;
                tbxConnectWith.Enabled = true;
                tbxDrawName.Clear();
                tbxDrawName.Focus();
                tbxDrawName.Visible = true;
                tbxDrawName.Location = new Point(e.X+pbxDraw.Location.X, e.Y);

                myAutomaton = new Automaton();
                myAutomaton.intermediateStates = new List<State>();
                myAutomaton.finalStates = new List<State>();
                myAutomaton.stateList = new List<State>();
                myAutomaton.startState = new State();
                myAutomaton.currentState = new State();
                
                State st = new State();
                //if (myAutomaton.currentState == null) { myAutomaton.currentState = myAutomaton.stateList[0]; }
                if (statePoints == null)
                //if(myAutomaton.stateList.Count == 0)
                {
                    //myAutomaton
                    st.category = "Initial";
                    myAutomaton.startState = st;
                    //myAutomaton.currentState = st;
                    statePoints = new List<Point>();
                }
                else
                {
                    st.category = "Intermediate";
                    //myAutomaton.intermediateStates.Add(st);
                }
                
                btnAdd.Enabled = true;
                //statePoints.Insert(statePoints.Count, 
                statePoints.Add(new Point(e.X - wid / 4, e.Y - wid / 4));
                c = statePoints.Count;
                wid = (pbxDraw.Height-170) / (c);

                if (c > 1)
                {
                    st.category = "Intermediate";
                    radioInitial.Enabled = true;
                    radioInter.Enabled = true;
                    
                }
                st.uniqueID = c - 1;
                st.transition = 1;
                //st.connect = textBox4.Text;
                //st.connectsWith = textBox5.Text;
                
               
                //myAutomaton.startState = new State();
                

                newState.Add(st);


                
                selectedState = st;
                myAutomaton.build(newState);
                //myAutomaton.currentState = newState[0];
                //setStatePoints();
                drawDiagram();
                tbxID.Text = st.uniqueID.ToString();
                //drawStatePoints();
                tbxDrawName.Focus();
            }
            else
            {
                int n = findStatePoint(new Point(e.X, e.Y));
                if (n >= 0)
                {
                    mdState = n;
                    drawDiagram();
                }
            }
        }
        private void showSelectedStateInfo()
        {
            tbxName.Enabled = true;
            tbxID.Enabled = true;
            tbxConnectTo.Enabled = true;
            tbxConnectWith.Enabled = true;
            if (selectedState.category == "Initial") { radioInitial.Checked = true; }
            if (selectedState.category == "Intermediate") { radioInter.Checked = true; }
            if (selectedState.category.Contains("Final")) { cbxFinal.Checked = true; }
            else { cbxFinal.Checked = false; }
            tbxID.Text = selectedState.uniqueID.ToString();
            tbxName.Text = selectedState.name;
            tbxConnectTo.Text = selectedState.connect;
            tbxConnectWith.Text = selectedState.connectsWith;
        }

        private void pbxDraw_MouseUp(object sender, MouseEventArgs e)
        {
            drag = -1;
            if (doubleClick)
            {
                tbxName.Enabled = true;
                tbxID.Enabled = true;
                tbxConnectTo.Enabled = true;
                tbxConnectWith.Enabled = true;
                
                //radiobtnOpen.Enabled = false;
                //radioButton2.Enabled = false;
                //radioButton3.Enabled = false;
                int m = findStatePoint(new Point(e.X, e.Y));
                if (m < myAutomaton.stateList.Count && m > -1)
                {
                    selectedState = myAutomaton.stateList[m];
                    
                }

                showSelectedStateInfo();
                doubleClick = false;
                setComboBox();
                comboBox1.SelectedText = selectedState.name;
                drawDiagram();

            }
            else if (cbxDraw.Checked)
            {
                int n = findStatePoint(new Point(e.X, e.Y));
                if (n >= 0)
                {
                    if (newState[mdState].connect.Length > 0)
                    {
                        newState[mdState].connect += "_";
                    }
                    newState[mdState].connect += newState[n].name;//n.ToString();

                    
                    tbxDraw.Size = new Size(20, 20);
                    tbxDraw.Visible = true;
                    tbxDraw.Focus();
                    Point p = new Point((statePoints[mdState].X+statePoints[n].X)/2 + pbxDraw.Location.X, (statePoints[mdState].Y + statePoints[n].Y)/2+pbxDraw.Location.Y);
                    tbxDraw.Location = p;
                    selectedState = newState[mdState];

                    if (selectedState.category == "Initial")
                    {
                        radioInitial.Checked = true;
                    }
                    if (selectedState.category == "Intermediate")
                    {
                        radioInter.Checked = true;
                    }
                    if (selectedState.category.Contains("Final"))
                    {
                        cbxFinal.Checked = true;
                    }
                    myAutomaton = new Automaton();
                    myAutomaton.build(newState);

                   
                }
                drawDiagram();
                tbxID.Text = selectedState.uniqueID.ToString();
                tbxConnectTo.Text = selectedState.connect.ToString();
                tbxConnectWith.Text = selectedState.connectsWith;
                
            }
        }

        private void pbxDraw_DoubleClick(object sender, EventArgs e)
        {
            doubleClick = true;
            cbxDraw.Checked = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            tbxDraw.Visible = false;
            tbxDrawName.Visible = false;
            drawDiagram();

            if (tbxName.Text != "")
            { selectedState.name = tbxName.Text; }
            if(tbxID.Text != "")
            {selectedState.uniqueID = System.Convert.ToInt32(tbxID.Text);}
            if(tbxConnectTo.Text != "")
            {selectedState.connect = tbxConnectTo.Text;}
            if(tbxConnectWith.Text != "")
            {selectedState.connectsWith = tbxConnectWith.Text;}

            
            if (radioInter.Checked)
            { selectedState.category = "Intermediate"; }
            if (cbxFinal.Checked)
            { selectedState.category += "_Final"; }
            if(selectedState.uniqueID < newState.Count)
            {newState[selectedState.uniqueID] = selectedState;}

            if (tbxDraw.Text != "")
            {

                if (newState[mdState].connectsWith.Length > 0)
                {
                    newState[mdState].connectsWith += "_";
                }
                newState[mdState].connectsWith += tbxDraw.Text;
                selectedState = newState[mdState];
                myAutomaton = new Automaton();
                myAutomaton.build(newState);
                tbxDraw.Clear();
            }
            //myAutomaton = new Automaton();
            //myAutomaton.build(newState);
            /*if (selectedState.uniqueID == 0)
            {
                myAutomaton.startState = selectedState;
            }
            else
            {
                myAutomaton.intermediateStates[selectedState.uniqueID - 1] = selectedState;
            }*/
            tbxID.Text = selectedState.uniqueID.ToString();
            tbxConnectTo.Text = selectedState.connect.ToString();
            tbxConnectWith.Text = selectedState.connectsWith;
            
            //myAutomaton.currentState = newState[0];
            drawDiagram();
            
        }
        private void reset()
        {

            g = Graphics.FromImage(bmp);

            myAutomaton = new Automaton();
            myAutomaton.build(newState);

            c = myAutomaton.stateList.Count;
            wid = (pbxDraw.Width - 170) / (c) + 10;

            setStatePoints();
            drawDiagram();

            tbxID.Clear();
            tbxConnectTo.Clear();
            tbxConnectWith.Clear();
            showSelectedStateInfo();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void radioInitial_Click(object sender, EventArgs e)
        {
            selectedState.category = "Initial";
        }

        private void radioInter_Click(object sender, EventArgs e)
        {
            selectedState.category = "Intermediate";
        }

        private void radioFinal_Click(object sender, EventArgs e)
        {
            selectedState.category = "Final";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "../../";
            saveFileDialog1.ShowDialog();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //myAutomaton.stateList.RemoveAt(selectedState.uniqueID);
            //newState = new List<State>(myAutomaton.stateList);
            //newState.RemoveAt(selectedState.uniqueID);
            
            selectedState.alive = false;
                myAutomaton = new Automaton();
            myAutomaton.build(newState);
            drawDiagram();
        }

        private void pbxDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag >= 0)
            {
                statePoints[drag] = new Point(e.X-wid/4, e.Y-wid/4);
                drawDiagram();
            }
        }

        private void tbxConnectWith_Enter(object sender, EventArgs e)
        {
            drawDiagram();
        }

        private void tbxConnectTo_Leave(object sender, EventArgs e)
        {
            drawDiagram();
        }

      

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            pbxDraw.Height = this.Height;
            pbxDraw.Width = this.Width - 180;
            c = myAutomaton.stateList.Count;
            wid = (pbxDraw.Width - 170) / (c) + 10;   
            setStatePoints();
            drawDiagram();       
        }

       

        private void tbxDraw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbxDraw.Text != "")
                {
                    if (newState[mdState].connectsWith.Length > 0)
                    {
                        newState[mdState].connectsWith += "_";
                    }
                    newState[mdState].connectsWith += tbxDraw.Text;
                    selectedState = newState[mdState];
                    myAutomaton = new Automaton();
                    myAutomaton.build(newState);
                    tbxDraw.Clear();
                    tbxDraw.Visible = false;
                    drawDiagram();
                    showSelectedStateInfo();
                }   
            }
        }


        private void showHelp()
        {
            string str = "\t\t\tFinite State Machine \n" +
                       "-------------------------------------------------------------------------------------\n\n" +
                       "- To open an Automaton, Enter the file path in the box labeled 'XML File' and click\t\t 'Open'\n" +
                       "- To save an Automaton, Enter the file path and select 'save'\n" +
                       "- To move a State, Simply Drag and Drop\n" +
                       "- To modify the selected state, edit its properties in the panel and select\n\t 'Update Selected State' (Be sure to select the correct category)\n" +
                       "- To add a state select 'Add State' and click where you want your state to go\n" +
                       "- To add transitions select a state and fill in 'Connect To' and 'Connect With'\n" +
                       "\tMultiple transitions are seperated with a '_' and have corresponding \t\tpositions\n" +
                       "- To draw in transitions, check the 'Draw Transitions' checkbox\n" +
                       "When running an input, each string must be separated with a '_' \n" +
                       "Selected State - Highlighted with a blue box, its properties are shown in the panel\n" +
                       "Current State - Illuminated in Red\n" +
                       "Final States - Depicted as a circle within another circle\n" +
                       "Connect To - The ID of the State that the selected state is connected to\n" +
                       "Connect With - The string that will move the current state from the selected state to the connected state\n";
            MessageBox.Show(str);
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            showHelp();
            
        }
        private void save()
        {
            tbxFile.Text = saveFileDialog1.FileName;
            myParser.stateList = myAutomaton.stateList;
            myParser.saveXML(tbxFile.Text);
            myAutomaton = new Automaton();
            myAutomaton.build(newState);
            btnRun.Enabled = true;
        }
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            save();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "../../";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbxFile.Text != "")
            {
                myParser.stateList = myAutomaton.stateList;
                myParser.saveXML(tbxFile.Text);
                myAutomaton = new Automaton();
                myAutomaton.build(newState);
                btnRun.Enabled = true;    
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "../../";
            saveFileDialog1.ShowDialog();
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0 && comboBox1.SelectedIndex < newState.Count)
            {
                int n = findIndex(comboBox1.SelectedItem.ToString());
                if (n >= 0)
                {
                    selectedState = newState[n];
                }
            }
            showSelectedStateInfo();
            drawDiagram();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveJPGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Image img = pbxDraw.Image;
          //  pbxDraw.DrawToBitmap(bmp, pbxDraw.ClientRectangle);
            using (g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.CornflowerBlue);
                drawConnections();

                drawStatePoints();
                drawCurrentState();
                drawStateIDs();
            }
            pbxDraw.Image = bmp;
            bmp = new Bitmap(pbxDraw.Width, pbxDraw.Height);
            pbxDraw.DrawToBitmap(bmp, pbxDraw.ClientRectangle);
            saveFileDialog1.InitialDirectory = "../../";
            saveFileDialog1.ShowDialog();
            
            bmp.Save(saveFileDialog1.FileName);
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tbxInput.Text == "" && !myAutomaton.currentState.connectsWith.Contains("&"))
            {
                timer1.Stop();
            }
            else
            {
                runOneStep();
            }
        }

        private void runOneStep()
        {
            
                myAutomaton.setInputExpression(tbxInput.Text);
                int p = myAutomaton.mExpression.Length;
                if (!myAutomaton.currentState.connectsWith.Contains(myAutomaton.mExpression[0]) && !myAutomaton.currentState.connectsWith.Contains("&"))
                {
                    timer1.Stop();
                    MessageBox.Show("Expression Rejected!");
                }
                bool pass = myAutomaton.solve(myAutomaton.currentState, myAutomaton.mExpression);
                string accept = myAutomaton.move(!pass);

                tbxInput.Clear();
                tbxInput.Text = myAutomaton.mExpression;
                drawDiagram();

                
                if (accept == "accept" && tbxInput.Text.Length == 0)
                {
                    timer1.Stop();
                    MessageBox.Show("Expression Accepted!");
                                        
                }
                else if ((tbxInput.Text.Length <= 0 && !myAutomaton.currentState.connectsWith.Contains("&"))) //|| (accept == "reject"))
                {
                    timer1.Stop();
                    MessageBox.Show("Expression Rejected!");
                    
                }
            
        }
        private void btnStep_Click(object sender, EventArgs e)
        {
            runOneStep();

           
        }

        private void runInputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showHelp();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myAutomaton = new Automaton();
            statePoints = new List<Point>();
            newState = new List<State>();
            comboBox1.Items.Clear();
            //drawDiagram();
            using (g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.CornflowerBlue);
            }
            pbxDraw.Image = bmp;
            bmp = new Bitmap(pbxDraw.Width, pbxDraw.Height);
            pbxDraw.DrawToBitmap(bmp, pbxDraw.ClientRectangle);
        }

        private void tbxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectedState.name = tbxName.Text;
                drawDiagram();
            }
        }

        private void tbxConnectTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectedState.connect = tbxConnectTo.Text;
                drawDiagram();
            }
        }

        private void tbxConnectWith_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectedState.connectsWith = tbxConnectWith.Text;
                drawDiagram();
            }
        }

        private void tbxDrawName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectedState.name = tbxDrawName.Text;
                showSelectedStateInfo();
                tbxDrawName.Visible = false;
                drawDiagram();
            }
        }

        private void cbxFinal_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxFinal.Checked)
            {
              //  selectedState.category += "_Final";
             //   drawDiagram();
            }
            else
            { 
                
            }
        }

        private void tbxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                timer1.Start();
            }
        }

        private void tbxFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                save();  
            }
        }
        private void tests()
        {
            string str = "\t DFA \t NFA \n\n";
            string [,]DFA = new string[5,5];
            string[,] NFA = new string[5, 5];
            //List<List<string>> DFA = new List<List<string>>(5);
            //DFA.Add(new List<string>(5));
            DFA[0,0] = "aa";
            DFA[0,1] = "babababb";
            DFA[0,2] = "abbaab";
            DFA[0,3] = "bb";
            DFA[0,4] = "bbaaaabbbab";
            DFA[1, 0] = "rgy";
            DFA[1, 1] = "rgyrgy";
            DFA[1, 2] = "rgyrgyrgy";
            DFA[1, 3] = "rgyrgyrgyrgy";
            DFA[1, 4] = "rgyrgyrgyrgyrgy";
            DFA[2,0] = "101100111110";
            DFA[2,1] = "01001001111";
            DFA[2,2] = "010101110101";
            DFA[2,3] = "101111111110";
            DFA[2,4] = "0011101110";
            DFA[3,0] = "000001111110";
            DFA[3,1] = "00000000";
            DFA[3,2] = "11111111111";
            DFA[3,3] = "01100000000";
            DFA[3,4] = "1001111001";
            DFA[4,0] = "1111111111";
            DFA[4,1] = "000000000111111111";
            DFA[4,2] = "0101010101010101";
            DFA[4,3] = "001001001001";
            DFA[4,4] = "0010011111";
            

            NFA[0,0] = "abbbababb";
            NFA[0,1] = "aaaaaaaab";
            NFA[0,2] = "aabaabbbbab";
            NFA[0,3] = "abaabaabbaabab";
            NFA[0,4] = "aaaabbbbaaab";
            NFA[1,0] = "11111011011111";
            NFA[1,1] = "0110";
            NFA[1,2] = "1001";
            NFA[1,3] = "111110011111";
            NFA[1,4] = "00110001001111";
            NFA[2,0] = "&";
            NFA[2,1] = "ab";
            NFA[2,2] = "ababababab";
            NFA[2,3] = "abaab";
            NFA[2,4] = "aabaabaab";
            NFA[3,0] = "aaabbbbbaba";
            NFA[3,1] = "cccaaaaacca";
            NFA[3,2] = "bbccbcbbb";
            NFA[3,3] = "accacccc";
            NFA[3,4] = "cbbbbbcbb";
            NFA[4,0] = "aaaaabbbbbb";
            NFA[4,1] = "aa";
            NFA[4,2] = "bbbbaabaaba";
            NFA[4,3] = "bababaababa";
            NFA[4,4] = "baabaaaab";
            
            for (int i = 0; i < 5; i++)
            {
                myAutomaton = new Automaton();
                myParser.loadXML("../../testDFA" + (i+1).ToString() + ".xml");
                myAutomaton.build(myParser.stateList);

                Automaton auto = new Automaton();
                Parser nParser = new Parser();
                nParser.loadXML("../../testNFA" + (i + 1).ToString() + ".xml");
                auto.build(nParser.stateList);

                for (int j = 0; j < 5; j++)
                {
                    myAutomaton.mExpression = DFA[i,j];
                    bool test = myAutomaton.solve(myAutomaton.currentState, myAutomaton.mExpression);
                    str += "(" + (i+1).ToString() + "," + (j+1).ToString() + ")\t" + test.ToString() + "\t";

                    auto.mExpression = NFA[i, j];
                    test = auto.solve(auto.currentState, auto.mExpression);
                    str += test.ToString() + "\n";

                }
                
            }
            MessageBox.Show(str);
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
            timer1.Interval = 1001 - ((trackBar1.Value) * 100);
        }

        private void runTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tests();
        }

        private void tbxRegEx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                myParser = new Parser();
                myParser.regex = tbxRegEx.Text;
                myParser.stateList = new List<State>(myParser.buildFromRegEx(myParser.stateList, 0, myParser.regex));
                myAutomaton = new Automaton();
                myAutomaton.stateList = new List<State>();
                myAutomaton.build(myParser.stateList);
                

                cbxDraw.Enabled = true;
                btnReset.Enabled = true;
                g = pbxDraw.CreateGraphics();
                btnRun.Enabled = true;
                g.Clear(Color.White);
                
                newState = new List<State>(myParser.stateList);

                //myAutomaton.build(myParser.stateList);
                c = myParser.stateList.Count;
                wid = (pbxDraw.Width - 170) / (c+1) + 10;
                statePoints = new List<Point>(myParser.stateList.Count);
                setStatePoints();
                drawDiagram();
            }
        }

        private void tbxRegEx_Enter(object sender, EventArgs e)
        {
            tbxRegEx.Clear();
        }

        private void tbxRegEx_Leave(object sender, EventArgs e)
        {
            tbxRegEx.Text = "Input Regular Expression";
        }

        


        
    }
}
