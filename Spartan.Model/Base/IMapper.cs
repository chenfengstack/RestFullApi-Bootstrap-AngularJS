namespace Spartan.Model.Base
{
    public interface IMapper<M, D>
    {
        M ToModel(D d);

        D Init(M t);
    }
}