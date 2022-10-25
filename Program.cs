using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class Program
    {
        static int weapon;
        static int[] ammo;
        static int[] maxAmmo;
        static string[] weaponName;

        static void Main(string[] args)
        {
            InitValues();

            Console.WriteLine("Functional showcase:");
            Console.ReadKey(true);
            GetCurrentWeapon();
            GetNewWeapon(3);
            Fire();
            AmmoCheck(weapon);
            AmmoPickUp(5);
            GetNewWeapon(1);
            Fire();
            Fire();
            Fire();
            Fire();
            AmmoCheck(weapon);
            Fire();
            AmmoCheck(weapon);

            Console.WriteLine();
            Console.WriteLine("Technical showcase:");
            Console.ReadKey(true);
            GetCurrentWeapon();
            Console.WriteLine("Testing an ammo pickup of negative value");
            Console.ReadKey(true);
            AmmoPickUp(-5);
            AmmoCheck(weapon);
            Console.WriteLine("Testing picking up a weapon of an out of range weapon number (less than 0 or greater than the max number)");
            Console.ReadKey(true);
            GetNewWeapon(69);
            Console.WriteLine("Testing checking the ammo of an out of range weapon number");
            Console.ReadKey(true);
            AmmoCheck(-420);
            Console.WriteLine("Testing reloading an out of range weapon value");
            Console.ReadKey(true);
            Reload(666, 5);
        }

        static void InitValues()
        {
            weapon = 0;

            ammo = new int[6];//instantiation
            ammo[0] = 5;//bow
            ammo[1] = 4;//crossbow
            ammo[2] = 6;//blowpipe
            ammo[3] = 2;//ballista
            ammo[4] = 7;//sling
            ammo[5] = 3;//arquebus

            maxAmmo = new int[6];//instantiation
            maxAmmo[0] = 10;//bow
            maxAmmo[1] = 8;//crossbow
            maxAmmo[2] = 12;//blowpipe
            maxAmmo[3] = 4;//ballista
            maxAmmo[4] = 14;//sling
            maxAmmo[5] = 6;//arquebus

            weaponName = new string[6];
            weaponName[0] = "bow";
            weaponName[1] = "crossbow";
            weaponName[2] = "blowpipe";
            weaponName[3] = "ballista";
            weaponName[4] = "sling";
            weaponName[5] = "arquebus";
        }

        static void GetNewWeapon(int newWeapon)
        {
            if (newWeapon < 0 || newWeapon > ammo.Length)
            {
                Console.WriteLine("ERROR: # of weapon to get is invalid");
                Console.ReadKey(true);
                return;
            }

            Console.WriteLine("Found a " + weaponName[newWeapon] + "!");
            weapon = newWeapon;
            Console.ReadKey(true);
            AmmoCheck(weapon);
        }
        static void AmmoCheck(int checkNum)
        {
            if (checkNum < 0 || checkNum > ammo.Length)
            {
                Console.WriteLine("ERROR: # of weapon to check is invalid");
                Console.ReadKey(true);
                return;
            }

            if (ammo[checkNum] > maxAmmo[checkNum])
            {
                ammo[checkNum] = maxAmmo[checkNum];
                Console.WriteLine(weaponName[checkNum] + " ammo maxed out");
                Console.ReadKey(true);
            }

            Console.WriteLine("You have " + ammo[checkNum] + " " + weaponName[checkNum] + " ammo left");
            Console.ReadKey(true);
        }
        static void GetCurrentWeapon()
        {
            Console.WriteLine("You are currently using a " + weaponName[weapon]);
            Console.ReadKey(true);
            AmmoCheck(weapon);
        }
        static void Fire()
        {
            Console.WriteLine("You fire your " + weaponName[weapon] + "!");
            Console.ReadKey(true);

            if (ammo[weapon] <= 0)
            {
                Console.WriteLine("But you have no ammo left");
                Console.ReadKey(true);
                return;

            }
            ammo[weapon]--;
        }
        static void Reload(int reloadNum, int ammoNum)//reloadNum is the weapon to reload, ammoNum is the amount of ammo to reload
        {
            if (reloadNum < 0 || reloadNum > ammo.Length)
            {
                Console.WriteLine("ERROR: # of weapon to reload is invalid");
                Console.ReadKey(true);
                return;
            }
            if (ammoNum < 0)
            {
                Console.WriteLine("ERROR: amount of ammo to gain is invalid");
                Console.ReadKey(true);
                return;
            }

            Console.WriteLine(ammoNum + " " + weaponName[reloadNum] + " ammo found!");
            ammo[reloadNum] += ammoNum;
            Console.ReadKey(true);
            AmmoCheck(reloadNum);
        }

        static void AmmoPickUp(int ammoAmount)
        {
            Console.WriteLine("Found an ammo pickup...");
            Console.ReadKey(true);
            Reload(weapon, ammoAmount);
        }
    }
}