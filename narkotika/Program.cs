using System;

namespace narkotika
{
    //TODO: 
    
    enum Drugs
    {
        EMPTY,
        HASH,
        COCAINE,
        KROKODIL,
        M_JANE,
        

    }

    
    enum Commands
    {
        VISLAGER,
        KOB
    }

    class Item
    {
        int id;
        double amount;

        string name;

        public Item(int _id, double _amount)
        {

            switch(_id)
            {

                case (int)Drugs.EMPTY:

                    id = (int)Drugs.EMPTY;

                    amount = 0;

                    name = "Empty";

                    break;

                case (int)Drugs.HASH:

                    id = (int)Drugs.HASH;

                    amount = _amount > 0 ? _amount : 1;

                    name = "Hash";

                    break;

                case (int)Drugs.COCAINE:

                    id = (int)Drugs.COCAINE;

                    amount = _amount > 0 ? _amount : 1;

                    name = "Cocaine";

                    break;

                case (int)Drugs.M_JANE:

                    id = (int)Drugs.M_JANE;

                    amount = _amount > 0 ? _amount : 1;

                    name = "Marijuana";
                    
                    break;

                case (int)Drugs.KROKODIL:

                    id = (int)Drugs.KROKODIL;

                    amount = _amount > 0 ? _amount : 1;

                    name = "Krokodil";
                    
                    break;

                default:

                id = (int)Drugs.EMPTY;
                amount = 0;
                name = "Empty";

                break;
            }
            
        }

        public Item()
        {
            id = -1;
            amount = -1;
            name = "null";
        }
        public int ID
        {
            get {return id;}
            
        }

        public string Name
        {
            get {return name;}
        }

        public double Amount
        {
            get{return amount;}
            set{amount = value;}
        }

    }
    class Program
    {
        
        public static double[] DrugPrices = new double[] { //i DKK, pris per gram
            1, //empty
            74.19, //hash
            163.7, //cocaine
            340.69, //krokodil
            77.2 //marry jane
        };

        static double playerCash = 2500; //DKK
        static Item[] lager = new Item[25];
        static int GetCommandIDfromInput(string input)
        {
            int result;

            if(Enum.IsDefined(typeof(Commands), input.ToUpper()))
            {
                result = (int)Enum.Parse(typeof(Commands), input.ToUpper());
            }
            else result = -1;
            return result;

        }

        static void LaunchCommand(int id)
        {
            switch(id)
            {
                case (int)Commands.VISLAGER:
                
                //show inventory
                CMD_VisLager();

                return;

                case (int)Commands.KOB:

                //buy drugs, with amount
                CMD_Buy();
                return;

                default:

                System.Console.WriteLine("Fokerte indtasting ID: {0}", id);

                return;
            }
        }

        static void CMD_VisLager()
        {
            System.Console.WriteLine(" *** NARKOTIKA PÅ LAGER ***");

            System.Console.WriteLine("Navn:\t\tAmount(grams):");

            for(int i = 0; i < lager.Length; i++) Console.Write($"{i.ToString()}. {lager[i].Name}\t\t{lager[i].Amount.ToString()}\n");
            
        }

        static void CMD_Buy()
        {
            System.Console.WriteLine(" * Indtast hvilken narkotika vil du gerne køb");

            

            int counter = -1;
            foreach(string name in Enum.GetNames(typeof(Drugs)))
            {
                counter++;
                if(name == "EMPTY") continue;
                Console.Write($"{counter}. {name}\n");
            }

            System.Console.WriteLine(" * Indast din valg(tal)");

            Console.Write(">");

            string input = Console.ReadLine();

            System.Console.WriteLine(" * Skriv hvor mange gram vil du gerne køb:");
            Console.Write(">");

            string quantity = Console.ReadLine();

            int drug = -1;
            int amount = -1;

            if(Int32.TryParse(input, out drug) && Int32.TryParse(quantity, out amount))
            {
                int slot = -1;
                double price = 0;
                
                switch(drug)
                {
                    case (int)Drugs.COCAINE:
                    
                    slot = IsDrugInInventory((int)Drugs.COCAINE); //should instead find the sum of cocaine in inventory

                    if( slot != -1)
                    {
                        if(!CanPlayerAfford((int)Drugs.COCAINE, amount))
                        {
                            System.Console.WriteLine("Du har ikke nok penge for dit narkotika :(");
                            return;
                        }

                        if(amount > lager[slot].Amount)
                        {
                            System.Console.WriteLine("Der er ikke nok narkotika på lager for dig.");
                        }
                        else {
                            lager[slot].Amount -= amount;
                            price = DrugPrices[(int)Drugs.COCAINE] * amount;

                            playerCash -= price;


                            System.Console.WriteLine($"Du har købt {amount}g af kokain for {price.ToString()} DKK.\nKokain tilbage på lager(slot {slot}): {lager[slot].Amount}.");
                            System.Console.WriteLine($" * Penge tilbage: {playerCash.ToString()}");
                        }
                    }
                    else System.Console.WriteLine("Vi har ikke nogen kokain på lager.");

                    return;

                    case (int)Drugs.KROKODIL:
                    
                    slot = IsDrugInInventory((int)Drugs.KROKODIL);

                    if( slot != -1)
                    {
                        if(!CanPlayerAfford((int)Drugs.KROKODIL, amount))
                        {
                            System.Console.WriteLine("Du har ikke nok penge for dit narkotika :(");
                            return;
                        }
                        if(amount > lager[slot].Amount)
                        {
                            System.Console.WriteLine("Der er ikke nok narkotika på lager for dig.");
                        }
                        else {
                            lager[slot].Amount -= amount;
                            price = DrugPrices[(int)Drugs.KROKODIL] * amount;

                            playerCash -= price;


                            System.Console.WriteLine($"Du har købt {amount}g af krokodil for {price.ToString()} DKK.\nKrokodil tilbage på lager(slot {slot}): {lager[slot].Amount}.");
                            System.Console.WriteLine($" * Penge tilbage: {playerCash.ToString()}");
                            
                        }
                    }
                    else System.Console.WriteLine("Vi har ikke nogen krokodil på lager.");
                    return;

                    case (int)Drugs.M_JANE:
                    
                    slot = IsDrugInInventory((int)Drugs.M_JANE);

                    if( slot != -1)
                    {
                        if(!CanPlayerAfford((int)Drugs.M_JANE, amount))
                        {
                            System.Console.WriteLine("Du har ikke nok penge for dit narkotika :(");
                            return;
                        }

                        if(amount > lager[slot].Amount)
                        {
                            System.Console.WriteLine("Der er ikke nok narkotika på lager for dig.");
                        }
                        else {
                            lager[slot].Amount -= amount;
                            price = DrugPrices[(int)Drugs.M_JANE] * amount;

                            playerCash -= price;


                            System.Console.WriteLine($"Du har købt {amount}g af marijuana for {price.ToString()} DKK.\nMarijuana tilbage på lager(slot {slot}): {lager[slot].Amount}.");
                            System.Console.WriteLine($" * Penge tilbage: {playerCash.ToString()}");
                        }
                    }
                    else System.Console.WriteLine("Vi har ikke nogen marijuana på lager.");
                    return;

                    case (int)Drugs.HASH:
                    
                    slot = IsDrugInInventory((int)Drugs.HASH);

                    if( slot != -1)
                    {
                        if(!CanPlayerAfford((int)Drugs.HASH, amount))
                        {
                            System.Console.WriteLine("Du har ikke nok penge for dit narkotika :(");
                            return;
                        }
                        

                        if(amount > lager[slot].Amount)
                        {
                            System.Console.WriteLine("Der er ikke nok narkotika på lager for dig.");
                        }
                        else {
                            lager[slot].Amount -= amount;

                            price = DrugPrices[(int)Drugs.HASH] * amount;

                            playerCash -= price;
                            


                            System.Console.WriteLine($"Du har købt {amount}g af hash for {price.ToString()} DKK.\nHash tilbage på lager(slot {slot}): {lager[slot].Amount}.");
                            System.Console.WriteLine($" * Penge tilbage: {playerCash.ToString()}");
                            
                        }
                    }
                    else System.Console.WriteLine("Vi har ikke nogen hash på lager.");
                    return;
                }
            }
            else System.Console.WriteLine("Invalid Input.");
        }

        static int IsDrugInInventory(int drugid)
        {
            int slot = -1;


            for(int i = 0; i < lager.Length; i++)
            {
                if(lager[i].ID == drugid){
                    slot = i;
                    break;
                }
            }
            return slot;
        }

        static bool CanPlayerAfford(int id, int grams)
        {
            if(grams < 1) return false;

            switch(id)
            {
                case (int)Drugs.COCAINE:
                if(DrugPrices[(int)Drugs.COCAINE] * grams > playerCash) return false;
                return true;

                case (int)Drugs.KROKODIL:
                if(DrugPrices[(int)Drugs.KROKODIL] * grams > playerCash) return false;
                return true;

                case (int)Drugs.M_JANE:
                if(DrugPrices[(int)Drugs.M_JANE] * grams > playerCash) return false;
                return true;

                case (int)Drugs.HASH:
                if(DrugPrices[(int)Drugs.HASH] * grams > playerCash) return false;
                return true;

                

                default: return false;
            }
        }

        static void Main(string[] args)
        {
            LoadInventory();
            Console.Clear();

            System.Console.WriteLine("Velkommen til narkotikabutikken! Skriv 'vislager' for at se hvad er på lager\nBrug 'kob' for at kob narkotika.");

            start:
            Console.Write(">");

            LaunchCommand(GetCommandIDfromInput(Console.ReadLine()));

            goto start;
        }

        static void LoadInventory()
        {
            Random rand = new Random();
            Random _rand = new Random();

            int drugid;

            
            for(int i = 0; i < lager.Length; i++)
            {
                if(i % 2 == 0) {
                    drugid = rand.Next(0, Enum.GetNames(typeof(Drugs)).Length);


                    lager[i] = new Item(drugid, rand.Next(0, 100));

                }
                else {
                    drugid = _rand.Next(0, Enum.GetNames(typeof(Drugs)).Length);


                    lager[i] = new Item(drugid, _rand.Next(0, 100));
                }
            }
        }
    }
}

