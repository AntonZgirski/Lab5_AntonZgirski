using System;

namespace Test_Semple
{
  class Program
  {
    static void Main(string[] args)
    {
      var com = new Communication();
      Action<string> del = s =>  { Console.WriteLine(s); }; 
      try
      {
        com.Create("Samsung", "S22 Ultra", 100.00, 128, 6.2);
        com.Create("Samsung", "S21", 120.00, 256, 5.7);
        com.Create("Apple", "Iphone 14", 500.00, 256, 6.7);
        //com.Create("Xiaomi", "Mi 12T", 400.00, 128, 7.0);
        //com.Create("Nokia", "3310", 20.00, 1, 3.4);
        //com.Create("Sony Ericson", "k750i", 1.00, 1, 1.5);
        //com.Create("Samsung", "S8", 120.00, 64, 5.8);      
        del.Invoke(com.ReadAll());
        del.Invoke(com.Read(10));

        com.Update(150.0, 4);
        com.Delete(5);
        del.Invoke(com.ReadAll());
        del.Invoke(com.PopularBrand());
      }
      catch(OverFlowException ex)
      {
        Console.WriteLine(ex.OverFlowExceptionMessage);
        //throw;
      }
      catch(DeleteNotFoundException ex)
      {
        Console.WriteLine(ex.DeleteNotFoundExceptionMessage);
        //throw;
      }
      catch (NotFoundException ex)
      {
        Console.WriteLine(ex.NotFoundExceptionMessage);
        //throw;
      }
      catch (UpdateNotFoundException ex)
      {
        Console.WriteLine(ex.UpdateNotFoundExceptionMessage);
        //throw;
      }
      catch (ReadNotFoundException ex)
      {
        Console.WriteLine(ex.ReadNotFoundExceptionMessage);
        //throw;
      }

    }
  }
}
