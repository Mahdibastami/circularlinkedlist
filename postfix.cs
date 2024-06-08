using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure1
{
    class Stack
    {
        public int topC;
        public int topS;
        public List<char> stackC;
        public List<string> stackS;
        public Stack()
        {
            topC = -1;
            topS = -1;
            stackC = new List<char>();
            stackS = new List<string>();
        }
        public void AddInStack(char s)
        {
            stackC.Add(s);
            topC++;

        }
        public void AddInStack(string s)
        {
            stackS.Add(s);
            topS++;

        }
        public char DeleteOfStackC()
        {
            char x;
            if (topC == -1)
                return '$';
            else
            {
                x = stackC[topC];
                stackC.RemoveAt(topC);
                topC--;
                return x;
            }
        }
        public string DeleteOfStackS()
        {
            string x;
            if (topS == -1)
                return "0";
            else
            {
                x = stackS[topS];
                stackS.RemoveAt(topS);
                topS--;
                return x;
            }
        }
    }

    internal class Program
    {
        static Dictionary<char, int> opp = new Dictionary<char, int>();

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string wellcome = "Welcome to our program";
            Console.SetCursorPosition((Console.WindowWidth - wellcome.Length) / 2, Console.CursorTop);
            Console.WriteLine(wellcome);
            Console.ResetColor();
            // opprands priority
            opp.Add('*', 1);
            opp.Add('/', 1);
            opp.Add('%', 1);
            opp.Add('+', 2);
            opp.Add('-', 2);
            opp.Add('(', 0);
            opp.Add(')', 8);
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("please choose your command: ");
                Console.WriteLine("1: Covert InFix to Postfix and PreFix ");
                Console.WriteLine("2: Covert PostFix to Infix and PreFix ");
                Console.WriteLine("3: Covert PreFix to Infix and PostFix ");
                Console.WriteLine("4: Covert InFix to PostFix ");
                Console.WriteLine("5: Covert InFix to PreFix ");
                Console.WriteLine("6: Covert PreFix to InFix ");
                Console.WriteLine("7: Covert PreFix to PostFix ");
                Console.WriteLine("8: Covert PostFix to PreFix ");
                Console.WriteLine("9: Covert PostFix to InFix ");
                Console.WriteLine("10: Quit");
                Console.ForegroundColor = ConsoleColor.Cyan;
                int key = Convert.ToInt32(Console.ReadLine());
                if (key == 10)
                    break;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Please Enter your expression:");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string s = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                if (key == 1)
                    ConvertInFixTo(s);
                else if (key == 2)
                {
                    Console.WriteLine("InFix: " + ConvertPostFixToInfix(s));
                    Console.WriteLine("PreFix: " + ConvertPostFixToPreFix(s));
                }
                else if (key == 3)
                {
                    Console.WriteLine("InFix: " + ConvertPreFixToInfix(s));
                    Console.WriteLine("PostFix: " + ConvertPreFixToPostFix(s));
                }
                else if (key == 4)
                    Console.WriteLine("PostFix: " + ConvertInFixtoPostFix(s));
                else if (key == 5)
                    Console.WriteLine("PreFix: " + ConvertInFixtoPreFix(s));
                else if (key == 6)
                    Console.WriteLine("InFix: " + ConvertPreFixToInfix(s));
                else if (key == 7)
                    Console.WriteLine("PostFix: " + ConvertPreFixToPostFix(s));
                else if (key == 8)
                    Console.WriteLine("PreFix: " + ConvertPostFixToPreFix(s));
                else if (key == 9)
                    Console.WriteLine("InFix: " + ConvertPostFixToInfix(s));

            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Do not visit us again thank you for your visit :) ");
            Console.ResetColor();
            //string s = "*+A+/BC/-D*EFG+IH";
            // "(A+(B/C+(D-E*F)/G))*(I+H)"
            //ABC/DEF*-G/++IH+*
            //*+A+/BC/-D*EFG+IH
            //Console.WriteLine(ConvertInFixtoPostFix(s));
            //Console.WriteLine(ConvertInFixtoPreFix(s));
            // ConvertInFixTo(s);
            //Console.WriteLine(ConvertPostFixToInfix(s));
            //Console.WriteLine(ConvertPostFixToPreFix(s));
            //Console.WriteLine(ConvertPreFixToInfix(s));
            //Console.WriteLine(ConvertPreFixToPostFix(s));

        }

        public static void ConvertInFixTo(string exp)
        {
            exp = prantez(exp);
            bool add = false;
            string postfix = "";
            string prefix;
            Stack p = new Stack();
            exp.ToCharArray();
            //convert to infix
            for (int i = 0; i < exp.Length; i++)
            {
                char s = exp[i];
                if (opp.ContainsKey(s))
                {
                    if (opp[s] == 8 && p.stackC.Count != 0)
                    {
                        char j = p.stackC[p.topC];
                        while (j != '(')
                        {
                            string w = p.DeleteOfStackS();
                            string z = p.DeleteOfStackS();
                            string y = z + w + p.DeleteOfStackC();
                            p.AddInStack(y);
                            j = p.stackC[p.topC];
                        }
                        char m = p.DeleteOfStackC();
                        add = true;
                    }
                    else if (p.stackC.Count == 0)
                    {
                        p.AddInStack(s);
                        add = true;
                    }
                    else if (opp[p.stackC[p.topC]] != 0 && opp[s] != CompareOpp(p.stackC[p.topC], s))
                    {
                        p.AddInStack(s);
                        add = true;
                    }
                    else if (opp[p.stackC[p.topC]] == 0 || opp[s] == 0)
                    {
                        p.AddInStack(s);
                        add = true;
                    }
                    else
                    {
                        string w = p.DeleteOfStackS();
                        string z = p.DeleteOfStackS();
                        string y = z + w + p.DeleteOfStackC();
                        p.AddInStack(y);
                    }
                    if (add)
                        add = false;
                    else
                        i--;

                }
                else
                {
                    string t = "";
                    t += exp[i];
                    p.AddInStack(t);
                }
            }
            postfix = p.DeleteOfStackS();
            Console.WriteLine("PostFix: " + postfix);
            //convert to prefix
            for (int i = 0; i < exp.Length; i++)
            {
                char s = exp[i];
                if (opp.ContainsKey(s))
                {
                    if (opp[s] == 8 && p.stackC.Count != 0)
                    {
                        char j = p.stackC[p.topC];
                        while (j != '(')
                        {
                            string w = p.DeleteOfStackS();
                            string z = p.DeleteOfStackS();
                            string y = p.DeleteOfStackC() + z + w;
                            p.AddInStack(y);
                            j = p.stackC[p.topC];
                        }
                        char m = p.DeleteOfStackC();
                        add = true;
                    }
                    else if (p.stackC.Count == 0)
                    {
                        p.AddInStack(s);
                        add = true;
                    }
                    else if (opp[p.stackC[p.topC]] != 0 && opp[s] != CompareOpp(p.stackC[p.topC], s))
                    {
                        p.AddInStack(s);
                        add = true;
                    }
                    else if (opp[p.stackC[p.topC]] == 0 || opp[s] == 0)
                    {
                        p.AddInStack(s);
                        add = true;
                    }
                    else
                    {
                        string w = p.DeleteOfStackS();
                        string z = p.DeleteOfStackS();
                        string y = p.DeleteOfStackC() + z + w;
                        p.AddInStack(y);
                    }
                    if (add)
                        add = false;
                    else
                        i--;

                }
                else
                {
                    string t = "";
                    t += exp[i];
                    p.AddInStack(t);
                }
            }
            prefix = p.DeleteOfStackS();
            Console.WriteLine("PreFix: " + prefix);

        }
        public static string prantez(string exp)
        {
            bool add = false;
            string x = "";
            Stack p = new Stack();
            exp.ToCharArray();
            for (int i = 0; i < exp.Length; i++)
            {
                char c = exp[i];
                if (opp.ContainsKey(exp[i]))
                {

                    if (opp[c] == 8 && p.stackC.Count != 0)
                    {
                        char j = p.stackC[p.topC];
                        while (j != '(')
                        {
                            string w = p.DeleteOfStackS();
                            string z = p.DeleteOfStackS();
                            string y = "(" + z + p.DeleteOfStackC() + w + ")";
                            p.AddInStack(y);
                            j = p.stackC[p.topC];

                        }
                        p.DeleteOfStackC();
                        add = true;

                    }
                    else if (p.stackC.Count == 0)
                    {
                        p.AddInStack(c);
                        add = true;
                    }
                    else if (opp[p.stackC[p.topC]] != 0 && opp[c] != CompareOpp(p.stackC[p.topC], c))
                    {
                        p.AddInStack(c);
                        add = true;
                    }
                    else if (opp[p.stackC[p.topC]] == 0 || opp[c] == 0)
                    {
                        p.AddInStack(c);
                        add = true;
                    }
                    else
                    {
                        string w = p.DeleteOfStackS();
                        string z = p.DeleteOfStackS();
                        string y = "(" + z + p.DeleteOfStackC() + w + ")";
                        p.AddInStack(y);

                    }

                    if (add)
                        add = false;
                    else
                        i--;
                }
                else
                {
                    string t = "";
                    t += exp[i];
                    p.AddInStack(t);


                }


            }
            while (p.topC != -1)
            {
                string w = p.DeleteOfStackS();
                string z = p.DeleteOfStackS();
                string y = "(" + z + p.DeleteOfStackC() + w + ")";
                p.AddInStack(y);
            }
            x = p.DeleteOfStackS();
            return x;
        }
        public static int CompareOpp(char p, char e)
        {
            if (opp.ContainsKey(p) && opp.ContainsKey(e))
            {
                //if isp > icp return isp
                //if the output was isp you can add in stack
                if (opp[p] > opp[e])
                    return opp[p];
                else
                    return opp[e];
            }
            else
                return opp[')'];
        }
        public static string ConvertInFixtoPostFix(string exp)
        {
            exp = prantez(exp);
            bool add = false;
            string infix = "";
            Stack p = new Stack();
            exp.ToCharArray();
            //convert to infix
            for (int i = 0; i < exp.Length; i++)
            {
                char s = exp[i];
                if (opp.ContainsKey(s))
                {
                    if (opp[s] == 8 && p.stackC.Count != 0)
                    {
                        char j = p.stackC[p.topC];
                        while (j != '(')
                        {
                            string w = p.DeleteOfStackS();
                            string z = p.DeleteOfStackS();
                            string y = z + w + p.DeleteOfStackC();
                            p.AddInStack(y);
                            j = p.stackC[p.topC];
                        }
                        char m = p.DeleteOfStackC();
                        add = true;
                    }
                    else if (p.stackC.Count == 0)
                    {
                        p.AddInStack(s);
                        add = true;
                    }
                    else if (opp[p.stackC[p.topC]] != 0 && opp[s] != CompareOpp(p.stackC[p.topC], s))
                    {
                        p.AddInStack(s);
                        add = true;
                    }
                    else if (opp[p.stackC[p.topC]] == 0 || opp[s] == 0)
                    {
                        p.AddInStack(s);
                        add = true;
                    }
                    else
                    {
                        string w = p.DeleteOfStackS();
                        string z = p.DeleteOfStackS();
                        string y = z + w + p.DeleteOfStackC();
                        p.AddInStack(y);
                    }
                    if (add)
                        add = false;
                    else
                        i--;

                }
                else
                {
                    string t = "";
                    t += exp[i];
                    p.AddInStack(t);
                }
            }
            infix = p.DeleteOfStackS();
            return infix;
        }
        public static string ConvertInFixtoPreFix(string exp)
        {

            string prefix;
            exp = prantez(exp);
            bool add = false;
            Stack p = new Stack();
            exp.ToCharArray();
            for (int i = 0; i < exp.Length; i++)
            {
                char s = exp[i];
                if (opp.ContainsKey(s))
                {
                    if (opp[s] == 8 && p.stackC.Count != 0)
                    {
                        char j = p.stackC[p.topC];
                        while (j != '(')
                        {
                            string w = p.DeleteOfStackS();
                            string z = p.DeleteOfStackS();
                            string y = p.DeleteOfStackC() + z + w;
                            p.AddInStack(y);
                            j = p.stackC[p.topC];
                        }
                        char m = p.DeleteOfStackC();
                        add = true;
                    }
                    else if (p.stackC.Count == 0)
                    {
                        p.AddInStack(s);
                        add = true;
                    }
                    else if (opp[p.stackC[p.topC]] != 0 && opp[s] != CompareOpp(p.stackC[p.topC], s))
                    {
                        p.AddInStack(s);
                        add = true;
                    }
                    else if (opp[p.stackC[p.topC]] == 0 || opp[s] == 0)
                    {
                        p.AddInStack(s);
                        add = true;
                    }
                    else
                    {
                        string w = p.DeleteOfStackS();
                        string z = p.DeleteOfStackS();
                        string y = p.DeleteOfStackC() + z + w;
                        p.AddInStack(y);
                    }
                    if (add)
                        add = false;
                    else
                        i--;

                }
                else
                {
                    string t = "";
                    t += exp[i];
                    p.AddInStack(t);
                }
            }
            prefix = p.DeleteOfStackS();
            return prefix;
        }
        public static string ConvertPostFixToInfix(string exp)
        {
            string infix;
            Stack p = new Stack();
            exp.ToCharArray();
            for (int i = 0; i < exp.Length; i++)
            {
                char s = exp[i];
                if (!opp.ContainsKey(s))
                {
                    string t = "";
                    t += s;
                    p.AddInStack(t);
                }
                else
                {
                    string w = p.DeleteOfStackS();
                    string z = p.DeleteOfStackS();
                    string y = "(" + z + s + w + ")";
                    p.AddInStack(y);
                }
            }
            infix = p.DeleteOfStackS();
            return infix;

        }
        public static string ConvertPostFixToPreFix(string exp)
        {
            string infix = ConvertPostFixToInfix(exp);
            return ConvertInFixtoPreFix(infix);
        }
        public static string ConvertPreFixToInfix(string exp)
        {
            exp.ToCharArray();
            Stack p = new Stack();
            string infix;
            for (int i = exp.Length - 1; i >= 0; i--)
            {
                char s = exp[i];
                if (!opp.ContainsKey(s))
                {
                    string t = "";
                    t += s;
                    p.AddInStack(t);
                }
                else
                {
                    string w = p.DeleteOfStackS();
                    string z = p.DeleteOfStackS();
                    string y = "(" + w + s + z + ")";
                    p.AddInStack(y);
                }
            }
            infix = p.DeleteOfStackS();
            return infix;
        }
        public static string ConvertPreFixToPostFix(string exp)
        {
            return ConvertInFixtoPostFix(ConvertPreFixToInfix(exp));
        }
    }

}