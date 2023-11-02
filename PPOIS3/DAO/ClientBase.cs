namespace PPOIS3.DAO
{
    public class ClientBase 
    {
        public static ClientBase? Instance { get; private set; }
        private readonly List<Client> clients = new();
        public ClientBase() => Instance ??= this;

        public virtual bool Create(Client client)
        {
            if (clients.Exists(x => x.Name == client.Name))
                return false;

            clients.Add(client);

            return true;
        }

        public virtual Client? Get(string name) => clients.Find(x => x.Name == name);

        public virtual bool Remove(string name)
        {
            Client? client = Get(name);
            if (client is null)
                return false;
            return clients.Remove(client);
        }
    }
}
