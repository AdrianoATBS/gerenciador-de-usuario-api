using GerenciadorDeUsuarios.Application.Interfaces;
using GerenciadorDeUsuarios.Domain.Entities;
using GerenciadorDeUsuarios.Infrastructure.Data;

namespace GerenciadorDeUsuarios.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;
    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }
    public void Adicionar(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }

    public void Atualizar(Usuario usuario)
    {
       _context.Usuarios.Update(usuario);
       _context.SaveChanges();
    }

    public bool EmailJaUsadoPorOutroUsuario(string email, Guid id)
    {
       return _context.Usuarios.Any(u => u.Email == email && u.Id != id);
       
    }

    public bool ExistePorEmail(string email)
    {
        return _context.Usuarios.Any(u => u.Email == email);
    }


    public Usuario? ObterPorId(Guid id)
    {
      return _context.Usuarios.Find(id);
       
    }
}
