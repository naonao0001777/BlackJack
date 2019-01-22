using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackProgram
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ゲームを開始します。");
            Console.ReadKey();
            CPU cpu = new CPU();
            cpu.draw();

            Player player = new Player();
            while (player.point<=21)
            {
                Console.WriteLine("カードを引きますか？(Y/N)");
                string option = Console.ReadLine();

                if (option == "y" || option == "Y")
                {
                    player.draw();

                }
                else if (option == "n" || option == "N")
                {
                    Console.Write("終了します。");
                }
                else
                {
                    Console.Write("想定外の文字列が入力されました。");
                }
            }
           
            Console.ReadKey();
        }
    }
    public class CardDraw
    {
        public string[] marks = new string[4] { "スペード", "クラブ", "ダイヤ", "ハート" };
        public string []number = new string [13] {"1","2","3","4","5","6","7","8","9","10","11","12","13" };

        public void draw()
        {
            Random r1 = new System.Random();
            int random_m = r1.Next(3);

            Random r2 = new System.Random();
            int random_n = r2.Next(12);

            CardDraw cd = new CardDraw();
            string mark = cd.marks[random_m];
            string number = cd.number[random_n];
        }
        //Console.WriteLine("CPUが引いたのは{0}の{1}",mark,number);
    }

    public class CPU
    {
        public string mark { set; get; }

        public string number { set; get; }

        public int point { set; get; }

        public void draw()
        {
            //ランダムでカードを引く
            Random r1 = new System.Random();
            int random_m = r1.Next(3);

            Random r2 = new System.Random();
            int random_n = r2.Next(12);

            CardDraw card = new CardDraw();

            string mark = card.marks[random_m];
            string number = card.number[random_n];

            CPU cpu = new CPU();
            cpu.point = int.Parse(number);

            Console.WriteLine("CPUが引いたのは{0}の{1}",mark,number);
        }
    }
    public class Player
    {
        public string mark { set; get; }

        public string number { set; get; } 

        public int point { set; get; }

        public void draw()
        {
            Random r1 = new System.Random();
            int random_m = r1.Next(3);

            Random r2 = new System.Random();
            int random_n = r2.Next(12);

            CardDraw card = new CardDraw();

            string mark = card.marks[random_m];
            string number = card.number[random_n];

            Player player = new Player();
            player.point = int.Parse(number);

            Console.WriteLine("あなたが引いたのは{0}の{1}", mark, number);
        }
    }
    public class Game
    {
        void Compare()
        {
            CPU cpu = new CPU();
            int cpuNum = int.Parse(cpu.number);

            Player player = new Player();
            int pleyerNum = int.Parse(player.number);


        }
    }
}
