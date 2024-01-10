using models_for_l12;
using System.Collections;

namespace Lab12.Services;

public class MockUsers : ICollection<users_tr>
{
    private readonly List<users_tr> _users;

    public int Count => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public MockUsers()
    {
        _users = new List<users_tr>()
        {
            new users_tr()
            {
                Id = 1,
                phone_number = 890123421,
                email = "sdfaasdf"
            },
            new users_tr()
            {
                Id = 2,
                phone_number = 790323421,
                email = "zcxvgf"
            },
            new users_tr()
            {
                Id = 3,
                phone_number = 590133421,
                email = "wertwtrf"
            }
        };
    }

    public users_tr? Get(int? id)
    {
        return _users.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<users_tr> GetAll()
    {
        return _users;
    }

    public users_tr Add(users_tr user)
    {
        user.Id = _users.Max(x => x.Id) + 1;
        _users.Add(user);
        return user;
    }

    public users_tr? Delete(int id)
    {
        var author = _users.FirstOrDefault(x => x.Id == id);
        if (author != null)
        {
            _users.Remove(author);
        }

        return author;
    }

    public users_tr? Edit(users_tr newUser)
    {
        var user = _users.FirstOrDefault(x => x.Id == newUser.Id);
        if (user != null)
        {
            user.Id = newUser.Id;
            user.phone_number = newUser.phone_number;
            user.email = newUser.email;
        }

        return user;
    }

    void ICollection<users_tr>.Add(users_tr item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(users_tr item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(users_tr[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(users_tr item)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<users_tr> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}


public class MockTariffs : ICollection<tariffs>
{
    private readonly List<tariffs> _tariffs;

    public int Count => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public MockTariffs()
    {
        _tariffs = new List<tariffs>()
        {
            new tariffs()
            {
                Id = 1,
                price = 300,
                name_of_tarif = "11111",
                description = "asdfax"
            },
            new tariffs()
            {
                Id = 2,
                price = 400,
                name_of_tarif = "22",
                description = "sdfafadssdfax"
            },
            new tariffs()
            {
                Id = 3,
                price = 500,
                name_of_tarif = "3",
                description = "qqqqsdaf"
            }
        };

    }

    public tariffs? Get(int? id)
    {
        return _tariffs.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<tariffs> GetAll()
    {
        return _tariffs;
    }

    public tariffs Add(tariffs tariff)
    {
        tariff.Id = _tariffs.Max(x => x.Id) + 1;
        _tariffs.Add(tariff);
        return tariff;
    }

    public tariffs? Delete(int id)
    {
        var tariff = _tariffs.FirstOrDefault(x => x.Id == id);
        if (tariff != null)
        {
            _tariffs.Remove(tariff);
        }

        return tariff;
    }

    public tariffs? Edit(tariffs newTariff)
    {
        var tariff = _tariffs.FirstOrDefault(x => x.Id == newTariff.Id);
        if (tariff != null)
        {
            tariff.Id = newTariff.Id;
            tariff.name_of_tarif = newTariff.name_of_tarif;
            tariff.price = newTariff.price;
            tariff.description = newTariff.description;
        }

        return tariff;
    }

    void ICollection<tariffs>.Add(tariffs item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(tariffs item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(tariffs[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(tariffs item)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<tariffs> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

public class MockSubscribers : ICollection<subscribers>
{
    private readonly List<subscribers> _subscribers;

    public int Count => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public MockSubscribers()
    {
        _subscribers = new List<subscribers>()
        {
            new subscribers()
            {
                Id = 2,
               name_of_tarif = "3333",
                name = "Anton",
                email = "asdfsdf",
                discount = 15
            },
            new subscribers()
            {
                Id = 2,
                name_of_tarif = "121134",
                name = "Anton2",
                email = "xcvvxcvsdf",
                discount = 10
            },
            new subscribers()
            {
                Id = 0,
                name_of_tarif = "1234",
                name = "Anton3",
                email = "eeeeef",
                discount = 1
            }
        };
    }

    public subscribers? Get(int? id)
    {
        return _subscribers.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<subscribers> GetAll()
    {
        return _subscribers;
    }

    public subscribers Add(subscribers sub)
    {
        sub.Id = _subscribers.Max(x => x.Id) + 1;
        _subscribers.Add(sub);
        return sub;
    }

    public subscribers? Delete(int id)
    {
        var sub = _subscribers.FirstOrDefault(x => x.Id == id);
        if (sub != null)
        {
            _subscribers.Remove(sub);
        }

        return sub;
    }

    public subscribers? Edit(subscribers newsub)
    {
        var sub = _subscribers.FirstOrDefault(x => x.Id == newsub.Id);
        if (sub != null)
        {
            sub.Id = newsub.Id;
            sub.email = newsub.email;
            sub.name_of_tarif= newsub.name_of_tarif;
            sub.discount= newsub.discount;
        }

        return sub;
    }

    void ICollection<subscribers>.Add(subscribers item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(subscribers item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(subscribers[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(subscribers item)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<subscribers> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}