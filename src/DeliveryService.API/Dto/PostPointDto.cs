using System;
using DeliveryService.API.Model;

namespace DeliveryService.API.Dto
{
    public class PostPointDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        internal bool IsValid()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        internal Point ToDomain()
        {
            return new Point(this.Id, this.Name);
        }
    }
}
