using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WorldLink.Contexts;
using WorldLink.Models;

namespace WorldLink.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private WorldLinkDbContext _context;

        public UsuarioRepository(WorldLinkDbContext context)
        {
            _context = context;
        }

        public Usuario FindById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Insert(Usuario entity)
        {
            _context.Usuarios.Add(entity);
        }

        public IList<Usuario> ListAll()
        {
            return _context.Usuarios.ToList();
        }

        public IList<Usuario> Query(Expression<Func<Usuario, bool>> filter)
        {
            return _context.Usuarios.Where(filter).ToList();
        }

        public void Remove(int id)
        {
            var entity = FindById(id);
            _context.Usuarios.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Usuario entity)
        {
            _context.Usuarios.Update(entity);
        }

        public Usuario FindByNome(string nome)
        {
            var usuarios =  Query(usuario => usuario.Nome == nome);

            if (usuarios.Count > 0)
            {
                return usuarios.First();
            }

            return null;
        }

    }
}
