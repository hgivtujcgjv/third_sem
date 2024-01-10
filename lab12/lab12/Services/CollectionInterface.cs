﻿using models_for_l12;
namespace lab12.Services;



public interface ICollection<T>
{
    public IEnumerable<T> GetAll();
    public T? Get(int? id);
    public T Add(T newElem);
    public T? Edit(T editedElem);
    public T? Delete(int id);
}