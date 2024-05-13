using Application.Contract.Persistance.Dapper;
using Dapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Security.Cryptography;

namespace Persistence.Repositories.Dapper
{
    public class OrdersDapperRepository : GenericDapperRepository<Orders, int>, IOrderDapperRepository
    {
        protected readonly IDbConnection _connection;
        protected readonly ILogger<OrdersDapperRepository> _logger;
       
        public OrdersDapperRepository(IDbConnection connection, ILogger<OrdersDapperRepository> logger)
               : base(connection, logger)
        {
            _connection = connection;
            _logger = logger;
        }

        public override async Task<Orders?> GetByIdAsync(int id)
        {
            _logger.LogInformation($"Getting Order with ID {id}");
            var query = @"
            SELECT o.*, p.* 
            FROM Orders o
            INNER JOIN People p ON o.PeopleId = p.Id
            WHERE o.Id = @Id
        ";
            var order = await _connection.QueryAsync<Orders, People, Orders>(query,
                (order, people) =>
                {
                    order.People = people;
                    return order;
                },
                new { Id = id },
                splitOn: "PeopleId");
            return order.FirstOrDefault();
        }

        public override async Task<IEnumerable<Orders>> GetAllAsync()
        {
            _logger.LogInformation($"Getting all Orders");
            var query = @"
        SELECT o.*, p.* 
        FROM Orders o
        INNER JOIN People p ON o.PeopleId = p.Id ";
            var orders = await _connection.QueryAsync<Orders, People, Orders>(query,
                (order, people) =>
                {
                    order.People = people;
                    return order;
                },
                splitOn: "PeopleId");
            return orders;
        }
    }
}

