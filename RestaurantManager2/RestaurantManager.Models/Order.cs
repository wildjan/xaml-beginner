using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RestaurantManager.Models
{
    public class Order
    {
        private static int _nextId = 0;

        [Key]
        public int Id { get; set; }

        public string SpecialRequests { get; set; }

        public List<MenuItem> Items { get; set; }

        public Table Table { get; set; }

        public bool Complete { get; set; }

        public bool Expedite { get; set; }

        public override string ToString()
        {
            return String.Join(Environment.NewLine, Items.Select(i => i.Title));
        }

        public Order()
        {
            Id = _nextId;
            _nextId = _nextId + 1;
        }
    }
}
