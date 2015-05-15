using Spartan.Model.DbContext;

namespace Spartan.Model.Base
{
    public class ModelFactory
    {
        public SpartanDB db = null;

        //public ModelFactory(SpartanDB db)
        //{
        //    this.db = db;
        //}

        //public V Dto<T, V>(T model)
        //    where T : BaseModel
        //    where V : BaseDto
        //{
        //    return new BaseFactory<T, V>(this.db).Dto(model);
        //}
        //public T Model<T, V>(V dto)
        //    where T : BaseModel
        //    where V : BaseDto
        //{
        //    return new BaseFactory<T, V>(this.db).Model(dto);
        //}
    }
}