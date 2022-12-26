using System;

namespace Test_Semple
{
  class Program
  {
    static void Main(string[] args)
    {
      var com = new Communication();
      var console = new WriteConsole();
      com.Create("Samsung", "S22 Ultra", 100.00, 128, 6.2);
      com.Create("Samsung", "S21", 120.00, 256, 5.7);
      com.Create("Apple", "Iphone 14", 500.00, 256, 6.7);
      com.Create("Xiaomi", "Mi 12T", 400.00, 128, 7.0);
      com.Create("Nokia", "3310", 20.00, 1, 3.4);
      com.Create("Sony Ericson", "k750i", 1.00, 1, 1.5);
      com.Create("Samsung", "S8", 120.00, 64, 5.8);

      console.Print(com.ReadAll());
      console.Print(com.Read(2));      

      com.Update(150.0, 2);
      com.Delete(3);

      console.Print(com.ReadAll());
      console.Print(com.PopularBrand());
    }
  }
}
