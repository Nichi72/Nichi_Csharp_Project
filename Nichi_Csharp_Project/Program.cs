using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Nichi_Csharp_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                string str = Console.ReadLine();
                Fix fix = new Fix();
                fix.postFix(str);
                Console.WriteLine();
            }
        
        }
    }

    class Operator
    {
        public char char_Operator;
        public int operatorRank;
        public Operator(char char_Operator, int operatorRank)
        {
            this.char_Operator = char_Operator;
            this.operatorRank = operatorRank;
        }
        public Operator()
        {

        }

    }
    class Fix
    {
        // 피 연산자 스택
        Stack<char> stack_operand = new Stack<char>();
        // 연산자 스택
        Stack<Operator> stack_operator = new Stack<Operator>() ;
        // 중위 표기법
        //char[,] arr_operatorRank = new char[,] {
        //{'+',3 },
        //{'-','3' },
        //{'*','2' },
        //{'/','2' },
        //};
        Operator[] arr_operatorRank = new Operator[4];

        public Fix()
        {
            arr_operatorRank[0] = new Operator('+', 5);
            arr_operatorRank[1] = new Operator('-', 5);
            arr_operatorRank[2] = new Operator('*', 1);
            arr_operatorRank[3] = new Operator('/', 1);
        }
     
        public void InFix()
        {

        }
        // 후위 표기법
        public void postFix(String str)
        {
            char[] arr_char = new char[str.Length];
            string outStr = null;
            Operator operatorTemp =new Operator();
            for (int i = 0; i < str.Length; i++)
            {
                arr_char[i] = str[i];
            }

            for (int i = 0; i < arr_char.Length; i++)
            {
                switch(arr_char[i])
                {
                    case '+':
                        operatorTemp = arr_operatorRank[0];
                        break;
                    case '-':
                        operatorTemp = arr_operatorRank[1];
                        break;
                    case '*':
                        operatorTemp = arr_operatorRank[2];
                        break;
                    case '/':
                        operatorTemp = arr_operatorRank[3];
                        break;
                    default:
                        stack_operand.Push(arr_char[i]);
                        break;
                }
                // 연산자 스택 Top과 연산자 Temp랑 비교
                // 연산자랭크가 높을수록 우선순위
                //('+', 5);
                //('-', 5);
                //('*', 1);
                //('/', 1);

                // 문제점
                // 맨 처음에는 피연산자 하나 연산자 NUll이라 비교를 못함.

                // * > + 라면 
                if (operatorTemp.operatorRank > stack_operator.Peek().operatorRank)
                {
                    stack_operator.Push(operatorTemp);
                }
                // + < * 라면
                else if(operatorTemp.operatorRank < stack_operator.Peek().operatorRank)
                {
                    int temp = (int)stack_operand.Pop() + (int)stack_operand.Pop();
                    outStr = temp.ToString();

                    outStr += stack_operator.Pop().char_Operator;
                }
           
                 
            }


            foreach(char a in arr_char)
            {
                Console.Write(a);
            }
        }
        // 전위 표기법 
        public void preFix()
        {

        }
    }


}
