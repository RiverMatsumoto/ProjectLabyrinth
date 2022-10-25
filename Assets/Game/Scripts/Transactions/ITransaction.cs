namespace Game.Scripts.Transactions
{
    public interface ITransaction<T>
    {
        void ExecuteTransaction(T subject);
    }
}
