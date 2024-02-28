using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;

namespace P42.Uno.Markup;
public static class DependencyPropertyExtensions
{
    internal class DependencyRegistryEntry
    {
        public string Name;
        public Type PropertyType;
        public Type OwnerType;

        public DependencyRegistryEntry(string name, Type propertyType, Type ownerType)
        {
            Name = name;
            PropertyType = propertyType;
            OwnerType = ownerType;
        }

        public override bool Equals(object obj)
        {
            if (obj is not DependencyRegistryEntry entry) return false;

            return entry.Name == Name &&
                entry.PropertyType == PropertyType &&
                entry.OwnerType == OwnerType;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, PropertyType, OwnerType);
        }
    }

    internal static Dictionary<DependencyProperty, DependencyRegistryEntry> DependencyRegistry = new();

    public static DependencyProperty Register(string name, Type propertyType, Type ownerType, PropertyMetadata typeMetadata)
    {
        var property = DependencyProperty.Register(name, propertyType, ownerType, typeMetadata);
        var entry = new DependencyRegistryEntry(name, propertyType, ownerType);

        if (DependencyRegistry.Values.FirstOrDefault(v => v == entry) is DependencyRegistryEntry)
            throw new ArgumentException($"DependencyProperty is already registered : [{name}, {propertyType}, {ownerType}]");

        DependencyRegistry.Add(property, entry);
        return property;
    }

    public static DependencyProperty RegisterAttached(string name, Type propertyType, Type ownerType, PropertyMetadata defaultMetadata)
    {
        var property = DependencyProperty.RegisterAttached(name, propertyType, ownerType, defaultMetadata);
        var entry = new DependencyRegistryEntry(name, propertyType, ownerType);

        if (DependencyRegistry.Values.FirstOrDefault(v => v == entry) is DependencyRegistryEntry)
            throw new ArgumentException($"DependencyProperty is already registered : [{name}, {propertyType}, {ownerType}]");

        DependencyRegistry.Add(property, entry);
        return property;
    }

}
