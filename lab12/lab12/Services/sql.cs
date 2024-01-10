using Microsoft.EntityFrameworkCore;
using models_for_l12;
using lab12.Services;

namespace Lab12.Services;

public class SqlUsers : lab12.Services.ICollection<users_tr>
{
    private mobile_operator_Context _db;

    public SqlUsers(mobile_operator_Context db)
    {
        _db = db;
    }

    public users_tr? Get(int? id)
    {
        return _db.users.Find(id);
    }

    public IEnumerable<users_tr> GetAll()
    {
        return _db.users;
    }

    public users_tr Add(users_tr user)
    {
        _db.users.Add(user);
        _db.SaveChanges();
        return user;
    }

    public users_tr? Edit(users_tr newUser)
    {
        var user = _db.users.Attach(newUser);
        user.State = EntityState.Modified;
        _db.SaveChanges();
        return newUser;
    }

    public users_tr? Delete(int id)
    {
        var user = _db.users.Find(id);
        if (user != null)
        {
            _db.users.Remove(user);
            _db.SaveChanges();
        }

        return user;
    }
}


public class SqlTariffs : lab12.Services.ICollection<tariffs>
{
    private mobile_operator_Context _db;

    public SqlTariffs(mobile_operator_Context db)
    {
        _db = db;
    }

    public tariffs? Get(int? id)
    {
        return _db.tariffs.Find(id);
    }

    public IEnumerable<tariffs> GetAll()
    {
        return _db.tariffs;
    }

    public tariffs Add(tariffs tarif)
    {
        _db.tariffs.Add(tarif);
        _db.SaveChanges();
        return tarif;
    }

    public tariffs Edit(tariffs newTarif)
    {
        var tarif = _db.tariffs.Attach(newTarif);
        tarif.State = EntityState.Modified;
        _db.SaveChanges();
        return newTarif;
    }

    public tariffs? Delete(int id)
    {
        var tarif = _db.tariffs.Find(id);
        if (tarif != null)
        {
            _db.tariffs.Remove(tarif);
            _db.SaveChanges();
        }
        return tarif;
    }
}

public class SqlSubs : lab12.Services.ICollection<subscribers>
{
    private mobile_operator_Context _db;

    public SqlSubs(mobile_operator_Context db)
    {
        _db = db;
    }

    public subscribers? Get(int? id)
    {
        return _db.subscribers.Find(id);
    }

    public IEnumerable<subscribers> GetAll()
    {
        return _db.subscribers;
    }

    public subscribers Add(subscribers sub)
    {
        _db.subscribers.Add(sub);
        _db.SaveChanges();
        return sub;
    }

    public subscribers Edit(subscribers newsub)
    {
        var s1 = _db.subscribers.Attach(newsub);
        // book.State = EntityState.Modified;
        _db.SaveChanges();
        return newsub;
    }

    public subscribers? Delete(int id)
    {
        var sub = _db.subscribers.Find(id);
        if (sub != null)
        {
            _db.subscribers.Remove(sub);
            _db.SaveChanges();
        }
        return sub;
    }
}