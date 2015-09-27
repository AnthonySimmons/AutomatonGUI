using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Automaton_GUI
{
    public class Parser
    {
        public List<State> stateList;

        public Parser()
        {
            stateList = new List<State>();
        }
        public string regex = "";


        public List<State> combineLists(List<State> L1, List<State> L2, List<State> L3, char c)
        {
            //if (L1.Count == 0)
            { L1.Add(new State()); }
            int x = L1.Count;
            L1[L1.Count - 1].connectsWith += "_" + L2[0].connectsWith + "_" + L3[0].connectsWith;
            int branchNode = L1.Count-1;
            for (int i = 1; i < L2.Count; i++)
            {
                L2[i].uniqueID = L1.Count;
                L2[i].name = L2[i].uniqueID.ToString();
                string[] str1 = System.Text.RegularExpressions.Regex.Split(L2[i].connect, "_");
                for (int j = 0; j < str1.Length; j++)
                {
                    if (str1[j] != "")
                    {
                        //  int n = System.Convert.ToInt32(str1[j]);
                        L2[i].connect.Replace(str1[j], (L1.Count + 1).ToString());
                    }
                }
                L1.Add(L2[i]); 
            }
            L1[branchNode].connect += "_" + (branchNode+1).ToString() + "_" + (x+L2.Count-1).ToString();
            branchNode = L1.Count - 1;
            for (int i = 1; i < L3.Count; i++)
            {
                L3[i].uniqueID = L1.Count;
                L3[i].name = L3[i].uniqueID.ToString();
                string[] str1 = System.Text.RegularExpressions.Regex.Split(L3[i].connect, "_");
                for (int j = 0; j < str1.Length; j++)
                {
                    if (str1[j] != "")
                    {
                        //  int n = System.Convert.ToInt32(str1[j]);
                        L3[i].connect.Replace(str1[j], (L1.Count + 1).ToString());
                    }
                }
                L1.Add(L3[i]); 
            }
            L1.Add(new State());
            L1[L1.Count - 2].connectsWith += "_" + c;
            L1[L1.Count - 2].connect += "_" + (L1.Count - 1).ToString();
            L1[branchNode].connectsWith += "_" + c;
            L1[branchNode].connect += "_" + (L1.Count - 1).ToString();
            //L1[branchNode + 1].connect = (branchNode + 2).ToString();
            for (int i = 0; i < L1.Count-1; i++)
            {
                if (i != branchNode && !L1[i].connect.Contains((i + 1).ToString()))
                {
                    L1[i].connect += (i + 1).ToString();
                }
            }

                return L1;
        }
        public List<State> buildFromRegEx(List<State> mList, int count, string regex)
        {
            //int count = 0;
            //if (mList.Count == 0) { mList.Add(new State()); }
            for (int i = 0; i < regex.Length; i++)
            {
                if (regex[i] == '[')
                {
                    //stateList.Add(new State());
                    
                    string tmp = "";
                    while (regex[i + 1] != ']')
                    {
                        i++;
                        if (tmp.Length > 0)
                        {
                            tmp += ",";
                        }
                        tmp += regex[i];
                        
                    }

                    count = RegExHelper(mList, count, i, tmp, 2);
                    
                    //i++;
                    //count++;
                }
                else if (regex[i] == ']')
                {
                    if (i + 1 < regex.Length)
                    {
                        if (regex[i + 1] == '*')
                        {
                            count--;
                        }
                        else if (regex[i + 1] == '+')
                        {
                         //   count--;
                        }
                    }

                }

                else if (regex[i] == '+' )
                {
                    mList[mList.Count - 1].connect += "_" + (mList.Count - 1).ToString();
                    mList[mList.Count - 1].connectsWith += "_" + regex[i - 1].ToString();

                }

                else if (regex[i] == '(')
                {
                    string str1 = "";
                    string str2 = "";

                    //while (regex[i+1] != ')')
                    {
                        while (regex[i + 1] != '|')
                        {
                            i++;
                            str1 += regex[i];

                        }
                        i++;
                        while (regex[i + 1] != ')')
                        {
                            i++;
                            str2 += regex[i];
                        }
                        List<State> list1 = buildFromRegEx(new List<State>(), 0, str1);
                        List<State> list2 = buildFromRegEx(new List<State>(), 0, str2);

                        if (i + 2 < regex.Length)
                        {
                            mList = new List<State>(combineLists(mList, list1, list2, regex[i + 2]));
                        }
                        else
                        {
                            mList = new List<State>(combineLists(mList, list1, list2, '&'));
                        }
                        i++;
                    }
                    i++;
                    count = mList.Count - 1;
                }
                else if (regex[i] != '?' && regex[i] != '+' && regex[i] != '*' && regex[i] != '(' && regex[i] != ')' && regex[i] != '[' && regex[i] != ']')
                {
                    mList.Add(new State());
                    //  count = mList.Count - 1;
                    if (mList[count].connectsWith.Length > 0) { mList[count].connectsWith += "_"; }
                    if (mList[count].connect.Length > 0) { mList[count].connect += "_"; }
                    mList[count].connectsWith += regex[i].ToString();


                    if (i < regex.Length - 1)
                    {
                        if (regex[i + 1] == '*' || regex[i + 1] == '?')
                        {
                            mList[count].connect += count.ToString();
                            count--;

                        }
                        else
                        {
                            //if (!mList[count - 1].connect.Contains(count.ToString())) { count=0; }
                            mList[count].connect += (count + 1).ToString();
                        }
                    }
                    else
                    {
                        mList[count].connect += (count + 1).ToString();

                    }

                    count++;
                }
            }
            
            for(int i = 0; i < mList.Count; i++)
            {
                mList[i].uniqueID = i;
                mList[i].name = i.ToString();
                mList[i].category = "Intermediate";
            }
            if (mList[mList.Count - 1].connect.Contains(mList.Count.ToString()))
            {
                mList.Add(new State());
                mList[mList.Count - 1].name = (mList.Count - 1).ToString();
                mList[mList.Count - 1].uniqueID = mList.Count - 1;
            }
            mList[0].category = "Initial";
           mList[mList.Count-1].category = "Final";
           return mList;
        }

        private int RegExHelper(List<State> mList, int count, int i, string tmp, int inc)
        {
         if (i + inc < regex.Length)
                    {
                        if (regex[i + inc] == '*' || regex[i + inc] == '?')
                        {
                            if (mList.Count == 0)
                            {
                                mList.Add(new State());
                                count++;
                                mList[mList.Count - 1].connect += (mList.Count - 1).ToString();
                                mList[mList.Count - 1].connectsWith += tmp;

                            }
                            else 
                            {
                                //stateList.Add(new State());
                                mList[mList.Count - 1].connect += "_" + (mList.Count - 1).ToString();
                                mList[mList.Count - 1].connectsWith += "_" + tmp;
                            }
                            //count++;

                        }
                        else if (regex[i + inc] == '+')
                        {
                            mList.Add(new State());
                            if (mList.Count - 2 > 0)
                            {
                                mList[mList.Count - 2].connect += "_" + (mList.Count - 1).ToString();
                                mList[mList.Count - 2].connectsWith += "_" + tmp;//regex[i].ToString();
                            }
                            mList[mList.Count - 1].connect += "_" + (mList.Count - 1).ToString();
                            mList[mList.Count - 1].connectsWith += "_" + tmp;
                            count++;
                        }
                        else
                        {
                            mList.Add(new State());
                            mList[mList.Count-1].connect += "_" + (mList.Count).ToString();
                            mList[mList.Count-1].connectsWith += "_" + tmp;
                            count++;
                        }
                        
                    }
                    else
                    {
                        if (mList.Count == 0) { mList.Add(new State()); count++;}
                        mList[mList.Count-1].connect += "_" + (mList.Count).ToString();
                        mList[mList.Count-1].connectsWith += "_" + tmp;
                        
                    }
         return count;
        }

        public void loadRegEx(string path)
        {
            bool or = false;
            XmlReader reader = XmlReader.Create(path);
            regex = "";
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    regex += reader.Value;
                    if (or) { regex += "|"; or = false; }
                }
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "Or")
                    {
                        //string[] or = System.Text.RegularExpressions.Regex.Split(reader.Value, "|");
                        regex += "(";
                        or = true;
                    }
                    if (reader.Name == "AnySymbol")
                    {
                        regex += "[";
                    }
                }
                if (reader.NodeType == XmlNodeType.EndElement)
                {
                    //str += reader.Name + "\n";
                    if (reader.Name == "ZeroOrMore")
                    {
                        regex += "*";
                    }
                    if (reader.Name == "OneOrMore")
                    {
                        regex += "+";
                    }
                    if (reader.Name == "Or")
                    {
                        regex += ")";
                    }
                    if (reader.Name == "AnySymbol")
                    {
                        regex += "]";   
                    }
                    if (reader.Name == "ZeroOrOne")
                    {
                        regex += "?";
                    }
                }
                
                //str += "Name: "+reader.Name+"\tValue:"+reader.Value+"\n";
                
            }
        }

        public bool loadXML(string path)
        {
            Console.WriteLine("Loading XML file from " + @path);
            using (TextReader r = new StreamReader(@path))
            {
                XmlSerializer s = new XmlSerializer(typeof(List<State>));
                stateList = (List<State>)s.Deserialize(r);
            }
            return true;
        }

        public bool saveXML(string path)
        {
            Console.WriteLine("Saving XML file to " + @path);
            using (TextWriter w = new StreamWriter(@path))
            {
                XmlSerializer s = new XmlSerializer(typeof(List<State>));
                s.Serialize(w, stateList);
            }
            return true;
        }

        public void print(int index)
        {
            if (index >= 0 && index <= stateList.Count())
            {
                if (index == 0)
                {
                    Console.WriteLine();
                    stateList[0].print();
                    Console.WriteLine();
                }

                else if (index > 0)
                {
                    foreach (State s in stateList)
                    {
                        Console.WriteLine();
                        s.print();
                        Console.WriteLine();
                    }
                }
                //for (int i = 0; i < index; i++)
                //{
                //    stateList[index].print();
                //    Console.WriteLine();
                //}
            }
        }
    }
}
