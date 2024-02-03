using Domain.Common.Models;
using Domain.Menu.Entities;
using Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();

        public Menu(MenuId id) : base(id)
        {
        }

        public string Name { get; }
        public string Description { get; }
        public float AverageRating { get; }

        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    }
}
