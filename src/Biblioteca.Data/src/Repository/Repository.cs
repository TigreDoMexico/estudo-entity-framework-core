using Biblioteca.Data.Context;

namespace Biblioteca.Data.Repository;
public abstract class Repository<T> where T : class
{
    internal BibliotecaDbContext dbContext;

    internal Repository()
        => (dbContext) = (new BibliotecaDbContext());

    public List<T> BuscarTodos()
        => dbContext.Set<T>().ToList();

    public T? BuscarPorId(int id)
        => dbContext.Set<T>().Find(id);

    public void AdicionarNovo(T entidade)
    {
        // dbContext.Entry(entidade).State = EntityState.Added;
        dbContext.Set<T>().Add(entidade);
        SalvarNaBase();
    }

    public void Atualizar(T entidade, object dadosParaAlterar)
    {
        // dbContext.Set<T>.Attach(entidade);
        dbContext.Entry(entidade).CurrentValues.SetValues(dadosParaAlterar);
        SalvarNaBase();
    }

    public void Deletar(T entidade)
    {
        dbContext.Set<T>().Remove(entidade);
        SalvarNaBase();
    }

    public void SalvarNaBase()
        => dbContext.SaveChanges();
}