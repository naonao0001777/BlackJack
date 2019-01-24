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
            do
            {
                cpu.draw();

            } while (cpu.point <= 17);

            Player player = new Player();
            do
            {
                Console.WriteLine("カードを引きますか？(Y/N)");
                string option = Console.ReadLine();

                if (option == "y" || option == "Y")
                {
                    player.draw();

                }
                else if (option == "n" || option == "N")
                {
                    break;
                }
                else
                {
                    Console.Write("想定外の文字列が入力されました。");
                }
            } while (!(player.judge));

            if (player.judge)
            {
                Game game = new Game();
                int win = game.compare();

                if (win == 0)
                {
                    Console.Write("CPUの勝ち");
                }
                else if (win == 1)
                {
                    Console.Write("あなたの勝ち");
                }
                else if (win == 2)
                {
                    Console.Write("引き分け");

                }
            }
            else if (player.point > 21)
            {
                Console.Write("バーストしました。");
            }

            Console.ReadKey();
        }
    }
    /**
     * カードを引く処理をします
     * 
     */
    public class DrawCard
    {
        public string[] marks = new string[4] { "スペード", "クラブ", "ダイヤ", "ハート" };
        public string[] numbers = new string[13] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" };

        public List<string> drawn_mark = new List<string>();
        public List<string> drawn_number = new List<string>();

        public string mark { set; get; }

        public string number { set; get; }

        public void draw()
        {

            do
            {
                Random r1 = new System.Random();
                int random_mark = r1.Next(3);

                Random r2 = new System.Random();
                int random_number = r2.Next(12);

               
                mark = marks[random_mark];
                number = numbers[random_number];

            } while (drawn_mark.Contains(mark) && drawn_number.Contains(number));

            drawn_mark.Add(mark);
            drawn_number.Add(number);
        }
    }
    /**
     * CPUの処理をします
     * 
     */
    public class CPU
    {
        public string mark { set; get; }

        public string number { set; get; }

        public int point { set; get; }

        public bool judge = false;

        public void draw()
        {

            DrawCard dc = new DrawCard();
            dc.draw();

            //CPU cpu = new CPU();
            point += int.Parse(dc.number);

            Console.WriteLine("CPUが引いたのは{0}の{1}", dc.mark, dc.number);

            if (point > 21)
            {
                judge = true;
            }
        }
    }
    /**
     * プレイヤーの処理をします
     * 
     */
    public class Player
    {
        public string mark { set; get; }

        public string number { set; get; }

        public int point { set; get; }

        public bool judge = false;

        public void draw()
        {

            DrawCard dc = new DrawCard();
            dc.draw();

            //Player player = new Player();
            point += int.Parse(dc.number);

            Console.WriteLine("あなたが引いたのは{0}の{1}", dc.mark, dc.number);

            if (point > 21)
            {
                judge = true;
            }
        }
    }
    /**
     *勝ち負け判定をします 
     * 
     */
    public class Game
    {
        public int win { set; get; }

        public int compare()
        {
            CPU cpu = new CPU();

            Player player = new Player();


            if (cpu.point < player.point)
            {
                return 1;//playerが勝ったら1を返す
            }
            else if (cpu.point > player.point)
            {
                return 0;//cpuが勝ったら0を返す
            }
            else
            {
                return 2;//引き分けならば2を返す
            }


        }
    }
}
