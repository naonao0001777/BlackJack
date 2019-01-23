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
            } while (player.judge == true);

            Game game = new Game();
            int win = game.compare(game.win);

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
        public string []numbers = new string [13] {"1","2","3","4","5","6","7","8","9","10","11","12","13" };

        public List<string> drawn_mark = new List<string>();

        public string mark { set; get; }

        public string number { set; get; }

        public void draw(int number)
        {

            do
            {
                Random r1 = new System.Random();
                int random_mark = r1.Next(3);

                Random r2 = new System.Random();
                int random_number = r2.Next(12);

                DrawCard dc = new DrawCard();
                mark = dc.marks[random_mark];
                number = dc.numbers[random_number];

                drawn_mark.Add(mark);

            } while (!(drawn_mark.Contains(mark)));
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

        public bool judge = true;

        public void draw()
        {

            DrawCard dc = new DrawCard();
            dc.draw();

            CPU cpu = new CPU();
            cpu.point += int.Parse(dc.number);

            Console.WriteLine("CPUが引いたのは{0}の{1}", dc.mark, dc.number);

            if (cpu.point > 21)
            {
                cpu.judge = false;
                Console.WriteLine("バーストしました");
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

        public bool judge = true;

        public void draw()
        {

            DrawCard dc = new DrawCard();
            dc.draw();

            Player player = new Player();
            player.point += int.Parse(dc.number);
            
            Console.WriteLine("あなたが引いたのは{0}の{1}", dc.mark, dc.number);

            if (player.point > 21)
            {
                player.judge = false;
                Console.WriteLine("バーストしました");
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

        public int compare(int win)
        {
            CPU cpu = new CPU();
            
            Player player = new Player();

            
            if (cpu.point < player.point)
            {
                return 1;//playerが勝ったら1を返す
            }
            else if(cpu.point > player.point)
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
