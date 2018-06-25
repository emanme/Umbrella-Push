using System;

namespace Umbrella.Interfaces
{
    public interface ISynchronizable
    {
        Guid Id { get; set; }

        DateTime DateCreated { get; set; }

        DateTime DateModified { get; set; }
    }
}
