using System;

namespace RecycleProject.Interfaces.DI
{
    public interface IDIMeta
    {
        bool IsRegistred(Type t);
        Type RegistredTypeFor(Type t);
    }
}
