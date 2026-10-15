namespace CIS3285_Unit4_StudentMVC_2024.Models
{
    // The controller depends on this interface instead of a concrete repository.
    public interface IStudentCRUDInterface
    {
        List<IStudentInterface> getAllStudent();
        IStudentInterface getStudentById(int id);
        void AddStudent(IStudentInterface newStudent);
        void UpdateStudent(int studentId, IStudentInterface updatedStudent);
        void DeleteStudent(int studentId);
    }
}
