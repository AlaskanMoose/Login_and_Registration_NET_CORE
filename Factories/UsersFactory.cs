using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using login_registration.Models;

namespace login_registration.Factories{
  public class UsersFactory : IFactory<User>{
    private readonly DbConnector _dbConnector;
    public UsersFactory(DbConnector connect){
      _dbConnector = connect;
    }
    public void Add(User user){
      string Query = $"INSERT INTO User (FirstName, LastName, Email, Password) VALUES ('{user.FirstName}, '{user.LastName}', '{user.Email}', '{user.Password}'";
      _dbConnector.Execute(Query);
    }
    public List<Dictionary<string, object>>  GetLatestUser(){
      string Query = "SELECT * FROM User ORDER BY UserId DESC LIMIT 1";
      var users = _dbConnector.Query(Query);
      return  users;
    }
    public List<Dictionary<string, object>> GetUserById(int Id){
      string Query = $"SELECT * FROM User WHERE EMAIL = '{Id}";
      var users = _dbConnector.Query(Query);
      return users;
    }
    public List<Dictionary<string, object>> GetUserByEmail(string Email){
      string Query = $"SELECT * FROM User WHERE EMAIL = '{Email}";
      var users = _dbConnector.Query(Query);
      return users;
    }
  }
}
