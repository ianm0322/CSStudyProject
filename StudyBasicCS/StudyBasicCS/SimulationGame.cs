using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace StudyBasicCS
{

    class SimulationGame
    {
        // 상수
        private const int ENDING_STAGE = 99;

        // 게임 데이터
        private int stage = 0;
        private int ending = 0;
        private int choice = 0;
        private bool hasLegendItem = false;

        // 축적 데이터
        private int deathByTrapCounter = 0;
        public void Main()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("게임을 시작하시겠습니까? [ Y / N ]");
                Console.Write("입력: ");
                string input = Console.ReadLine();
                if (input == "Y")
                {
                    StartGame();
                }
                else if (input == "N")
                {
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        public void InitGameData()
        {
            stage = 0;
            ending = 0;
            choice = 0;
            hasLegendItem = false;
        }

        public void StartGame()
        {
            while (true)
            {
                switch (stage)
                {
                    case 0:
                        // Log
                        Console.Clear();
                        Console.WriteLine("[던전입구]");
                        Console.WriteLine("");
                        // Choices
                        Console.WriteLine("1. 던전에 들어간다.");
                        Console.WriteLine("0. 집으로 돌아간다.");
                        Console.WriteLine("");
                        // Input & Processing
                        bool isExit = false;
                        while (!isExit)
                        {
                            Console.Write("\n선택지를 고르시오: ");
                            try
                            {
                                choice = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                choice = 0;
                            }
                            // Process
                            switch (choice)
                            {
                                case 1:
                                    stage = 1;
                                    isExit = true;
                                    Console.Clear();
                                    break;
                                case 0:
                                    stage = ENDING_STAGE;
                                    ending = 1;
                                    isExit = true;
                                    Console.Clear();
                                    break;
                                default:
                                    Console.Write("잘못된 선택지. ");
                                    break;
                            }
                        }
                        break;
                    case 1:
                        // Log
                        Console.WriteLine("[1층: 함정방]");
                        if (deathByTrapCounter > 0)
                        {
                            Console.WriteLine($"[{deathByTrapCounter}구의 주검이 너저분하게 널부러져 있다.]");
                        }
                        Console.WriteLine("[함정이 있는 듯하다. 어떻게 할까?]");
                        Console.WriteLine("");
                        // Choices
                        Console.WriteLine("1. 민첩하게 함정을 돌파한다.");
                        Console.WriteLine("2. 용감하게 함정을 돌파한다.");
                        Console.WriteLine("3. 벽을 살핀다.");
                        Console.WriteLine("0. 함정이다 이얏호!(함정에 뛰어든다.)");
                        Console.WriteLine("");
                        // Input & Processing
                        isExit = false;
                        while (!isExit)
                        {
                            Console.Write("\n선택지를 고르시오: ");
                            try
                            {
                                choice = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                choice = 0;
                            }
                            // Process
                            switch (choice)
                            {
                                case 1:
                                    stage = 2;
                                    isExit = true;
                                    Console.Clear();
                                    Console.WriteLine("종이 한 장 차이로 함정을 피했다!");
                                    break;
                                case 2:
                                    isExit = true;
                                    Console.Clear();
                                    Console.WriteLine("\"아무도 날 막을 수 없으셈ㅋㅋ\"");
                                    if (hasLegendItem == true)
                                    {
                                        stage = 2;
                                        Console.WriteLine("함정이 날아오는 족족 B.F.G.로 폭파시켜 통과했다.");
                                    }
                                    else
                                    {
                                        stage = ENDING_STAGE;
                                        ending = 3;
                                    }
                                    break;
                                case 3:
                                    stage = 3;
                                    isExit = true;
                                    break;
                                case 0:
                                    stage = ENDING_STAGE;
                                    ending = 2;
                                    isExit = true;
                                    break;
                                default:
                                    Console.Write("잘못된 선택지. ");
                                    break;
                            }
                        }
                        break;
                    case 2:             // 함정 회피 이벤트
                                        // Log
                        Console.WriteLine("[2층: 보물의 방]");
                        Console.WriteLine("[눈앞에 괴물이 나타났다. 어떻게 할까?]");
                        Console.WriteLine("");
                        // Choices
                        Console.WriteLine("1. 설득한다.");
                        if (hasLegendItem)
                        {
                            Console.WriteLine("2. 『설득력』있게 설득한다.");
                        }
                        Console.WriteLine("0. 집으로 돌아간다.");
                        Console.WriteLine("");
                        // Input & Processing
                        isExit = false;
                        while (!isExit)
                        {
                            Console.Write("\n선택지를 고르시오: ");
                            try
                            {
                                choice = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                choice = 0;
                            }
                            // Process
                            switch (choice)
                            {
                                case 1:
                                    stage = ENDING_STAGE;
                                    ending = 4;
                                    isExit = true;
                                    Console.Clear();
                                    break;
                                case 2:
                                    if (hasLegendItem)
                                    {
                                        stage = ENDING_STAGE;
                                        ending = 5;
                                        isExit = true;
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        Console.Write("잘못된 선택지. ");
                                    }
                                    break;
                                case 0:
                                    stage = ENDING_STAGE;
                                    ending = 1;
                                    isExit = true;
                                    Console.Clear();
                                    break;
                                default:
                                    Console.Write("잘못된 선택지. ");
                                    break;
                            }
                        }
                        break;
                    case 3:             // 비밀문 이벤트
                                        // Log
                        Console.Clear();
                        Console.WriteLine("[???층: 비밀스러운 공간]");
                        Console.WriteLine("[벽을 더듬자 마법으로 감춰진 비밀통로가 모습을 드러냈다.]");
                        Console.WriteLine("[어두운 계단참을 더듬어 도달한 곳에 있는 건 찬양하라 B.F.G.!!]");
                        Console.WriteLine("[\"오, B.F.G. 최고의 대화수단이지.\"]");
                        Console.WriteLine("");
                        // Choices
                        Console.WriteLine("1. B.F.G.를 챙긴다.");
                        Console.WriteLine("0. 쫄보처럼 도망친다.");
                        Console.WriteLine("");
                        // Input & Processing
                        isExit = false;
                        while (!isExit)
                        {
                            Console.Write("\n선택지를 고르시오: ");
                            try
                            {
                                choice = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                choice = 0;
                            }
                            // Process
                            switch (choice)
                            {
                                case 1:
                                    stage = 1;
                                    hasLegendItem = true;
                                    isExit = true;
                                    Console.Clear();
                                    break;
                                case 0:
                                    stage = 1;
                                    isExit = true;
                                    Console.Clear();
                                    break;
                                default:
                                    Console.Write("잘못된 선택지. ");
                                    break;
                            }
                        }
                        break;
                    case ENDING_STAGE:
                        switch (ending)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("[ E N D I N G ]");
                                Console.WriteLine("");
                                Console.WriteLine("당신은 도망치셨습니다.");
                                Console.WriteLine("겁 쟁 이 !");
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("[ E N D I N G ]");
                                Console.WriteLine("");
                                Console.WriteLine("당신은 콧노래를 부르며 함정에 뛰어들었습니다.");
                                Console.WriteLine("결과는... 굳이 말해야 할까요?");
                                deathByTrapCounter++;
                                break;
                            case 3:
                                Thread.Sleep(1500);
                                Console.WriteLine("[ E N D I N G ]");
                                Console.WriteLine("");
                                Console.WriteLine("당신의 무모한 용기는 무적의 방패가 아니었습니다.");
                                Console.WriteLine("날카로운 톱날이 당신의 살을 뭉갰고,");
                                Console.WriteLine("처량한 주검이 던전에 쌓일 뿐이었습니다.");
                                deathByTrapCounter++;
                                break;

                            case 4:
                                Console.Clear();
                                Console.WriteLine("[ E N D I N G ]");
                                Console.WriteLine("");
                                Console.WriteLine("당신은 괴물을 필사적으로 설득했습니다.");
                                Thread.Sleep(1500);
                                Console.WriteLine("당신은 그 어느 때보다 달변가였고, 괴물은 당신 말에 감명 받아 말합니다.");
                                Thread.Sleep(1500);
                                Console.WriteLine("");
                                Console.WriteLine("\"Oh, I can't speak Korean. 한쿡말 몰롸요우.\"");
                                Console.WriteLine("");
                                Thread.Sleep(2500);
                                Console.WriteLine("당신은 빈손으로 고향에 돌아와야 했습니다.");
                                Console.WriteLine("하지만... 사실 지금까지의 여정과 모험이 진정한 보물이 아니었을까요?");
                                break;
                            case 5:
                                Console.Clear();
                                Console.WriteLine("[ H I D D E N      E N D I N G ]");
                                Console.WriteLine("");
                                Console.WriteLine("당신은 괴물을 필사적으로 설득했습니다.");
                                Thread.Sleep(1500);
                                Console.WriteLine("당신은 그 어느 때보다 달변가였고, 괴물은 당신 말에 감명 받아 말합니다.");
                                Thread.Sleep(1500);
                                Console.WriteLine("");
                                Console.WriteLine("\"Oh, I can't speak Korean. 한쿡말 몰롸요우.\"");
                                Console.WriteLine("");
                                Thread.Sleep(2500);
                                Console.WriteLine("그러나 당신은 당황하지 않고 만국공통어 B.F.G.를 꺼내들었습니다.");
                                Thread.Sleep(1500);
                                Console.WriteLine("");
                                Console.WriteLine("\"아, 이러면 말이 달라지지ㅋㅋㅋㅋ\"");
                                Console.WriteLine("");
                                Thread.Sleep(1500);
                                Console.WriteLine("당신은 괴물이 가진 보물과 함께 고향에 돌아왔습니다.");
                                Thread.Sleep(1500);
                                Console.WriteLine("하지만... 사실 새로운 친구와의 만남이 진정한 보물이 아니었을까요?");
                                Thread.Sleep(1500);
                                Console.WriteLine("당신의 진솔한 친구, 『B.F.G.』말입니다.");
                                break;
                            default:
                                Console.WriteLine("[ E N D I N G ]");
                                Console.WriteLine("");
                                Console.WriteLine("아무래도 던전에 문제가 있나 봅니다.");
                                throw new Exception($"ending error: {ending} is incorrect number.");
                        }
                        InitGameData();
                        Console.WriteLine();
                        Console.WriteLine("계속하기 위해 엔터를 입력하시오.");
                        Console.ReadLine();
                        Console.Clear();
                        return;
                    default:
                        // Log
                        Console.WriteLine("[Error층: 에러의 방]");
                        Console.WriteLine("[문제가... 후... 생겼습니다.]");
                        throw new Exception($"stage error: {stage} is incorrect number.");
                }
            }
        }
    }
}
