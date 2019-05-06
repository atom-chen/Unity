using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 输出类型
            //int i = 5;
            //Console.WriteLine(i.GetType());           ///输出i的类型

            //string a = "aaaa";
            //string b = "aaaa";
            //Console.WriteLine((object)a == (object)b);  ///判断a和b的数据是否相等
            #endregion

            #region StringBuilder
            /*
             * 推荐使用
             */
            //StringBuilder builder = new StringBuilder();///推荐使用，占用内存小
            //builder.Append("aa");                     ///添加字符
            //builder.Append("bb");
            //Console.WriteLine(builder);               ///输出所有的字符
            //builder.Append("cc");                     ///继续添加字符，内存不会重新分配（占用内存小）
            //Console.WriteLine(builder);
            //builder.AppendFormat(" dd {0} {1}", "ee","ff");///连续添加字符(" dd {0} {1}", "ee","ff")，实则添加dd ee ff
            //Console.WriteLine(builder);
            #endregion

            #region 类型装换TryParse
            /*
             * 类型装换
             * 如果需要转换的数据内容和先前定义的类型相同，则输出成功转换的数据，否则输出其他
             */
            //int x,y;
            //bool succeed = Int32.TryParse("11", out x); 
            //Console.WriteLine(x);                       ///转换成功，输出11
            //bool succeed1 = Int32.TryParse("a", out y);
            //Console.WriteLine(y);                       ///转换失败，输出0     原先y=0
            #endregion

            #region 强类型输入List<int>
            /*
             * 推荐使用
             * 列表数组，强类型输入
             */
            //List<int> intlist = new List<int>();
            //intlist.Add(1);
            //intlist.AddRange(new int[] { 2, 3 });     ///批量添加
            //intlist.Insert(1, 15);                    ///键值插入
            //foreach (var i in intlist)
            //{
            //    Console.WriteLine(i);
            //}
            //List<double> doublelist = new List<double>();
            //doublelist.Add(1);
            //doublelist.AddRange(new double[] { 2, 3 });
            //doublelist.Insert(1, 1.5);
            //foreach(var i in doublelist)
            //{
            //    Console.WriteLine(i);
            //}
            #endregion

            #region 键值对集合Dictionary<string, string>
            /*
             * 推荐使用     键值对集合
             */
            //Dictionary<string, string> d = new Dictionary<string, string>();    ///<键，值>
            //d.Add("a", "1");
            //Console.WriteLine(d["a"]);              ///输出 1
            #endregion

            #region 键值对集合,根据 键 先进行排序,SortedList<int, int>
            /*
             * 键值对集合
             * 根据 键 先进行排序
             */
            //SortedList<int, int> sl = new SortedList<int, int>();   ///<键，值>
            //sl.Add(5,105);
            //sl.Add(2, 102);
            //sl.Add(10, 99);
            //foreach(var i in sl)
            //{
            //    Console.WriteLine(i);
            /* 
             * 输出  键，值
             *   [2，102]
             *   [5，105]
             *   [10，99]
             */
            //}
            //foreach (var i in sl)
            //{
            //    Console.WriteLine(i.Value);
            /* 
             * 输出  值
             *   102
             *   105
             *   99
             */
            //}
            #endregion

            #region 堆栈  队列
            /* 
             * stack         queue
             * 堆栈         队列
             * 先进后出     先进先出
             */
            #endregion

            #region 继承测试1
            //Dog dog = new Dog();
            //dog.Age = 10;
            //dog.Bite();                             ///使用Dog 的方法
            //dog.GetAge();                           ///直接使用父类Animal 的方法
            #endregion

            #region 继承测试2
            //B b = new B();
            /*
             * 实例化B
             * B 继承 A
             * 先输出  构造函数A
             * 再输出  构造函数B
             * 结果
             *     A constructor
             *     B constructor
             */
            #endregion

            Console.ReadLine();
        }
    }
    #region 继承测试1
    //class Animal
    //{
    //    public int Age
    //    {
    //        get;
    //        set;
    //    }
    //    public virtual void Bite()                  ///virtual 继承后可以被重写
    //    {
    //        Console.WriteLine("Animal bite");
    //    }
    //    public void GetAge()
    //    {
    //        Console.WriteLine(Age);
    //    }
    //    public void BitMan()
    //    {
    //        Console.WriteLine("Animal bit man");
    //    }
    //}
    ///*
    // * 添加sealed 其他class 无法继承本class
    // */
    //sealed class Dog : Animal                              ///继承Animal
    //{
    //    public override void Bite()                 ///override 重写父类Animal 的Bite 方法
    //    {
    //        Console.WriteLine("Dog bite");
    //    }
    //    //public override void BitMan()               ///父类的BitMan 没有virtual，不能使用override
    //    //{
    //    //    Console.WriteLine("Dog bit man");
    //    //}
    //    public new void BitMan()                    ///建议添加new ，new隐藏父类的BitMan
    //    {
    //        Console.WriteLine("Dog bit man");
    //    }
    //}
    ////class LittleDog : Dog                           ///Dog中含有sealed ，则无法进行继承
    ////{

    ////}
    #endregion

    #region 继承测试2
    //class A
    //{
    //    public A()                                      ///构造函数A
    //    {
    //        Console.WriteLine("A constructor");
    //    }
    //}
    //class B : A
    //{
    //    public B()                                      ///构造函数B
    //    {
    //        Console.WriteLine("B constructor");
    //    }
    //}
    #endregion

}
