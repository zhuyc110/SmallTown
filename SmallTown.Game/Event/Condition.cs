using SmallTown.Game.Person;
using SmallTown.Game.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Game.Event;
public class Condition
{
    private readonly int _minAge;
    private readonly int _maxAge;
    private readonly Sex _sex;
    private readonly IList<int> _personalityIds;
    private readonly IList<IdValuePair<int, int>> _propertyMapping;
    private readonly IList<Operator> _operators;

    public Condition(int minAge, int maxAge, Sex sex, IList<int> personalityIds, IList<IdValuePair<int, int>> propertyMapping, IList<Operator> operators)
    {
        _minAge = minAge;
        _maxAge = maxAge;
        _sex = sex;
        _personalityIds = personalityIds ?? Enumerable.Empty<int>().ToList();
        _propertyMapping = propertyMapping ?? Enumerable.Empty<IdValuePair<int, int>>().ToList();
        _operators = operators ?? Enumerable.Empty<Operator>().ToList();
    }

    public bool CanMatch(Person.Person person)
    {
        if (!person.Sex.HasFlag(_sex))
        {
            return false;
        }

        if (person.Age < _minAge || person.Age > _maxAge)
        {
            return false;
        }

        if (_personalityIds.Any() && !_personalityIds.Contains(person.Personality.Id))
        {
            return false;
        }

        for (var index = 0; index < _propertyMapping.Count; index++)
        {
            var (propertyId, value) = _propertyMapping[index];
            var property = person.Properties.FirstOrDefault(x => x.Reference.Id == propertyId);
            if (property == null)
            {
                return false;
            }

            var oprt = _operators[index];

            switch (oprt)
            {
                case Operator.Equals:
                    if (value != property.Value)
                    {
                        return false;
                    }
                    break;
                case Operator.LessThan:
                    if (property.Value > value)
                    {
                        return false;
                    }
                    break;
                case Operator.GreaterThan:
                    if (property.Value < value)
                    {
                        return false;
                    }
                    break;
            }
        }

        return true;
    }
}
