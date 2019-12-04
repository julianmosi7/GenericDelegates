using System;
using System.Collections.Generic;

using System.Linq;
//using GenericDelegates.Linq;

using GenericDelegates.Db;

namespace GenericDelegates
{
  public class Program
  {

    private static void Main()
    {
      var db = new Database().Init();

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
                    .ToList();
    }

    public static List<string> FirstnamesInChina(Database db)
    {
            return db.Persons
                .Where(x => x.Adress.country == "China")
                .OrderBy(x => x)
                .Select(x => x.first_name)
                .Distinct()
                .ToList();
    }

    public static int MaxStreetNrPhilippines(Database db)
    {
            return db.Persons
                .Where(x => x.Adress.country == "Philippines")
                .Select(x => Int32.Parse(x.Adress.streetnumber))
                .Max();
    }

    public static List<string> CountriesWithEmailEndingWithOrg(Database db)
    {
            return db.Persons
                .Where(x => x.email.Contains(".org"))
                .OrderBy(x => x)
                .Select(x => x.Adress.country)
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
