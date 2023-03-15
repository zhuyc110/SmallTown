using SmallTown.Game.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallTown.Game.Record;

public class RecordStorage
{
    public IList<RecordStorage> Postfix { get; set; }
    public Record? Record { get; set; }

    public RecordStorage()
    {
        Postfix = new RecordStorage[10];
    }

    public Record? Get(int id)
    {
        return Get(id, Postfix);
    }

    public void Add(Record record)
    {
        Add(record.Id, record);
    }

    private Record? Get(int id, IList<RecordStorage> postfix)
    {
        if (id < 0)
        {
            return default;
        }

        if (id < 10)
        {
            return postfix[id].Record;
        }
        else
        {
            var post = id % 10;
            return Get(id / 10, postfix[post].Postfix);
        }
    } 

    private void Add(int id, Record record)
    {
        if (id < 10)
        {
            if (Postfix[id] == null)
            {
                Postfix[id] = new RecordStorage();
            }
            Postfix[id].Record = record;
        }
        else
        {
            var locationIndex = id % 10;
            id /= 10;
            if (Postfix[locationIndex] == null)
            {
                Postfix[locationIndex] = new RecordStorage();
            }
            Postfix[locationIndex].Add(id, record);
        }
    }
}
