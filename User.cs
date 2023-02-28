namespace MvcPostRequestApp
{
    public class User
    {
        public string? Name { set; get;}
        public int Age { get; set; }
        public override string ToString()
        {
            return $"Name {Name}, Age {Age}";
        }
    }
}
