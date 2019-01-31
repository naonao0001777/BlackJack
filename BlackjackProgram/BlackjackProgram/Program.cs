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

            Console.ReadLine();
            cpu.draw();


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
                    Console.WriteLine("想定外の文字列が入力されました。");
                }
            } while (!(player.judge));


            if (player.point > 21)
            {
                Console.WriteLine("バーストしました。");

                cpu.draw();

                if (cpu.point <= 21)
                {
                    Console.WriteLine("あなたの負け。");
                }
                else if (cpu.point > 21)
                {
                    Console.WriteLine("二人ともバーストしました。引き分け");
                }

            }
            else if (player.point <= 21)
            {
                /* Game game = new Game();
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

                 }*/
                if (cpu.point < 17)
                {
                    cpu.draw();
                }

                if (player.point == cpu.point && !(cpu.judge))
                {
                    Console.Write("引き分け");
                }
                else if (player.point > cpu.point)
                {
                    Console.Write("あなたの勝ち");
                }
                else if (player.point < cpu.point && !(cpu.judge))
                {
                    Console.Write("CPUの勝ち");
                }
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
        public string[] numbers = new string[13] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        public List<string> drawn_mark;
        public List<string> drawn_number;


        public string mark { set; get; }

        public string number { set; get; }

        public void draw()
        {
            drawn_mark = new List<string>();
            drawn_number = new List<string>();

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

            Console.WriteLine("CPUが引いたのは{0}の{1}", dc.mark, dc.number);

            if (dc.number == "A")
            {
                dc.number = "11";

                if (point > 10)
                {
                    dc.number = "1";
                }
            }
            else if (dc.number == "J" || dc.number == "Q" || dc.number == "K")
            {
                dc.number = "10";
            }

            point += int.Parse(dc.number);

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


            Console.WriteLine("あなたが引いたのは{0}の{1}", dc.mark, dc.number);

            if (dc.number == "A")
            {
                dc.number = "11";

                if (point > 10)
                {
                    dc.number = "1";
                }

            }
            else if (dc.number == "J" || dc.number == "Q" || dc.number == "K")
            {
                dc.number = "10";
            }
            
            point += int.Parse(dc.number);

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
