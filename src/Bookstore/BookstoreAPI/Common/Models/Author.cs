namespace BookstoreAPI.Common.Models
{
    public abstract class Author
    {
        public int Id { get; set; }

        public abstract string ShortName { get; }
        public abstract string FullName { get; }

        public static Author FromNameString(string name)
        {
            if (name.Contains(',')) // multiple names
            {
                var split = name.Split(',', '.', ' ').Where(x => !string.IsNullOrEmpty(x));
                return new MultipleNamesAuthor()
                {
                    Id = this.Id,
                    LastName = split.Last(),
                    FirstNames = split.SkipLast(1).ToList()
                };
            }
            else if (!name.Contains(" ")) // one name
                return new OneNameAuthor()
                {
                    Id = this.Id,
                    Name = name
                };
            else // first and last name
            {
                var split = name.Split(',', '.', ' ').Where(x => !string.IsNullOrEmpty(x));
                return new FullNameAuthor()
                {
                    Id = this.Id,
                    FirstName = split.First(),
                    LastName = split.Last()
                };
            }
        }
    }

    public class OneNameAuthor : Author
    {
        public string Name { get; set; }
        public override string ShortName => Name;

        public override string FullName => Name;
    }

    public class FullNameAuthor : Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ShortName => $"{FirstName.First()}. {LastName}";

        public override string FullName => $"{FirstName} {LastName}";
    }

    public class MultipleNamesAuthor : Author
    {
        public List<string> FirstNames { get; set; }
        public string LastName { get; set; }
        public override string ShortName => $"{string.Join(". ", FirstNames.Select(x => x.First()))}. {LastName}";

        public override string FullName => string.Join(" ", FirstNames) + $" {LastName}";
    }
}
