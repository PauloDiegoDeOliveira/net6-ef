using Bogus;
using DevLabs.Domain.Entitys;

namespace DevLabs.FakeData.AnotacaoData
{
    public class AnotacaoFaker : Faker<Anotacao>
    {
        public AnotacaoFaker()
        {
            var id = new Faker().Random.Guid();
            RuleFor(o => o.Id, _ => id);
            RuleFor(o => o.Titulo, f => f.Person.FullName);
        }
    }
}