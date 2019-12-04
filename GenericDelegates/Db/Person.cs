namespace GenericDelegates.Db
{
  public class Person
  {
    //{"id":1,"first_name":"Michael","last_name":"Mason","email":"mmason0@apache.org","gender":"Male","adress_id":25}
    public int id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public string gender { get; set; }
    public int adress_id { get; set; }
    public Adress Adress { get; set; }
    public override string ToString() => $"{last_name} {first_name}";
  }
}
