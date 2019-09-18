using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace GBX_Calculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());//题目个数                    
            Program P = new Program();
            Save file = new Save();
            DataTable dT = new DataTable();
            string result = null;           
            object ob = null;
            for (int i = 0; i < num; i++)
            {
                result =product();               
                ob = dT.Compute(result, "");
                int flag = 1;//设立标志，后面好判断结果是不是为负，是否带小数，除数是否为0                             
                if (ob.ToString().Contains(".") || result.Contains("/0") || int.Parse(ob.ToString()) < 0)//判断出现小数,除数为0,结果为负三种情况
                {
                    flag = 0;
                    i--;
                }
                if (flag == 1)
                {
                    result += "=" + ob.ToString();
                    Console.WriteLine(result);
                    file.save(result);
                }
            }
        }
        public static string Count(string result)
        {
            Program P = new Program();
            DataTable dT = new DataTable();
            string end = null;
            object ob = null;
            ob = dT.Compute(result, "");
            end = ob.ToString();
            return end;
        }
        static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        public static string product()
        {
            string[] S = new string[] { "+", "-", "*", "/" };//定义操作符号
            string result = null;//存储字符串的结果
            Random rd = new Random(GetRandomSeed()); ;//随机实例  
            int opNum = rd.Next(2, 4);//随机生成操作符个数
            int num1 = rd.Next(0, 100); //生成的算式中的第一个数字 
            result += Convert.ToString(num1);//拼接第一数字
            for (int j = 0; j < opNum; j++)
            {

                int num2 = rd.Next(0, 100);//根据操作符号的个数生成后面的数字
                int index = rd.Next(0, 4);//随机生成数组下标
                result += S[index] + Convert.ToString(num2);//拼接算式  
            }
            return result;
        }
        
    }
    public class Save
    {
        public void save(string result)
        {
            string path = @"D:\\result.txt";
            FileInfo fileInfo = new FileInfo(path);//创建本地文本文件
            StreamWriter sw = fileInfo.AppendText();
            sw.WriteLine(result);//写入
            sw.Close();//关闭
        }
    }
}
