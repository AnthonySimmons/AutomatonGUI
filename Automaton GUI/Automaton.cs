using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automaton_GUI
{
    class Automaton
    {
        //public:

        //FUNCTIONS
        public Automaton()
        {
            //startState = new State();
            currentState = new State();
            //startState = new State();
            currentState = startState;
            /*intermediateStates = new List<State>();
            finalStates = new List<State>();
            mDictionary = new List<string>();
            stateList = new List<State>();
            startState = new State();*/
        }
        public Automaton(Automaton source)
        {
            this.stateList = new List<State>(source.stateList);
            this.startState = source.startState;
            this.mExpression = source.mExpression;
            this.intermediateStates = new List<State>(source.intermediateStates);
            this.finalStates = new List<State>(source.finalStates);
            this.currentState = new State(source.currentState);
        }
        
        public bool solve(State current, string mExp)
        {
            Automaton tmp = new Automaton(this);
            tmp.currentState = new State(current);
            tmp.mExpression = mExp;
            int count = 0;
            string acc = "";
            do{
                count++;
                acc = tmp.move(false);
                if (acc == "reject")
                {
                    return false;
                }
               
            } while ((acc != "accept" && tmp.mExpression.Length > 0)||(tmp.currentState.connectsWith.Contains("&"))) ;
            return acc == "accept";
        }

        public bool build(System.Collections.Generic.List<Automaton_GUI.State> input)
        {
            //***************************************************************************************************************
            // Name: public bool build( List<XML>Parser.State> input )
            // Description: This function takes a list of States to build an Automaton. The list of states must
            // have only one starting state, at least one final state, and may have final states. This function will
            // sort the states into the according categories. It will also create the dictionary based on the State's IDs.
            //***************************************************************************************************************
            //if (intermediateStates == null)
            {
                intermediateStates = new List<Automaton_GUI.State>();
            }
            //if(finalStates == null)
            { finalStates = new List<Automaton_GUI.State>(); }
            if (mDictionary == null)
            { mDictionary = new List<string>(); }
            if (stateList == null)
            { stateList = new List<State>(); }

            foreach (State s in input)
            {
                stateList.Add(s);
                if (s.category.Contains("Initial"))
                {
                    if (startState == null)
                    {
                        startState = s;
                        currentState = s;
                        Console.WriteLine("State: " + s.uniqueID + " set as Initial");
                    }

                    else
                    {
                        Console.WriteLine("ERROR: Start State already set!");
                        return false;
                    }
                }//initial state

                else if (s.category.Contains("Intermediate"))
                {
                    intermediateStates.Add(s);
                    Console.WriteLine("State: " + s.uniqueID + " set as Intermediate");
                }//intermediate state

                else if (s.category.Contains("Final"))
                {
                    finalStates.Add(s);
                    Console.WriteLine("State: " + s.uniqueID + " set as Final");
                }//final state

                else
                {
                    Console.WriteLine("ERROR: Your category for State" + s.uniqueID + " is all sorts of messed up");
                    return false;
                }//category error

                //update dictionary
                mDictionary.Add(s.name);
            }
            if (stateList.Count == 0) { stateList.Add(new State()); }
            startState = stateList[0];
            currentState = startState;
            if (finalStates.Count == 0)
            {
                Console.WriteLine("ERROR: No Final States!");
                return false;
            }
            else
                return true;

        }
        public bool setInputExpression(string expression)
        {
            mExpression = expression;
            if (checkInputExpression(expression))
            {
                Console.WriteLine(expression);
                return true;
            }
            else
            {
                Console.WriteLine(expression + "Failed");
                return false;
            }


        }

        private int findIndex(string mName)
        {
            for (int i = 0; i < stateList.Count; i++)
            {
                if (stateList[i].name == mName)
                {
                    return i;
                }
            }
            return -1;
        }

        public string move(bool pass)
        {
            /*
             * This functions takes the user input expression (mExpression) and moves the currentState to a connected state
             * if the initial input string (ex[0]) matches one of the accepted transition strings (cs[i])
             * The initial user input string (ex[0]) is dropped from mExpression at the end
             * currentState will move at most once each function call
             * Returns true if you've reached a final state, false otherwise
             */
            ///ex - user input string as an array ("a_b_c" -> [a, b, c])
            //string[] ex = System.Text.RegularExpressions.Regex.Split(mExpression, "_");
            //cs - list of acceptable strings for corresponding transitions

            string[] cs = System.Text.RegularExpressions.Regex.Split(this.currentState.connectsWith, "_");
            //next - list of connected states
            string[] next = System.Text.RegularExpressions.Regex.Split(this.currentState.connect, "_");

            if (cs.Length == next.Length)
            {
                for (int i = 0; i < cs.Length; i++)
                {
                    if (mExpression.Length > 0)
                    {

                        string[] transitions = System.Text.RegularExpressions.Regex.Split(cs[i], ",");
                        for (int j = 0; j < transitions.Length; j++)
                        {
                            
                            if (this.mExpression[0].ToString() == transitions[j])
                            {
                                int n = findIndex(next[i]);//System.Convert.ToInt32(next[i]);
                                if(n >= 0)
                                {
                                if (stateList[n].alive)
                                {
                                    if (solve(stateList[n], this.mExpression.Substring(1)) || pass)
                                    {
                                        this.currentState = this.stateList[n];
                                        this.mExpression = this.mExpression.Substring(1);
                                        if (this.currentState.category.Contains("Final") && this.mExpression.Length == 0)
                                        {
                                            return "accept";
                                        }
                                        return "false";
                                    }
                                }
                                }
                            }
                        }
                    }
                    if (cs[i] == "&")
                    {
                        int n = findIndex(next[i]);
                        if (n >= 0 && n != this.currentState.uniqueID)
                        {
                            if ((stateList[n].alive && solve(stateList[n], this.mExpression))|| pass)
                            {
                                this.currentState = this.stateList[n];
                                if (this.currentState.category.Contains("Final") && this.mExpression.Length == 0)
                                {
                                    return "accept";
                                }
                                return "false";
                            }
                        }
                    }
                }


            }
            
            if (this.currentState.category.Contains("Final") && this.mExpression.Length == 0)
            {
                return "accept";
            }
            if (this.mExpression.Length > 0)
            {
                this.mExpression = this.mExpression.Substring(1);
            }
            return "reject";
            
        }

       

        public bool runInputExpression()
        {
            //mExpression = 1_2_3_4_
            State currentState = startState;
            string nextID;

            mExpression.Remove(0, 2); //delete starting state

            while (mExpression.Length != 0)
            {
                nextID = "";
                while (mExpression[0] != '_')
                    nextID += mExpression[0];

                if (currentState.canMove(nextID))
                    currentState = move(nextID);
            }

            return false;
        }



        //private:
        public void printStates()
        {
            string states = startState.uniqueID.ToString();
            string transitions = startState.connect.ToString();
            foreach (State s in intermediateStates)
            {
                //Console.WriteLine(s.uniqueID);
                states += " -> " + s.uniqueID.ToString();
                transitions += "   " + s.connect.ToString();
            }
            foreach (State s in finalStates)
            {
                //Console.WriteLine(s.uniqueID);
                states += " -> " + s.uniqueID.ToString();
                transitions += "   " + s.connect.ToString();
            }
            Console.WriteLine(states);
            Console.WriteLine(transitions);
        }

        //ATTRIBUTES:
        public State currentState;
        public State startState = null;
        public List<Automaton_GUI.State> intermediateStates;
        public List<State> finalStates;
        private List<string> mDictionary;
        public string mExpression = "";
        public List<State> stateList;
        //FUNCTIONS
        private bool checkInputExpression(string input)
        {
            // Name: checkInputExpression( string input )
            // Description: This function expects a string input to be in the format: "XXXXXX". It will first check
            // if there are any states in the expression that do not exist in the automaton. If there are states in the
            // expression that do not exist, the function will exit. Otherwise, We will set mExpression to the input string.
            // This will call the run() function to see if the expression will run sucessfully on our automaton.

            if (checkDictionary(input))
                return true;
            else
                return false;

        }
        private bool checkDictionary(string input)
        {
            string[] cs = System.Text.RegularExpressions.Regex.Split(this.currentState.connectsWith, "_");

            foreach (string str in cs)
            {
                for (int i = 0; i < stateList.Count(); i++)
                {
                    if (stateList[i].name == str)
                    {
                        break;
                    }
                }
                Console.WriteLine("ERROR: STATENAME DOESN'T EXIST");
                return false;
            }
            return true;
        }
        private State move(string inputName)
        {

            if (startState.name == inputName)
                return startState;
            else
                foreach (State s in intermediateStates)
                {
                    if (s.name == inputName)
                        return s;
                }
            foreach (State s in finalStates)
            {
                if (s.name == inputName)
                    return s;
            }

            return null;
        }


    }


}