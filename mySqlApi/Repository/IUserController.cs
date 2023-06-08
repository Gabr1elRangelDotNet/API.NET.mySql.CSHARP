//Interface server como um contrato quem herdar seus atributos deverá invocar o metodo GetAll()

using mysqlAPI.Model;

namespace mysqlAPI.Repository;

public interface IUserRepository
{
   IEnumerable <User> GetAll();
   int InsertUser(User user);
}