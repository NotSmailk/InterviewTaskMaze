using Assets.Source.Script;
using Assets.Source.Scripts.Factories;
using System;
using System.Collections.Generic;

namespace Assets.Source.Scripts
{
    [Serializable]
    public class ConnectionConfig
    {
        public List<Connection> connections = new List<Connection>();

        public void Init(IFactory<Door> doorFactory, IFactory<Wall> wallFactory)
        {
            foreach (var connection in connections)
            {
                connection.CreateDoors(doorFactory, wallFactory);
            }
        }
    }
}
