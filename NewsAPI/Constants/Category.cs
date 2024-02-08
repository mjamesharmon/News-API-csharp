using System;
namespace NewsAPI.Constants
{
    public readonly struct Category : IEquatable<Category>
    {
        private readonly string _value;

        public static Category Business => new Category(Categories.Business);

        public static Category Entertainment =>
            new Category(Categories.Entertainment);

        public static Category Health => new Category(Categories.Health);

        public static Category Science => new Category(Categories.Science);

        public static Category Sports => new Category(Categories.Sports);

        public static Category Technology =>
            new Category(Categories.Technology);

        public static Category General =>
            new Category(Categories.General);

        public static Category FromName(string category) =>
            new Category(category);

        private Category(string category)
        {
            _value = category.ToLowerInvariant();
        }

        private Category(Categories knownCategory) :
            this(knownCategory.ToString())
        { }

        /// <summary>
        /// 
        /// </summary>
        public string Name => _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Category other)
        {
            return this._value.Equals(other._value);
        }
    }
}

