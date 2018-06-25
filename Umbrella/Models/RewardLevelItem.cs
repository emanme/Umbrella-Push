using System;
using SQLite;
using Umbrella.Enums;
using Umbrella.Interfaces;

namespace Umbrella.Models
{
    public class RewardLevelItem : ISynchronizable
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public RewardLevelValue Level { get; set; }
    }
}
