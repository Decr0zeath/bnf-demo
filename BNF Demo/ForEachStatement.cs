using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BNF_Demo
{
    class ForEachStatement
    {
        public bool DatatypeBNF(string datatypeString)
        {

            switch(datatypeString)
            {
                case "Boolean" :
                case "Byte" :
                case "Date" :
                case "Decimal" :
                case "Double" :
                case "Integer" :
                case "Long" :
                case "Sbyte" :
                case "Short":
                case "Single":
                case "String":
                case "Uinteger":
                case "Ulong":
                case "Ushort":
                    return true;
                default:
                    return false;
            }     
        }

        public string VariableBNF(string temporaryString, string originalString, int loopcounter)
        {
            int OriginalLength = originalString.Length;

            if(OriginalLength >= 3 && temporaryString != "<variable><variable>")
            {
                temporaryString = "<variable><variable>";
            }
            else if(OriginalLength == 2 )
            {
                if (Char.IsLetter(originalString[loopcounter]))
                {
                    temporaryString = "<letter><variable>";
                }
                if (Char.IsDigit(originalString[loopcounter]))
                {
                    temporaryString = "<letter><numbers>";
                }
            }
            else
            {
                if (Char.IsLetter(originalString[loopcounter]))
                {
                    temporaryString = "<letter>";
                }
                if (Char.IsDigit(originalString[loopcounter]))
                {
                    temporaryString = "<numbers>";
                }


            }

            return temporaryString;
        }
        public void ForEachBNF(string userinput)
        {
            string StartBNF = "For Each <variable> As <dataype> In <variable> ... Next";
            string[] BreakBNF = StartBNF.Split(' ');

            int count = 0;
            string[] newstring = userinput.Split(' ');

            foreach (string Splitnewstring in newstring)
            {
                count++;
            }

            Console.WriteLine("     " + StartBNF);

            int loopcounter = 0;

            while (true)
            {


                if (newstring[0] == "For" && newstring[1] == "Each" && newstring[3] == "As" && newstring[5] == "In" && newstring[7] == "..." && newstring[8] == "Next")
                {
                    var variable = new Regex("^[a-zA-Z0-9]*$");

                    if (variable.IsMatch(newstring[2]) && variable.IsMatch(newstring[6]))
                    {
                        if (newstring[2] != newstring[6])
                        {
                            foreach (char splitnewstring2 in newstring[2])
                            {
                                if (Char.IsLetter(splitnewstring2))
                                {
                                    VariableBNF(newstring[2], BreakBNF[2],loopcounter);
                                }
                                else
                                {
                                    Console.WriteLine(" Error : First character of variable should only contain letters.");
                                }
                            }

                            foreach (char splitnewstring6 in newstring[6])
                            {
                                if (Char.IsLetter(splitnewstring6))
                                {

                                }
                                else
                                {
                                    Console.WriteLine(" Error : First character of variable should only contain letters.");
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("Error : Variable \"" + newstring[2] + "\"" + " has already been declared.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error : Variable should only contain letters and numbers.");
                    }
                }
                else
                {
                    Console.WriteLine(" Error : Invalid For Each Syntax.");
                }

                loopcounter++;
            }
        }
    }
}
