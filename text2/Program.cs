using System.Numerics;
using System.Runtime.InteropServices;

namespace text2
{
    internal class Program
    {
        private static Character player;
        private static ItemInfo item1;
        private static ItemInfo item2;


        static void Main(string[] args)
        {
            GameDataSetting();
            DisplayGameIntro();
        }

        static void GameDataSetting()
        {
            // 캐릭터 정보 
            player = new Character("Chad", "전사", 1, 10, 5, 100, 1500);

            // 아이템 정보 
            item1 = new ItemInfo("짧은 반바지", "체온유지를 할 수 있는 옷입니다.", 0, 10, 0);
            item2 = new ItemInfo("바람개비", "수수깡과 종이로 만든 바람개비 입니다.", 2, 0, 0);
        }
        static void DisplayGameIntro()
        {
            Console.Clear();

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            int input = CheckValidInput(1, 3);
            switch (input)
            {
                case 1:
                    DisplayMyInfo();
                    break;

                case 2:
                    DisplayInventory();
                    break;
                case 3:
                    DisplayStore(); 
                    break;
            }
        }
        static void DisplayMyInfo()
        {
            Console.Clear();

            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보를 표시합니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv.{player.Level}");
            Console.WriteLine($"{player.Name}({player.Job})");
            Console.WriteLine($"공격력 : {player.Atk}");
            Console.WriteLine($"방어력 : {player.Def}");
            Console.WriteLine($"체력 : {player.Hp}");
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            if (item1.ItemName == "[E] 짧은 반바지" && item2.ItemName != "[E] 바람개비")
            {
                Console.Clear();

                Console.WriteLine("상태보기");
                Console.WriteLine("캐릭터의 정보를 표시합니다.");
                Console.WriteLine();
                Console.WriteLine($"Lv.{player.Level}");
                Console.WriteLine($"{player.Name}({player.Job})");
                Console.WriteLine($"공격력 : {player.Atk}");
                Console.WriteLine($"방어력 : {player.Def} +({item1.ItemDef + item2.ItemDef})");
                Console.WriteLine($"체력 : {player.Hp}");
                Console.WriteLine($"Gold : {player.Gold} G");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
            }
            else if (item2.ItemName == "[E] 바람개비" && item1.ItemName != "[E] 짧은 반바지")
            {
                Console.Clear();

                Console.WriteLine("상태보기");
                Console.WriteLine("캐릭터의 정보를 표시합니다.");
                Console.WriteLine();
                Console.WriteLine($"Lv.{player.Level}");
                Console.WriteLine($"{player.Name}({player.Job})");
                Console.WriteLine($"공격력 : {player.Atk} +({item1.ItemAtk + item2.ItemAtk})");
                Console.WriteLine($"방어력 : {player.Def}");
                Console.WriteLine($"체력 : {player.Hp}");
                Console.WriteLine($"Gold : {player.Gold} G");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
            }
            else if (item1.ItemName == "[E] 짧은 반바지" && item2.ItemName == "[E] 바람개비")
            {
                Console.Clear();

                Console.WriteLine("상태보기");
                Console.WriteLine("캐릭터의 정보를 표시합니다.");
                Console.WriteLine();
                Console.WriteLine($"Lv.{player.Level}");
                Console.WriteLine($"{player.Name}({player.Job})");
                Console.WriteLine($"공격력 : {player.Atk} +({item1.ItemAtk + item2.ItemAtk})");
                Console.WriteLine($"방어력 : {player.Def} +({item1.ItemDef + item2.ItemDef})");
                Console.WriteLine($"체력 : {player.Hp}");
                Console.WriteLine($"Gold : {player.Gold} G");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
            }
            int input = CheckValidInput(0, 0);

            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }


        static void DisplayInventory()
        {
            Console.Clear();

            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine($"- {item1.ItemName}    " + $" | 방어력 +{item1.ItemDef} | {item1.ItemDescription}");
            Console.WriteLine($"- {item2.ItemName}    " + $" | 공격력 +{item2.ItemAtk} | {item2.ItemDescription}");
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            int input = CheckValidInput(0, 1);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
                case 1:
                    EquipItemManagement();
                    break;
            }
        }
        static void EquipItemManagement()
        {
            Console.Clear();

            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("아이템을 장착하거나 해제합니다");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine($"- 1 {item1.ItemName}    " + $" | 방어력 +{item1.ItemDef} | {item1.ItemDescription}");
            Console.WriteLine($"- 2 {item2.ItemName}    " + $" | 공격력 +{item2.ItemAtk} | {item2.ItemDescription}");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("장착할 아이템 번호를 입력해주세요.");
            Console.WriteLine("이미 장착하고 있을 경우 해제합니다.");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            int input = CheckValidInput(0, 2);
            switch (input)
            {
                case 0:
                    DisplayInventory();
                    break;
                case 1:
                                       
                    if (item1.ItemName == "짧은 반바지")
                    {
                        item1.ItemName = "[E] 짧은 반바지";

                        player.Atk += item1.ItemAtk;
                        player.Def += item1.ItemDef;
                        player.Hp += item1.ItemHp;
                    }
                    else
                    {
                        item1.ItemName = "짧은 반바지";

                        player.Atk -= item1.ItemAtk;
                        player.Def -= item1.ItemDef;
                        player.Hp -= item1.ItemHp;
                    }
                    EquipItemManagement();
                    break;
                case 2:
                    if (item2.ItemName == "바람개비")
                    {
                        item2.ItemName = "[E] 바람개비";

                        player.Atk += item2.ItemAtk;
                        player.Def += item2.ItemDef;
                        player.Hp += item2.ItemHp;
                    }
                    else
                    {
                        item2.ItemName = "바람개비";

                        player.Atk -= item2.ItemAtk;
                        player.Def -= item2.ItemDef;
                        player.Hp -= item2.ItemHp;
                    }
                    EquipItemManagement();
                    break;
            }
        }

        static void DisplayStore()
        {
            Console.Clear();

            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine("800 G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("- 난닝구 | 방어력 +5 | 체온유지를 할 수 있는 옷입니다.          |   1000 G");
            Console.WriteLine("- 짧은 반바지 | 방어력 +9 |  중요부위를 가릴 수 있는 옷입니다.  |   구매완료");
            Console.WriteLine("- 밀짚 모자 | 방어력 +15 | 허수아비가 사용했던 모자입니다.      |   3500 G");
            Console.WriteLine("- 바람개비 | 공격력 +2 | 수수깡과 종이로 만든 바람개비 입니다.  |   600 G");
            Console.WriteLine("- 고무 망치 | 공격력 +5 | 고무로 만들어진 망치 입니다.          |   1500 G");
            Console.WriteLine("- 죽도 | 공격력 +7 | 대나무로 만들어진 검 입니다.               |   구매완료");
            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            int input = CheckValidInput(0, 1);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
                case 1:
                    ItemBuy();
                    break;
            }
        }

        static void ItemBuy()
        {
            Console.Clear();

            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine("800 G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("- 1. 난닝구 | 방어력 +5 | 체온유지를 할 수 있는 옷입니다.          |   1000 G");
            Console.WriteLine("- 2. 짧은 반바지 | 방어력 +9 |  중요부위를 가릴 수 있는 옷입니다.  |   구매완료");
            Console.WriteLine("- 3. 밀짚 모자 | 방어력 +15 | 허수아비가 사용했던 모자입니다.      |   3500 G");
            Console.WriteLine("- 4. 바람개비 | 공격력 +2 | 수수깡과 종이로 만든 바람개비 입니다.  |   600 G");
            Console.WriteLine("- 5. 고무 망치 | 공격력 +5 | 고무로 만들어진 망치 입니다.          |   1500 G");
            Console.WriteLine("- 6. 죽도 | 공격력 +7 | 대나무로 만들어진 검 입니다.               |   구매완료");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            int input = CheckValidInput(0, 0);

            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }


        static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    }

    public class ItemInfo
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; }
        public int ItemAtk { get; set; }
        public int ItemDef { get; set; }
        public int ItemHp { get; set; }

        public ItemInfo(string itemname, string itemdes, int itematk, int itemdef, int itemhp)
        {
            ItemName = itemname;
            ItemDescription = itemdes;
            ItemAtk = itematk;
            ItemDef = itemdef;
            ItemHp = itemhp;
        }
    }



    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public int Gold { get; }

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }
}