namespace CIS3285_Unit4_StudentMVC_2024.Models
{
    public class StudentRepository : IStudentCRUDInterface
    {
        private static readonly List<IStudentInterface> myStudents = new();

        public StudentRepository()
        {
            if (myStudents.Count == 0)
            {
                // Sample data for this Unit 5 implementation.
                myStudents.Add(new StudentModel(1001, "Cosmas", 16));
                myStudents.Add(new StudentModel(1002, "Alex", 12));
                myStudents.Add(new StudentModel(1003, "Jordan", 8));
            }
        }

        public List<IStudentInterface> getAllStudent()
        {
            return myStudents;
        }

        public IStudentInterface getStudentById(int id)
        {
            IStudentInterface? student = myStudents.Find(student => student.Id == id);

            // Null Object Pattern: never return null when a student is not found.
            return student ?? new NullStudent();
        }

        public void AddStudent(IStudentInterface newStudent)
        {
            myStudents.Add(newStudent);
        }

        public void DeleteStudent(int studentId)
        {
            int index = myStudents.FindIndex(student => student.Id == studentId);

            // FindIndex returns -1 when there is no match.
            if (index >= 0)
            {
                myStudents.RemoveAt(index);
            }
        }

        public void UpdateStudent(int studentId, IStudentInterface updatedStudent)
        {
            int index = myStudents.FindIndex(student => student.Id == studentId);

            if (index >= 0)
            {
                myStudents[index] = updatedStudent;
            }
        }
    }
}
