namespace P03_SalesDatabase
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data;
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SalesContext();
        }
    }
}
