﻿namespace ComputerShopForm
{
    public class Workstation : Computer
    {
        public string Raidtype { get; set; }

        public Workstation(string name, double price, string imagepath, string description, int stock, int ram, string mobo, string hdd, string cpu, string psu, string raidtype)
               : base(name, price, imagepath, description, stock, ram, mobo, hdd, cpu, psu)
        {
            Raidtype = raidtype;
        }

        public override string ToString()
        {
            string add = $"Your workstation is equipped with {Raidtype}";
            return base.ToString() + add;
        }

        public override string GetThisType()
        {
            return "Workstation";
        }
    }
}