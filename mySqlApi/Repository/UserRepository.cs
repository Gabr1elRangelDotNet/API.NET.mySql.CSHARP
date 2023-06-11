using Dapper;
using mysqlAPI.Model;
using MySqlConnector;


namespace mysqlAPI.Repository;

public class UserRepository : IUserRepository{

    private readonly string _connectionString;

    public UserRepository(string connectionstring)
    {
        _connectionString = connectionstring;
    }
    public IEnumerable<User> GetAll()
    {
        var sql = "SELECT * FROM cliente";
        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            return connection.Query<User>(sql);
        }
    }

    public int InsertUser(User newUser)
    {
        var sql = "INSERT INTO cliente VALUES (@i_cliente_cliente, @s_nome_cliente, @s_cpf_cliente, @d_nasc_cliente, @i_tipo_cliente)";

        User user = new User()
        {
            i_cliente_cliente = newUser.i_cliente_cliente,
            s_nome_cliente = newUser.s_nome_cliente,
            s_cpf_cliente = newUser.s_cpf_cliente,
            d_nasc_cliente = newUser.d_nasc_cliente,
            i_tipo_cliente = newUser.i_tipo_cliente,
        };

        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            return connection.Execute(sql, user);
        }
    }
    
    public int DeleteUser(int i_cliente_cliente)
    {
        var sql = "DELETE FROM cliente where i_cliente_cliente = @i_cliente_cliente";

        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            return connection.Execute(sql, new { i_cliente_cliente });
        }
    }
    
    public User GetName(int i_cliente_cliente)
    {
        var sql = $"SELECT s_nome_cliente from cliente where i_cliente_cliente= {i_cliente_cliente}";
        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            var user = connection.QuerySingleOrDefault<User>(sql);
            return user;
        }
    }
}
