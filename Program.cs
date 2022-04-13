using System;
class program
{
    static void Main(string[] args)
    {
        int ar = 0;
        int hhp = 0;
        int count = 3;
        

        Console.WriteLine("Welcome to the!!");
        Console.WriteLine("Attack will attack with your players damage, heal will use a potion, which you only have three of, and pray will heal a random amount of hp!");
        Console.WriteLine();
        Console.WriteLine("Enter your players name!");
        string input = Console.ReadLine();
        Console.WriteLine("Choose a class: mage, warrior, or archer:");
        string cl = Console.ReadLine();
        if (cl == "archer")
        {
            Random rd = new Random();
            int rdd = rd.Next(13, 17);
            ar = rdd;
            hhp = 85;

        }
        else if(cl == "mage")
        {
            Random rd = new Random();
            int rdd = rd.Next(25, 35);
            ar = rdd;
            hhp = 60;
        }
        else if(cl == "warrior")
        {
            Random rd = new Random();
            int rdd = rd.Next(95, 125);
            ar = 10;
            hhp = rdd;

        }
        else
        {
            Console.WriteLine("You didn't enter a player class, defaulting to buffoon.");
            input = "You buffoon";
            Random rd = new Random();
            int rdd = rd.Next(25, 45);
            ar = 5;
            hhp = rdd;
        }
        Random r = new Random();
        int aa = r.Next(4, 7);
        int ph = r.Next(17, 25);
        int rr = r.Next(8, 13);
        int pp = r.Next(17, 29);
        int ta = r.Next(10, 16);
        int hhh = r.Next(30, 50);

        Player p1 = new Player(input, ar, hhp);
        Enemy e1 = new Enemy("Tomato", aa, ph);
        Enemy e2 = new Enemy("Cactus", rr, pp);
        Enemy e3 = new Enemy("Wolf", ta, hhh);


        Fighter[] fight = new Fighter[9];
        fight[0] = p1;
        fight[1] = e1;
        fight[2] = e2;
        fight[3] = e3;

        bool deadp = false;
        bool dead1 = false;
        bool dead2 = false;
        bool dead3 = false;
        do
        {
            p1.Turn(count, out string choi);
            if (choi == "Attack")
            {
                Console.WriteLine();
                Console.WriteLine("Do you attack the Tomato, Cactus, or Wolf?");
                string attackee = Console.ReadLine();
                if (attackee == "Tomato")
                {
                    if (e1.hp > 0)
                    {
                        Console.WriteLine("You attacked the Tomato for " + ar + " damage!");
                        e1.hp = e1.hp - ar;
                    }
                    else
                    {
                        Console.WriteLine("Congrats! You attacked a corpse!");
                    }
                    
                }
                else if (attackee == "Cactus")
                {
                    if (e2.hp > 0)
                    {
                        Console.WriteLine("You attacked the Cactus for " + ar + " damage!");
                        e2.hp = e2.hp - ar;
                    }
                    else
                    {
                        Console.WriteLine("Congrats! You attacked a corpse!");
                    }
                }
                else if (attackee == "Wolf")
                {
                    if (e3.hp > 0)
                    {
                        Console.WriteLine("You attacked the Wolf for " + ar + " damage!");
                        e3.hp = e3.hp - ar;
                    }
                    else
                    {
                        Console.WriteLine("Congrats! You attacked a corpse!");
                    }
                }
                else
                {
                    if (e1.hp > 0)
                    {
                        Console.WriteLine("You attacked the Tomato for " + ar + " damage!");
                        e1.hp = e1.hp - ar;
                    }
                    else if(e2.hp > 0)
                    {
                        Console.WriteLine("You attacked the Cactus for " + ar + " damage!");
                        e2.hp = e2.hp - ar;
                    }
                    else if (e3.hp > 0)
                    {
                        Console.WriteLine("You attacked the Wolf for " + ar + " damage!");
                        e3.hp = e3.hp - ar;
                    }

                }
                if (e1.hp < 0)
                {
                    dead1 = true;
                    Console.WriteLine(e1.name + " is dead!");
                }
                else
                {
                    Console.WriteLine(e1.name + " has " + e1.hp + " health left!");
                }
                if (e2.hp < 0)
                {
                    dead2 = true;
                    Console.WriteLine(e2.name + " is dead!");
                }
                else
                {
                    Console.WriteLine(e2.name + " has " + e2.hp + " health left!");
                }
                if (e3.hp < 0)
                {
                    dead3 = true;
                    Console.WriteLine(e3.name + " is dead!");
                }
                else
                {
                    Console.WriteLine(e3.name + " has " + e3.hp + " health left!");
                }

            }
            else if (choi == "heal")
            {
                count = count - 1;
            }

            



            e1.Turn();
            
            p1.hp = p1.hp - e1.atk;
            
            //Console.WriteLine(input + " has " + p1.hp + " health left!");
            e2.Turn();
            
            p1.hp = p1.hp - e2.atk;
            //Console.WriteLine(input + " has " + p1.hp + " health left!");
            e3.Turn();
            p1.hp = p1.hp - e3.atk;
            if (p1.hp < 0)
            {
                deadp = true;
            }
            if (deadp == true)
            {
                Console.WriteLine();
                Console.WriteLine("YOU DIED");

            }
            else
            {
                Console.WriteLine(input + " has " + p1.hp + " health left!");
            }
            

        }
        while(deadp == false && (dead1 == false || dead2 == false || dead3 == false));

        if (deadp == true)
        {
            Console.WriteLine("You lost this fight :(");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("You have slain all thine enemies!");
            Console.WriteLine("You won!");
        }
    }

    class Fighter
    {
        public string name;
        public int atk;
        public int hp;

        public Fighter(string name, int a, int h)
        {
            this.name = name;
            this.atk = a;
            this.hp = h;
        }
        
       /* public bool dead()
        {
            if(hp > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /*public void Turn()
        {
            Console.WriteLine("ATTACK!!");
        }*/
        
    }

    class Enemy : Fighter
    {
        public Enemy(string name, int a, int h)
            : base(name, a, h)
        {
            int atk = a;

        }
        

        public void Turn()
        {
            if (hp > 0)
            {
                Console.WriteLine(name + " Attacked for " + atk + " damage!");
            }
            else
            {
                atk = 0;
                
            }
            

        }
    }
    class Player : Fighter
    {
        public Player(string name, int a, int h)
            : base(name, a, h)
        {
            
            int hp = h;
            int atk = a;
            
        }
        public void Turn(int count, out string choi)
        {
            string choice;
            choi = "";
            Console.WriteLine();
            Console.WriteLine("Your turn! Type in Attack, Heal, or Pray!");
            Console.WriteLine("Attack || Heal " + count + " || Pray");
            choice = Console.ReadLine();
            Console.WriteLine();
            if (choice == "Heal")
            {
                if (count > 0)
                {
                    hp = hp + 25;
                    choi = "heal";
                    Console.WriteLine("You recovered 25 hp!");
                }
                else
                {
                    Console.WriteLine("You have no more potions!");
                    choi = "Attack";
                }
                
                
            }
            else if (choice == "Pray")
            {
                Random roar = new Random();
                int prayed = roar.Next(5, 45);
                hp = hp + prayed;
                Console.WriteLine("You recovered" + prayed + " hp!");
            }
            else
            {
                choi = "Attack";

            }
            
            
            
        }
    }


}