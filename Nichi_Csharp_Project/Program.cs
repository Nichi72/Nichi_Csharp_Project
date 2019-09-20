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
    }
    class Fix
    {
        // 피 연산자 스택
        Stack<char> stack_operand = new Stack<char>();
        // 연산자 스택
        Stack<char> stack_operator = new Stack<char>() ;
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
            arr_operatorRank[0] = new Operator('+', 2);
            arr_operatorRank[1] = new Operator('-', 2);
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
            char operatorTemp = ' ';
            for (int i = 0; i < str.Length; i++)
            {
                arr_char[i] = str[i];
            }

            for (int i = 0; i < arr_char.Length; i++)
            {
                switch(arr_char[i])
                {
                    case '+':
                        operatorTemp = arr_operatorRank[0].char_Operator;
                        break;
                    case '-':
                        operatorTemp = arr_operatorRank[1].char_Operator;
                        break;
                    case '*':
                        operatorTemp = arr_operatorRank[2].char_Operator;
                        break;
                    case '/':
                        operatorTemp = arr_operatorRank[3].char_Operator;
                        break;
                    default:
                        stack_operand.Push(arr_char[i]);
                        break;
                }
                // 연산자 스택 Top과 연산자 Temp랑 비교
                // 연산자랭크가 낮을수록 우선순위
                //('+', 2);
                //('-', 2);
                //('*', 1);
                //('/', 1);
           
                 
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
