using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace GenericDelegates.Db
{
  public class Database
  {
    public List<Person> Persons { get; set; } = new List<Person>();
    public List<Adress> Adresses { get; set; } = new List<Adress>();

    public Database Init()
    {
      string sPersons = File.ReadAllText("persons.json");
      string sAdresses = File.ReadAllText("adresses.json");

      JArray jPersons = JsonConvert.DeserializeObject(sPersons) as JArray;
      JArray jAdresses = JsonConvert.DeserializeObject(sAdresses) as JArray;
      Persons = jPersons.ToObject<List<Person>>();
      Adresses = jAdresses.ToObject<List<Adress>>();

      var adressLookup = new Dictionary<int, Adress>();
      Adresses.ForEach(x => adressLookup[x.id] = x);
      Persons.ForEach(x => x.Adress = adressLookup[x.adress_id]);
      return this;
    }
  }
}
