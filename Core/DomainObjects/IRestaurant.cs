using System;

namespace Core.DomainObjects
{
    public interface IRestaurant
    {
        Guid Id { get; set; }

        string Name { get; set; }
        string FoodType { get; set; }

        DateTime? DateAttended { get; set; }

        decimal? Price { get; set; }
        double? Rating { get; set; }

        bool Bar { get; set; }

        Guid RelationshipId { get; set; }
    }
}
