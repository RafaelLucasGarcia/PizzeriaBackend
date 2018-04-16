using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PizzeriaBackend.Video
{
    public class Logger : ILogger
    {
        readonly IRepository _repository;
        readonly IUnitOfWork _unitOfWork;

        public Logger(IRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Dispose() {
            _unitOfWork.Dispose();
        }

        public void write(Pizza pizza)
        {
            _repository.Write(pizza);
            _unitOfWork.SaveChanges();
        }
    }

    public interface IRepository {
        void Write(Pizza pizza);
    }

    public class Repository : IRepository {
        readonly IRepositoryPizza _repositoryPizza;

        public Repository(IRepositoryPizza repositoryPizza)
        {
            _repositoryPizza = repositoryPizza;
        }

        public void Write(Pizza pizza) {
            var set = _repositoryPizza.IDbSet(typeof(Pizza));
            set.Add(pizza);
        }
    }

    public interface ILogger : IDisposable {
        void write(Pizza pizza);
    }

    public class Pizza {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public interface IUnitOfWork : IDisposable {
        int SaveChanges();
    }

    public interface IRepositoryPizza{
        DbSet IDbSet(Type type);

    }

    public class PizzaShowContext : DbContext, IUnitOfWork, IRepositoryPizza {
        public PizzaShowContext()
        {

        }

        public IDbSet<Pizza> Pizza { get; set; }
        public DbSet IDbSet(Type type) {
            return this.Set(type);
        }

        
    }


}