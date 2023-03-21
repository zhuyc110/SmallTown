using SmallTown.Game.Person;
using SmallTown.Game.Shared;
using System.Numerics;

namespace SmallTown.Game.Entity;
public class EntityTemplate : ReadableObjectBase
{
    public Vector2 Location { get; set; }

    public Scope Scope { get; }

    public ICollection<Role> Roles { get; }

    private readonly IReadOnlyCollection<IdValuePair<int, int>> _roleConfigs;

    public EntityTemplate(int id, string name, string description, int scope, IReadOnlyCollection<IdValuePair<int, int>> roles)
        : base(id, name, description)
    {
        Scope = (Scope)scope;
        Roles = new List<Role>();
        _roleConfigs = roles;
    }

    public void Setup(IRoleManager roleManager)
    {
        foreach (var (id, count) in _roleConfigs)
        {
            for (var i = 0; i < count; i++)
            {
                Roles.Add(roleManager.Get(id));
            }
        }
    }
}
