namespace FileSystem.Queries.Contracts;

public interface IQueryHandler<TQuery, TResult>
{
    TResult Handle(TQuery query);
}

