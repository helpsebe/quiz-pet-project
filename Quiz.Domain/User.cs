namespace Quiz.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int TimeTaken { get; set; }
    }
}
