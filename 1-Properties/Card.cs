namespace Properties
{
    using System;

    /// <summary>
    /// The class models a card.
    /// </summary>
    public class Card
    {
        private readonly string seed;
        private readonly string name;
        private readonly int ordinal;

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="name">the name of the card.</param>
        /// <param name="seed">the seed of the card.</param>
        /// <param name="ordinal">the ordinal number of the card.</param>
        public Card(string name, string seed, int ordinal)
        {
            this.name = name;
            this.ordinal = ordinal;
            this.seed = seed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="tuple">the informations about the card as a tuple.</param>
        internal Card(Tuple<string, string, int> tuple)
            : this(tuple.Item1, tuple.Item2, tuple.Item3)
        {
        }

        /// <summary>
        /// Fields properties, in this case there are just getters.
        /// </summary>
        public string Seed
        {
            get { return seed; }
        }

        public string Name
        {
            get { return name; }
        }

        public int Ordinal
        {
            get { return ordinal; }
        }

        /// <inheritdoc cref="object.ToString"/>
        public override string ToString()
        {
            // TODO understand string interpolation
            return $"{this.GetType().Name}(Name={this.GetName()}, Seed={this.GetSeed()}, Ordinal={this.GetOrdinal()})";
        }

        /// <inheritdoc cref="object.Equals"/>
        protected bool Equals(Card other)
        {
            return seed == other.seed && name == other.name && ordinal == other.ordinal;
        }

        /// <inheritdoc cref="object.Equals"/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Card) obj);
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            return HashCode.Combine(seed, name, ordinal);
        }
    }
}
