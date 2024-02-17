using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Operation
{
    public class Computation
    {

        public double Pemdas(string input)
        {
            string step = "";
            string bago = input;
            Boolean meron = bago.Contains("(");

            if (meron == true)
            {
                bago = input.Replace("(", "*");
                input = bago;
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '*')
                    {
                        int count=0;
                        int j = i;
                        Boolean okay = true;
                        while (okay == true)
                        {
                            if (input[j] == '+' || input[j] == '-' || input[j] == '/')
                            {
                                bago = input.Substring(0,count) + "(" + input.Substring(j+1);
                                okay = false;
                            }
                            count++;
                            j--;
                        }
                        // end while;
                    }
                    // end if;

                }
                // end for loop;

            }// end if meron;

            // parenthesis;
            for (int i = 0; i < bago.Length; i++)
            {
                step = "";
                if (bago[i] == '(')
                {
                    int j = i;
                    Boolean okay = true;
                    while (okay == true)
                    {

                        if (bago[j] != ')')
                        {
                            step = step + bago[j];
                        }else if (bago[j] == ')')
                        {
                            step = step + bago[j];
                            okay = false;
                        }
                        j++;
                    }

                    bago = PrintValue(bago, step);
                    i = 0; // to reset the loop;
                    step = ""; // Empty to reuse in another operation;

                }
            }
            // end parenthesis;

            // multiply;
            for (int i=0;i<bago.Length;i++)
            {
                step = "";
                if (bago[i] == '*')
                {
                    Boolean okay = true;
                    int j = i;
                    while (okay == true)
                    {

                        if (bago[j] == '+' || bago[j] == '-' || bago[j] == '/')
                        {
                            okay = false;
                        }else if (j == 0)
                        {
                            //step = substr_replace($step,substr($new,$j,1),0,0);
                            step = bago[j] + step;
                            okay = false;
                        }else
                        {
                            //$step = substr_replace($step,substr($new,$j,1),0,0);
                            step = bago[j] + step;
                        }
                        j--;
                    } // left side;
                    okay = true;
                    j = i + 1;
                    while (okay == true)
                    {

                        if (bago[j] == '+' || bago[j] == '-' || bago[j] == '/')
                        {
                            okay = false;
                        }else if (j == ((bago.Length) - 1))
                        {
                            step = step + bago[j];
                            okay = false;
                        }else
                        {
                            //$step = substr_replace($step,substr($new,$j,1),$j+1,0);
                            step = step + bago[j];
                        }
                        j++;

                    } // right side;
                    bago = PrintValue(bago, step);
                    i = 0; // to reset the loop;
                    step = ""; // Empty to reuse in another operation;
                }
            }
            // end multiply;

            //division;
            for (int i=0;i<bago.Length;i++)
            {
                step = "";
                if (bago[i] == '/')
                {
                    Boolean okay = true;
                    int j = i;
                    while (okay == true)
                    {

                        if (bago[j] == '+' || bago[j] == '-' )
                        {
                            okay = false;
                        }
                        else if (j == 0)
                        {
                            //$step = substr_replace($step,substr($new,$j,1),0,0);
                            step = bago[j] + step;
                            okay = false;
                        }
                        else
                        {
                            //$step = substr_replace($step,substr($new,$j,1),0,0);
                            step = bago[j] + step;
                        }
                        j--;
                    } // end left side;
                    okay = true;
                    j = i+1;
                    while (okay == true)
                    {
                        if(bago[j] == '+' || bago[j] == '-')
                        {
                            okay = false;
                        }else if (j == ((bago.Length)-1))
                        {
                            step = step + bago[j];
                            okay = false;
                        }else
                        {
                            //$step = substr_replace($step,substr($new,$j,1),$j+1,0);
                            step = step + bago[j];
                        }
                        j++;
                    } // right side;

                    bago = PrintValue(bago, step);
                    i = 0; // to reset the loop;
                    step = ""; // Empty to reuse in another operation;

                }
            }
            // end division;

            // addition;
            for (int i=0;i<bago.Length;i++)
            {
                step = "";
                if (bago[i] == '+')
                {
                    Boolean okay = true;
                    int j = i;
                    while(okay == true)
                    {

                        if (bago[j] == '-' || bago[j] == '/' || bago[j] == '*')
                        {
                            okay = false;
                        }else if (j == 0)
                        {
                            step = bago[j] + step;
                            okay = false;
                        }else
                        {
                            step = bago[j] + step;
                        }
                        j--;
                    } // end left side;
                    okay = true;
                    j = i + 1;
                    while (okay == true)
                    {

                        if (bago[j] == '-' || bago[j] == '/' || bago[j] == '*')
                        {
                            okay = false;
                        }else if (j == ((bago.Length)-1))
                        {
                            step = step + bago[j];
                            okay = false;
                        }else
                        {
                            step = step + bago[j];
                        }
                        j++;
                    } // right side;

                    bago = PrintValue(bago, step);
                    i = 0; // to reset the loop;
                    step = ""; // Empty to reuse in another operation;
                }
            }
            // end addition;

            // subtraction;
            for (int i=0;i<bago.Length;i++)
            {
                step = "";
                if (bago[i] == '-')
                {
                    Boolean okay = true;
                    int j = i;
                    while (okay == true)
                    {

                        if (bago[j] == '+' || bago[j] == '/' || bago[j] == '*')
                        {
                            okay = false;
                        }
                        else if (j == 0)
                        {
                            step = bago[j] + step;
                            okay = false;
                        }
                        else
                        {
                            step = bago[j] + step;
                        }
                        j--;
                    } // end left side;
                    okay = true;
                    j = i + 1;
                    while (okay == true)
                    {

                        if (bago[j] == '+' || bago[j] == '/' || bago[j] == '*')
                        {
                            okay = false;
                        }
                        else if (j == ((bago.Length) - 1))
                        {
                            step = step + bago[j];
                            okay = false;
                        }
                        else
                        {
                            step = step + bago[j];
                        }
                        j++;
                    } // right side;

                    bago = PrintValue(bago, step);
                    i = 0; // to reset the loop;
                    step = ""; // Empty to reuse in another operation;
                }
            }
            // end subtraction;





            return 0;
        }

        public Double Eval(String expression)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            return Convert.ToDouble(table.Compute(expression, String.Empty));
        }

        public string PrintValue(string bago, string step)
        {
            Computation pemdas = new Computation();
            string result = Eval(step).ToString();
            bago = bago.Replace(step, result);
            Console.WriteLine(bago); // print the step by step;

            return bago;
        }


    }
}