using System;
using System.Collections.Generic;

using System.Linq;
//using GenericDelegates.Linq;


using NorthwindDbLib;

namespace GenericDelegates
{
  public class Program
  {

    private static void Main()
    {
      var db = new NorthwindContext();
            try
            {
                int nrCategories = db.Categories.Count();
                Console.WriteLine($"{nrCategories} Categories in Db");
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

      
      Console.WriteLine("--------------------- MalesStreetNrLessThan10");
      MalesStreetNrLessThan10(db).Select(x => $"{x.last_name} {x.first_name}").Print();
      Console.WriteLine("--------------------- FirstnamesInChina");
      FirstnamesInChina(db).Print();
      Console.WriteLine("--------------------- WriteLine");
      Console.WriteLine(MaxStreetNrPhilippines(db));
      Console.WriteLine("--------------------- CountriesWithEmailEndingWithOrg");
      CountriesWithEmailEndingWithOrg(db).Print();
      Console.WriteLine("--------------------- PersonsFromIndonesia");
      PersonsFromIndonesia(db).Select(x => $"{x.last_name} {x.first_name}").Print();

      Console.ReadKey();
      
    }

    public static List<Person> MalesStreetNrLessThan10(Database db)
    {
            return db.Persons
                    .Where(x => Int32.Parse(x.Adress.streetnumber) < 10)
                    .Where(x => x.gender=="Male")
                    .ToList();
    }

    public static List<string> FirstnamesInChina(Database db)
    {
            return db.Persons
                .Where(x => x.Adress.country == "China")
                .Select(x => x.first_name)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
    }

    public static int MaxStreetNrPhilippines(Database db)
    {
            return db.Adresses
                .Where(x => x.country == "Philippines")
                .Select(x => Int32.Parse(x.streetnumber))
                .Max();
    }

    public static List<string> CountriesWithEmailEndingWithOrg(Database db)
    {
            return db.Persons
                .Where(x => x.email.EndsWith(".org"))
                .Select(x => x.Adress.country)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
                
            
    }

    public static List<Person> PersonsFromIndonesia(Database db)
    {
            return db.Persons
                 .Where(x => x.Adress.country == "Indonesia")
                 .OrderBy(x => x.last_name)
                 .Skip(3)
                 .Take(4)
                 .ToList();
    }
  }
}
