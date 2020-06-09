using GenericDelegates;
using GenericDelegates.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using FluentAssertions;

namespace XUnitTestPersons
{
  public class TestPersonRepositoryXUnit
  {
    #region ---------------------------------------------------------- Initialize
    private readonly Database db;

    public TestPersonRepositoryXUnit()
    {
      db = new Database().Init();
    }
    #endregion

    [Fact]
    public void T01x_TestMalesStreetNrLessThan10()
    {
      var expected = new List<string> {
        "Mason Michael",
        "Vasquez John",
        "Fisher Fred",
        "Freeman Carlos",
        "Kim Brian",
        "Gray Mark",
        "Palmer Donald",
        "James Bruce",
        "Gardner Matthew",
        "Stanley Jack",
        "Simpson Jerry",
        "Cooper Eric",
        "Gonzales Juan",
        "Price Ralph",
        "White Jerry",
        "Gordon Ernest",
        "Thompson Earl",
        "Garcia Donald",
        "Hansen Christopher",
        "Wright Phillip",
        "Webb Joseph",
        "Hayes Patrick",
        "Knight Chris",
        "Wallace Johnny"
      };
      var actual = Program.MalesStreetNrLessThan10(db);
      actual.Select(x => x.ToString()).Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void T02x_TestFirstnamesInChina()
    {
      var expected = new List<string> {
        "Christina",
        "Christopher",
        "Doris",
        "Eric",
        "Eugene",
        "Gerald",
        "Gloria",
        "James",
        "Johnny",
        "Juan",
        "Michael",
        "Nicholas",
        "Phyllis",
        "Sean",
        "Shirley",
        "Stephen"
      };
      var actual = Program.FirstnamesInChina(db);
      actual.Select(x => x.ToString()).Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void T03x_TestMaxSteetNrPhilippines()
    {
      int expected = 849;
      int actual = Program.MaxStreetNrPhilippines(db);
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void T04x_TestCountriesWithEmailEndingWithOrg()
    {
      var expected = new List<string> {
        "China",
        "Croatia",
        "France",
        "Indonesia",
        "Portugal"
      };
      var actual = Program.CountriesWithEmailEndingWithOrg(db);
      actual.Should().BeEquivalentTo(expected);
    }

    [Fact]

    public void T05x_TestPersonsFromIndonesia()
    {
      var expected = new List<string> {
        "Cooper Eric",
        "Cox Theresa",
        "Davis Christina",
        "Day Peter"
      };
      var actual = Program.PersonsFromIndonesia(db);
      actual.Select(x => x.ToString()).Should().BeEquivalentTo(expected);
    }
  }
}
