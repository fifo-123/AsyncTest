using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncTest
{
    public delegate void MyDelegate(string msg);
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //await Test();
            label1.Text = "Testing";
        }


        public void Test2(string msg)
        {
            //Program.form1.label1.Text = "Delegate method";
            label1.Text = msg;
        }

        public void Entah()
        {
            //label1.Text = "BEFORE";
            //Thread.Sleep(5000);

            //MyDelegate test = new MyDelegate(Test2); //declare and refer
            //test("Delegate 2"); //invoke

            //label1.Invoke(() => label1.Text = "Invoke");
            //label1.Invoke(test("Invoke"));

            Stopwatch sw = new Stopwatch();
            sw.Start();
            while(true)
            {
                if (sw.ElapsedMilliseconds > 5000)
                    break;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MyDelegate del = (string msg) => label1.Text = msg;
            //del("delegate test");

            MyDelegate test = new MyDelegate(Test2); //declare and refer
            test("Delegate 2"); //invoke

            //Action t = new Action()
            //Task A = new Task(Action t);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            //MyDelegate test = new MyDelegate(NewTask);
            //Task obTask = Task.Run(test("test");

            //Action a = test("ENTAH");
            //Action a = () =>
            //{
            //    Thread.Sleep(5000);
            //};
            Action b = new Action(Entah);
            //Task t = new Task(b);
            //t.Start();
            //label1.Text = "START ASYNC";

            //t.Wait();
            //label1.Text = "DONE ASYNC";


            //Task<int> task = HandleFileAsync();
            label1.Text = "START ASYNC";
            await Task.Run(b);

            Task.WaitAll();
            label1.Text = "DONE ASYNC";
        }

    }
}
