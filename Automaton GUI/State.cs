using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Automaton_GUI
{
    [Serializable()]
    public class State
    {
        //Sample Format
        [XmlAttribute("ID")]
        public int uniqueID;

        [XmlElement("Title")]
        public string title;

        [XmlElement("Category")]
        public string category;

        [XmlElement("Transition")]
        public int transition;

        [XmlElement("Name")]
        public string name;

        [XmlElement("Connect_To")]
        public string connect;

        [XmlElement("Connect_With")]
        public string connectsWith;

        [XmlElement("Alive")]
        public bool alive = true;


        public State()
        {
            //Sample
            uniqueID = 0;
            title = "";
            category = "";
            transition = 0;
            name = "";
            connect = "";
            connectsWith = "";
            alive = true;
        }
        public State(State source)
        {
            uniqueID = source.uniqueID;
            title = source.title;
            category = source.category;
            transition = source.transition;
            name = source.name;
            connect = source.connect;
            connectsWith = source.connectsWith;
            alive = source.alive;
        }
        public bool canMove(string nextID)
        {
            return connect.Contains(nextID);
        }

        

        public void print()
        {
            Console.WriteLine("ID: " + uniqueID);
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Category: " + category);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Connects To: " + connect);
            Console.WriteLine("Transition: " + transition);
        }
    }
}
