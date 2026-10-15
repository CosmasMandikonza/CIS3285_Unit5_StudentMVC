namespace CIS3285_Unit4_StudentMVC_2024.Models
{
    /// <summary>
    /// Null Object used when a requested student does not exist.
    /// It still satisfies IStudentInterface, so callers receive a safe object
    /// instead of a null reference.
    /// </summary>
    public class NullStudent : IStudentInterface
    {
        public int Id
        {
            get { return -1; }
            set { }
        }

        public string Name
        {
            get { return "Student Not Found"; }
            set { }
        }

        public int Credits
        {
            get { return 0; }
            set { }
        }
    }
}
