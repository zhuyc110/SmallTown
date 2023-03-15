using SmallTown.Engine.Resource;
using SmallTown.Game.Shared;
using SmallTown.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Game.Person;
public class RoleManager : ReadableObjectManagerBase<Role>
{
    protected override string ReadableObjectKey => nameof(Role);

    public RoleManager(IAssetManager assetManager, ILanguageService languageService)
        : base(assetManager, languageService)
    {
    }

    public override Role Get(int id)
    {
        if (id <= 0)
        {
            return ReadableObjects[0];
        }

        if (ReadableObjects.Count < id)
        {
            var parentIndex = id / 10000;
            return ReadableObjects[parentIndex - 1].GetChild(id);
        }

        if (ReadableObjects[id - 1].Id == id)
        {
            return ReadableObjects[id - 1];
        }

        return ReadableObjects[id - 1];
    }
}
