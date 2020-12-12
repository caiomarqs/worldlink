using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WorldLink.Contexts;
using WorldLink.Models;

namespace WorldLink.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private WorldLinkDbContext _context;

        public ContatoRepository(WorldLinkDbContext context)
        {
            _context = context;
        }

        public Contato FindById(int id)
        {
            return _context.Contatos.Find(id);
        }

        public void Insert(Contato entity)
        {
            _context.Contatos.Add(entity);
        }

        public IList<Contato> ListAll()
        {
            return _context.Contatos.ToList();
        }

        public IList<Contato> Query(Expression<Func<Contato, bool>> filter)
        {
            return _context.Contatos.Where(filter).ToList();
        }

        public void Remove(int id)
        {
            var user = FindById(id);
            _context.Contatos.Remove(user);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Contato entity)
        {
            _context.Contatos.Update(entity);
        }

        public Contato FindByEmail(string email)
        {
            var contatos = _context.Contatos.Where(u => u.Email.Equals(email)).ToList();

            if (contatos.Count > 0)
            {
                return contatos.First();
            }

            return null;
        }
    }
}
