namespace Indexers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <inheritdoc cref="IMap2D{TKey1,TKey2,TValue}" />
    public class Map2D<TKey1, TKey2, TValue> : IMap2D<TKey1, TKey2, TValue>
    {
        private Dictionary<Tuple<TKey1, TKey2>, TValue> map = new Dictionary<Tuple<TKey1, TKey2>, TValue>();

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.NumberOfElements" />
        public int NumberOfElements
        {
            get
            { return this.map.Count; }
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.this" />
        public TValue this[TKey1 key1, TKey2 key2]
        {
            get { return this.map[new Tuple<TKey1, TKey2>(key1, key2)]; }
            set { this.map[new Tuple<TKey1, TKey2>(key1, key2)] = value; }
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetRow(TKey1)" />
        public IList<Tuple<TKey2, TValue>> GetRow(TKey1 key1)
        {
            IList<Tuple<TKey2, TValue>> rowList = new List<Tuple<TKey2, TValue>>();
            foreach (var keys in this.map.Keys)
            {
                if (keys.Item1.Equals(key1))
                {
                    rowList.Add(new Tuple<TKey2, TValue>(keys.Item2, this.map[keys]));
                }
            }

            return rowList;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetColumn(TKey2)" />
        public IList<Tuple<TKey1, TValue>> GetColumn(TKey2 key2)
        {
            IList<Tuple<TKey1, TValue>> columnList = new List<Tuple<TKey1, TValue>>();
            foreach (var keys in this.map.Keys)
            {
                if (keys.Item2.Equals(key2))
                {
                    columnList.Add(new Tuple<TKey1, TValue>(keys.Item1, this.map[keys]));
                }
            }

            return columnList;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetElements" />
        public IList<Tuple<TKey1, TKey2, TValue>> GetElements()
        {
            IList<Tuple<TKey1, TKey2, TValue>> elementsList = new List<Tuple<TKey1, TKey2, TValue>>();
            foreach (var keys in this.map.Keys)
            {
                elementsList.Add(new Tuple<TKey1, TKey2, TValue>(keys.Item1, keys.Item2, this.map[keys]));
            }

            return elementsList;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.Fill(IEnumerable{TKey1}, IEnumerable{TKey2}, Func{TKey1, TKey2, TValue})" />
        public void Fill(IEnumerable<TKey1> keys1, IEnumerable<TKey2> keys2, Func<TKey1, TKey2, TValue> generator)
        {
            foreach (var row in keys1)
            {
                foreach (var column in keys2)
                {
                    this.map[new Tuple<TKey1, TKey2>(row, column)] = generator(row, column);
                }
            }
        }

        protected bool Equals(Map2D<TKey1, TKey2, TValue> other)
        {
            return Equals(map, other.map);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Map2D<TKey1, TKey2, TValue>) obj);
        }

        public override int GetHashCode()
        {
            return (map != null ? map.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return $"{nameof(map)}: {map}";
        }
    }
