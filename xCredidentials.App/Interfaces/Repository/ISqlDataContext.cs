namespace xCredidentials.App.Interfaces.Repository;

public interface ISqlDataContext
{
    Task<IEnumerable<T>> LoadData<T, P>(string storedProcedure, P parameters, string connectionId = "Default");
    Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "Default");
}