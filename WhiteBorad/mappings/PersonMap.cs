using FluentNHibernate.Mapping;
using WhiteBorad.Models;

namespace WhiteBorad.mappings
{
    public class PersonMap:ClassMap<Person>
    {
         public PersonMap()
         {
             Id(x => x.Id);
             Map(x => x.Name);
             Map(x => x.Description);
         }
    }

}