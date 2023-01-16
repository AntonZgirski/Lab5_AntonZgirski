using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Semple
{
  public class Communication
  {
    public List<Phone> phones = new List<Phone>();
    private const int MaxValue = 5;

    public void Create(string name, string phone, double price, int size, double diag)
    {
      if (phones.Count > MaxValue) throw new OverFlowException("The list is full!");
      phones.Add(new Phone(name, phone, price, size, diag));
    }    

    public string Read(int i)
    {
      try
      {
        return phones[i].ToString();
      }
      catch
      {
        throw new ReadNotFoundException($"Reading is not possible! No record number {i}");
      }      
    }

    public void Update(double price, int i)
    {
      try
      {
        var phone = phones[i];
        phone.Price = price;
      }
      catch
      {
        throw new UpdateNotFoundException($"Updating is not possible! No record number {i}");
      }
    }
    public void Delete(int i)
    {
      try
      {
        phones.RemoveAt(i);
      }
      catch
      {
        throw new DeleteNotFoundException($"Deleting is not possible! No record number {i}");
      }
    }

    public string ReadAll()
    {
      StringBuilder st = new StringBuilder();
      
      foreach (var ph in phones)
      {
        st.AppendLine($"Brand Phone {ph.BrandName}. Model Phone {ph.ModelPhone}. Price {String.Format("{0:f2}", ph.Price)}. Memory size {ph.MemorySize}." +
             $"Screen diagonal {ph.ScreenDiagonal}.");
      }

      return st.ToString();
    }

    public string PopularBrand()
    {      
      Dictionary<string, int> dicti = new Dictionary<string, int>();
      dicti.Add(phones[0].BrandName, 1);
      for (int i = 1; i < phones.Count; i++)
      {        
        if (dicti.ContainsKey(phones[i].BrandName))
        {
          dicti[phones[i].BrandName] += 1;
        }
        else
        {
          dicti.Add(phones[i].BrandName, 1);
        }
      }
      
      int max = 0;
      string popBrandName = "";
      foreach (var di in dicti)
      {
        if (di.Value > max)
        {
          popBrandName = di.Key;
          max = di.Value;
        }
      }

      return $"The most popular brand is {popBrandName}.";  
    }
  }

  public class Phone
  {
    public string BrandName { get; set; }
    public string ModelPhone { get; set; }
    public double Price { get; set; }
    public int MemorySize { get; set; }
    public double ScreenDiagonal { get; set; }

    public Phone(string name, string phone, double price, int size, double diag)
    {
      BrandName = name;
      ModelPhone = phone;
      Price = price;
      MemorySize = size;
      ScreenDiagonal = diag;
    }

    public override string ToString()
    {
      return $"Brand Phone {BrandName}. Model Phone {ModelPhone}. Price {String.Format("{0:f2}", Price)}. Memory size {MemorySize}." +
             $"Screen diagonal {ScreenDiagonal}.";
    }
  }

  public class NotFoundException : Exception
  {
    public NotFoundException(string message) : base(message)
    {
      NotFoundExceptionMessage = message;
    }

    public string NotFoundExceptionMessage { get; set; }
  }

  public class DeleteNotFoundException : Exception
  {
    public DeleteNotFoundException(string message) : base(message)
    {
      DeleteNotFoundExceptionMessage = message;
    }

    public string DeleteNotFoundExceptionMessage { get; set; }
  }

  public class UpdateNotFoundException : Exception
  {
    public UpdateNotFoundException(string message) : base(message)
    {
      UpdateNotFoundExceptionMessage = message;
    }

    public string UpdateNotFoundExceptionMessage { get; set; }
  }

  public class ReadNotFoundException : Exception
  {
    public ReadNotFoundException(string message) : base(message)
    {
      ReadNotFoundExceptionMessage = message;
    }

    public string ReadNotFoundExceptionMessage { get; set; }
  }


  public class OverFlowException : Exception
  {
    public OverFlowException(string message) : base(message)
    {
      OverFlowExceptionMessage = message;
    }

    public string OverFlowExceptionMessage { get; set; }
  }


}
